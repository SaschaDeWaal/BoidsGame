using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonoBehaviour {

    public GameObject boidTemplate;
    private List<Boid> boids = new List<Boid>();

    /// <summary>
    /// Create boids inside the world. Exsisting boids will be deleted.
    /// </summary>
    /// <param name="amount">How many boids should be created</param>
    public void Create(int amount) {
        Clear();

        for(int i = 0; i < amount; i++) {
            boids.Add(CreateBoid());
        }
    }

    /// <summary>
    /// Clears and destroys all boids.
    /// </summary>
    public void Clear() {
        foreach(Boid boid in boids) {
            Destroy(boid.gameObject);
        }

        boids.Clear();
    }

    private void LateUpdate() {
        Vector3 averageBoidsPosition = GetAveragePositionOfAllBoids();

        foreach(Boid boid in boids) {
            boid.UpdatePosition(boids, averageBoidsPosition);
        }
    }

    private Vector3 GetAveragePositionOfAllBoids() {
        Vector3 position = Vector3.zero;

        foreach(Boid boid in boids) {
            position += boid.transform.position;
        }

        return position / boids.Count;
    }

    private Boid CreateBoid() {
        GameObject newBoid = Instantiate(boidTemplate);
        newBoid.transform.position = new Vector3(Random.Range(10, 90), 0 , Random.Range(10, 90));
        return newBoid.GetComponent<Boid>();
    }
}
