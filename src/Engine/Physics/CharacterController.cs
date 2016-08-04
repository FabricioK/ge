﻿using Newtonsoft.Json;
using System.Numerics;

namespace Engine.Physics
{
    public class CharacterController : Component
    {
        private PhysicsSystem _physics;

        [JsonIgnore]
        public BEPUphysics.Character.CharacterController Controller { get; private set; }

        public override void Attached(SystemRegistry registry)
        {
            _physics = registry.GetSystem<PhysicsSystem>();
            Controller = new BEPUphysics.Character.CharacterController(
                Transform.Position,
                jumpSpeed: 8f,
                tractionForce: 1500
                );
            _physics.AddObject(Controller);
            Transform.SetPhysicsEntity(Controller.Body);
        }

        public override void Removed(SystemRegistry registry)
        {
            _physics.RemoveObject(Controller);
            Transform.RemovePhysicsEntity();
        }

        public void SetMotionDirection(Vector2 motion)
        {
            Controller.HorizontalMotionConstraint.MovementDirection = motion;
        }
    }
}