using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public class ParticlesData
    {
        [SerializeField] ParticleSystem particle;
        [SerializeField] float min;
        [SerializeField] float max;

        public void SetMin()
        {
            var emission = particle.emission;
            emission.rateOverTime = min;
        }

        public void SetMax()
        {
            var emission = particle.emission;
            emission.rateOverTime = max;
        }
    }
}
