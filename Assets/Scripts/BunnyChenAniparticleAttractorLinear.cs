using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class BunnyChenAniparticleAttractorLinear : MonoBehaviour
{
    ParticleSystem ps;
    ParticleSystem.Particle[] m_Particles;
    public Transform target;
    public float speed = 5f;
    int numParticlesAlive;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (!GetComponent<Transform>())
        {
            GetComponent<Transform>();
        }
    }

    void Update()
    {
        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        float step = speed * Time.deltaTime;
        for (int i = 0; i < numParticlesAlive; i++)
        {
            // m_Particles[i].position = Vector3.LerpUnclamped(m_Particles[i].position, target.position, step);
            // 计算目标与当前粒子的位置差
            Vector3 directionToTarget = target.position - m_Particles[i].position;

            // 调整每个轴的速度因子
            float adjustedSpeedX = step * 5f; // X 轴速度较慢
            float adjustedSpeedY = step *10; // Y 轴速度较快
            float adjustedSpeedZ = step * 10; // Z 轴速度较快

            // 逐轴处理位置变更
            m_Particles[i].position += new Vector3(
                directionToTarget.x * adjustedSpeedX,
                directionToTarget.y * adjustedSpeedY,
                directionToTarget.z * adjustedSpeedZ
            );
        }

        ps.SetParticles(m_Particles, numParticlesAlive);
    }
}