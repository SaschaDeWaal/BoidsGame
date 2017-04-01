using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    //rule 1: To Center
    private const float MOVE_TO_CENTER_SPEED = 0.01f;

    //rule 2: Move away from others
    private const float MOVE_AWAY_FROM_BOIDS = 2f;
    private const float MIN_KEEP_AWAY_DISTANCE = 4f;

    //rule 3: Match other boids velocity
    private const float MATCH_BOIDS_DISTANCE = 10;
    private const float MATCH_OTHER_BOIDS = 0.8f;

    //rule 4: Run away from dog
    private const float RUN_AWAY_DOG_SPEED = 0.01f;

    private const float OVERAL_SPEED = 0.01f;
    private const float MAX_VELOCITY = 0.3f;

    public Vector3 velocity = Vector3.zero;
    public MeshRenderer meshRender;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UpdatePosition(List<Boid> boids, Vector3 averagePosition) {

        velocity += MoveTowardsAverageBoidsPosition(averagePosition, boids) * OVERAL_SPEED;
        velocity += KeepDistanteFromOthers(boids)                           * OVERAL_SPEED;
        velocity += TryToMatchNearBoids(boids)                              * OVERAL_SPEED;
        velocity += RunAwayFromDog(boids)                                   * OVERAL_SPEED;
        velocity += KeepInsideField()                                       * OVERAL_SPEED;

        velocity = velocity.Clamp(-MAX_VELOCITY, MAX_VELOCITY);

        Vector3 velocity3D = new Vector3(velocity.x, 0, velocity.z);
        transform.LookAt(transform.position + velocity3D);
        transform.position += velocity3D;
    }

    //Rule 1: boids should move towards the average position of all boids
    private Vector3 MoveTowardsAverageBoidsPosition(Vector3 averagePosition, List<Boid> boids) {

        //We already have the average position of all boids from the BoidsManager.
        //Now we need to remove this boids position from this position. 
        averagePosition -= transform.position / boids.Count;

        return (averagePosition - transform.position) * MOVE_TO_CENTER_SPEED;
    }

    //Rule 2: Boids try to keep a small distance away from other boids.
    private Vector3 KeepDistanteFromOthers(List<Boid> boids) {
        Vector3 direction = Vector3.zero;

        foreach(Boid boid in boids) {
            if(!boid.Equals(this)) {

                float distance = Vector3.Distance(transform.position, boid.transform.position);

                if(distance < MIN_KEEP_AWAY_DISTANCE) {
                    direction += (transform.position - boid.transform.position) * MOVE_AWAY_FROM_BOIDS;
                }
            }
        }

        return direction;
    }

    //Rule 3: Boids try to match velocity with near boids. 
    private Vector3 TryToMatchNearBoids(List<Boid> boids) {

        Vector3 nearVelocity = Vector3.zero;
        int boidsCounted = 0;

        foreach(Boid boid in boids) {
            if(!boid.Equals(this)) {

                float distance = Vector3.Distance(transform.position, boid.transform.position);

                if(distance < MATCH_BOIDS_DISTANCE) {
                    nearVelocity += boid.velocity;
                    boidsCounted++;
                }
            }

        }

        if(boidsCounted > 0) {
            nearVelocity = nearVelocity / boidsCounted;
        }

        return nearVelocity * MATCH_OTHER_BOIDS;
    }

    //rule4: They run away from the dog
    private Vector3 RunAwayFromDog(List<Boid> boids) {
        float speed = 100 - Vector3.Distance(transform.position, player.transform.position);
        Vector3 vel = Vector3.MoveTowards(Vector3.zero, player.transform.position - transform.position, 1f) * -1 * RUN_AWAY_DOG_SPEED * speed;

        return vel;
    }

    //rule5: When boids are near the end of the field, they run inside the field
    private Vector3 KeepInsideField() {
        return Tools.OutsideRange(transform.position, 8, 93) * -1;
    }

}