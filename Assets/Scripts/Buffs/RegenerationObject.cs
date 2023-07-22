using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerationObject : MonoBehaviour
{
    [SerializeField]
    private int _layerPlayer = 9;
    [SerializeField]
    private CircleCollider2D _circleCollider2D;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private Regeneration _regeneration;
    [SerializeField]
    private float _regenerationAmount;
    [SerializeField]
    private float _time;
    [SerializeField]
    private float _timeToDestroy; //para que se destruya cuando ya termino de sonar
    [SerializeField]
    private OnOffUIBuffAndDebuff _icon;
    private OnOffUIBuffAndDebuff[] _auxIcon;
    private int _totalOfBuffsAndDebuffs=6;
    [SerializeField]
    private OnOffUIBuffAndDebuff.TypeOfBuffOrDebuff _typeForUse;
    private const int _constZero = 0;
    void Start()
    {
        _auxIcon = new OnOffUIBuffAndDebuff[_totalOfBuffsAndDebuffs];
        if ( _circleCollider2D == null )
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
        }
        if ( _spriteRenderer == null )
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if ( _audioSource == null )
        {
            _audioSource = GetComponent<AudioSource>();
        }
        if( _regeneration == null)
        {
            _regeneration = FindObjectOfType<Regeneration>();
        }
        if (_icon == null)
        {
            _auxIcon = FindObjectsOfType<OnOffUIBuffAndDebuff>();
            for (int i = _constZero; i < _auxIcon.Length; i++)
            {
                if (_auxIcon[i].GetTypeOfBuffOrDebuff() == _typeForUse)
                {
                    _icon = _auxIcon[i];
                    break;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerPlayer)
        {
            _regeneration.StartRegeneration(_regenerationAmount, _time);
            _audioSource.Play();
            _spriteRenderer.enabled = false;
            _circleCollider2D.enabled = false;
            if (_icon != null)
            {
                _icon.SetOnTimer(_time);
            }
            StartCoroutine(DestroyAfterSeconds(_timeToDestroy));
        }
    }
    private IEnumerator DestroyAfterSeconds(float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        Destroy(this.gameObject);
    }
    public void SetIcon(OnOffUIBuffAndDebuff icon)
    {
        _icon = icon;
    }
}
