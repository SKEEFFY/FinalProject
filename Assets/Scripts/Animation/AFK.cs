using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AFK : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _afkTreshold;

    private float _activityTime;
    private static readonly int HashAnimatorBool = Animator.StringToHash("Afk");
    private bool  isAfk = false;

    private Coroutine _coroutine;

    public UnityEvent OnAfk = new UnityEvent();
    public UnityEvent OffAfk = new UnityEvent();

    private void Start()
    {
        OnAfkMusic.EndMusic.AddListener(OnReturnFromAfk);
    }

    void Update()
    {
        if(Input.anyKey)
        {
            _activityTime = Time.time;
            if(isAfk)
            {
                isAfk = false;
                OnReturnFromAfk();
            }
        }
        if (!isAfk && Time.time - _activityTime > _afkTreshold)
        {
            {
                isAfk = true;
                _coroutine = StartCoroutine(EnableAfk());
            }
        }
    }

    private void OnReturnFromAfk()
    {
        _animator.SetBool(HashAnimatorBool, false);
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        OffAfk.Invoke();
    }

    private IEnumerator EnableAfk()
    {
            OnAfk.Invoke();
            yield return new WaitForSeconds(10.5f);
            _animator.SetBool(HashAnimatorBool, true);   
    }
}
