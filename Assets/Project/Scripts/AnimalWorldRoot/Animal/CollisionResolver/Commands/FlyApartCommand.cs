using AnimalWorld.Animal;
using UnityEngine;

namespace AnimalWorld.Resolver
{
    public sealed class FlyApartCommand : ICollisionCommand
    {
        private readonly float _force;

        public FlyApartCommand(float force)
        {
            _force = force;
        }

        public void Execute(AnimalMono self, Collision collision)
        {
            Vector3 normal = collision.contacts[0].normal;
            normal.y = 0.5f;

            self.rigidbody.AddForce(normal.normalized * _force, ForceMode.Impulse);
        }
    }
}
