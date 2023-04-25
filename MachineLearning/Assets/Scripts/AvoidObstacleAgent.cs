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

    public MeshRenderer gmr;
    public Material win;
    public Material lose;

    public Obstacle[] obs;

    void Start()
    {
        startPos = transform.position;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = startPos;
        foreach (Obstacle o in obs)
        {
            o.UpdatePosition();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.position);
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        pc.updateInput(actions.ContinuousActions[0]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        pc.updateInput(Input.GetAxis("Horizontal"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AddReward(-10);
            gmr.material = lose;
            EndEpisode();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            AddReward(100);
            gmr.material = win;
            EndEpisode();

        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ClearPath"))
        {
            AddReward(80);
        }
    }

}
