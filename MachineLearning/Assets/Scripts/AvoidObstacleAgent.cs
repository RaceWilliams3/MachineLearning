using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class AvoidObstacleAgent : Agent
{
    public PlayerController pc;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = startPos;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        pc.updateInput(actions.ContinuousActions[0]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AddReward(-1);
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            AddReward(1);
            EndEpisode();

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AddReward(-0.1f);
        }
    }
}
