using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HNS.FSM;
using HNS.FSM.StateReferences;
using HNS.ParentState.GroundState;
using HNS.Data.PlayerData;
using UniGLTF;

namespace HNS.SubState.WalkState
{
    public class WalkState : ParentGroundedState
    {
        public WalkState(PlayerController playerController, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
        {
            InitializeData();
        }

        public void InitializeData()
        {
            _playerData.timeTargetRotation.y = 0.14f;
        }
        public override void CheckerState()
        {
            base.CheckerState();
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void LogicStateUpdate()
        {
            base.LogicStateUpdate();
            if (Input.x == 0f && Input.y == 0f)
            {
                _stateMachine.ChangeState(_playerController.IdleStates);
                _playerController.Anim.SetFloat("Speed", 0f);
                Debug.Log("Idle State");
            }
            //_playerData.SetSpeedModifier(1);
            float targetMovementRotation = Rotate(_playerController.MoveDirection());
            Vector3 targerRotation = GetTargetRotation(targetMovementRotation);
            _playerController.RB.AddForce(targerRotation * _playerData.GetMovementSpeed() - _playerController.GetCurrentHorizontalVelocity(), ForceMode.Force);
        }
        public override void PhysicsStateUpdate()
        {
            base.PhysicsStateUpdate();
        }
        public float Rotate(Vector3 Direction)
        {
            float directionAngle = UpdateTargetRotation(Direction);

            RotateTowardsTargetRotation();
            return directionAngle;
        }
        public void RotateTowardsTargetRotation()
        {
            float currentYAngle = _playerController.RB.rotation.eulerAngles.y;
            if (currentYAngle == _playerData.GetCurrentTargetRotation().y)
            {
                return;
            }
            float smoothYAngle = Mathf.SmoothDampAngle(currentYAngle, _playerData.GetCurrentTargetRotation().y, ref _playerData.dampedTargetRotationCurrentVelocity.y, _playerData.GetTimeTargetRotation().y - _playerData.GetDampRotatePassTime().y);
            _playerData.dampedTargetRotationPassedTime.y += Time.deltaTime;
            Quaternion targetRotation = Quaternion.Euler(0f, smoothYAngle, 0f);
            _playerController.RB.MoveRotation(targetRotation);
        }
        public float UpdateTargetRotation(Vector3 Direction, bool ConsiderCameraRotation = true)
        {
            float directionAngle = GetDirectionAngle(Direction);
            if (ConsiderCameraRotation)
            {
                directionAngle = AddCameraRotate(directionAngle);
            }
            if (directionAngle != _playerData.currentTargetRotation.y)
            {
                UpdateTargetRotations(directionAngle);
            }
            return directionAngle;
        }
        public float GetDirectionAngle(Vector3 Direction)
        {
            float directionAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg;
            if (directionAngle < 0f)
            {
                directionAngle += 360f;
            }
            return directionAngle;
        }
        public float AddCameraRotate(float Angle)
        {
            Angle += _playerController.MainCameraTransform.eulerAngles.y;
            if (Angle > 360f)
            {
                Angle -= 360f;
            }
            return Angle;
        }

        public void UpdateTargetRotations(float Target)
        {
            _playerData.currentTargetRotation.y = Target;
            _playerData.dampedTargetRotationPassedTime.y = 0f;
        }
        public Vector3 GetTargetRotation(float TargetAngle)
        {
            return Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
        }
        //public float UpdateTargetRotation(Vector3 Direction)
        //{
        //    float directionAngle = GetDirectionAngle(Direction);
        //    directionAngle = AddCameraRotate(directionAngle);
        //    if(directionAngle != _playerData.GetCurrentTargetRotation().y)
        //    {
        //        UpdateTargetRotation(directionAngle);
        //    }
        //    return directionAngle;
        //}
    }
}

