using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;
    //Unity�������ړ�������R���|�[�l���g������i�ǉ��j
    private Rigidbody myRigidbody;
    //�O�����̑��x�i�ǉ��j
    private float velocityZ = 16f;
    //�������̑��x�i�ǉ��j
    private float velocityX = 10f;
    //������̑��x�i�ǉ��j
    private float velocityY = 10f;
    //���E�̈ړ��ł���͈́i�ǉ��j
    private float movableRange = 3.4f;
    //����������������W���i�ǉ��j
    private float coefficient = 0.99f;
    //�Q�[���I���̔���i�ǉ��j
    private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {

        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbody�R���|�[�l���g���擾�i�ǉ��j
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //�Q�[���I���Ȃ�Unity�����̓�������������i�ǉ��j
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //�������̓��͂ɂ�鑬�x�i�ǉ��j
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x�i�ǉ��j
        float inputVelocityY = 0;

        //Unity��������L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������i�ǉ��j
        if (Input.GetKey (KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //�������ւ̑��x�����i�ǉ��j
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey (KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //�E�����ւ̑��x�����i�ǉ��j
            inputVelocityX = this.velocityX;
        }

        //�W�����v���Ă��Ȃ����ɃX�y�[�X�������ꂽ��W�����v����i�ǉ��j
        if (Input.GetKeyDown (KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //�W�����v�A�j�����Đ��i�ǉ��j
            this.myAnimator.SetBool("Jump", true);
            //������ւ̑��x�����i�ǉ��j
            inputVelocityY = this.velocityY;
        }
        else
        {
            //���݂�Y���̑��x�����i�ǉ��j
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump�X�e�[�g�̏ꍇ��Jump��false���Z�b�g����i�ǉ��j
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //Unity�����ɑ��x��^����i�ύX�j
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }

    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏����i�ǉ��j
    void OnTriggerEnter(Collider other)
    {

        //��Q���ɏՓ˂����ꍇ�i�ǉ��j
        if (other.gameObject.CompareTag("CarTag") || other.gameObject.CompareTag("TrafficConeTag"))
        {
            this.isEnd = true;
        }
        //�S�[���n�_�ɓ��B�����ꍇ�i�ǉ��j
        else if (other.gameObject.CompareTag("GoalTag"))
        {
            this.isEnd = true;
        }
        //�R�C���ɏՓ˂����ꍇ�i�ǉ��j
        else if (other.gameObject.CompareTag("CoinTag"))
        {
            //�ڐG�����R�C���̃I�u�W�F�N�g��j���i�ǉ��j
            Destroy(other.gameObject);
        }
    }
}
