using UnityEngine;
using System.Collections;

public enum Type
{
    swarm,
    range
}

public class ground_enemy_movment : MonoBehaviour
{

    public Type type;
    public float speed = 15.0f;

    //for range units only, in seconds
    public float fire_speed = 20.0f;
    public float fire_rate = 3.0f;
    public Transform spawn_position;
    public GameObject pool;
    public Transform pivot;

    private float fire_interval_time;
    private Transform target;
    private Rigidbody body;
    private Vector3 heading;
    private Vector3 desired_velocity;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pool = GameObject.FindGameObjectWithTag("enemy_bullet_pool");
        body = GetComponent<Rigidbody>();
        pivot = transform;
        fire_interval_time = fire_rate;
    }

    void Update()
    {

        heading = Vector3.Normalize(body.velocity);

        if (type == Type.swarm)
            swarm_update();
        else
            range_update();

        face_player();
    }

    void swarm_update()
    {
        Vector3 to_target = target.position - transform.position;
        Vector3 target_heading = Vector3.Normalize(target.GetComponent<Rigidbody>().velocity);
        float relative_heading = Vector3.Dot(heading, target_heading);

        if (Vector3.Dot(to_target, target_heading) > 0 && (relative_heading < -0.95))
            desired_velocity = seek(target.position);
        else
        {

            float look_ahead_time = to_target.magnitude / (speed + target.GetComponent<Rigidbody>().velocity.magnitude);
            look_ahead_time += turn_around_time();
            desired_velocity = seek(target.position + target.GetComponent<Rigidbody>().velocity * look_ahead_time);
        }

        body.AddForce(desired_velocity);
    }

    void range_update()
    {
        Vector3 firing_direction = Vector3.zero;
        Vector3 bullet_initial_pos = spawn_position.position;
        Vector3 target_initial_pos = target.position;
        Vector3 target_initial_vel = target.GetComponent<Rigidbody>().velocity;
        float target_speed = target_initial_vel.magnitude;
        float spawn_target_init_dist = (target_initial_pos - bullet_initial_pos).magnitude;

        //law of cosines
        float cos_theta = Vector3.Dot(Vector3.Normalize(bullet_initial_pos - target_initial_pos), Vector3.Normalize(target_initial_vel));
        float a = Mathf.Pow(fire_speed, 2.0f) - Mathf.Pow(target_speed, 2.0f);
        float b = 2.0f * spawn_target_init_dist * target_speed * cos_theta;
        float c = -1.0f * Mathf.Pow(spawn_target_init_dist, 2.0f);

        float t_plus = (-b + Mathf.Sqrt(Mathf.Pow(b, 2.0f) - 4.0f * a * c)) / (2.0f * a);
        float t_minus = (-b - Mathf.Sqrt(Mathf.Pow(b, 2.0f) - 4.0f * a * c)) / (2.0f * a);

        float actual_t;

        //checking for negative values and discarding them
        if (t_plus < 0 || t_minus < 0)
        {
            if (t_plus < 0)
                actual_t = t_minus;
            else
                actual_t = t_plus;
        }
        else
        {
            //both are positve, so pick the smallest one
            if (t_plus < t_minus)
                actual_t = t_plus;
            else
                actual_t = t_minus;
        }

        firing_direction = Vector3.Normalize(target_initial_vel + ((target_initial_pos - bullet_initial_pos) / actual_t));

        //rotate towards firing direction
        transform.rotation = Quaternion.LookRotation(firing_direction);
        if (fire_interval_time <= 0)
            shoot();
        fire_interval_time -= Time.deltaTime * (float)fire_speed;
    }

    void shoot()
    {
        GameObject bullet = pool.GetComponent<object_pooler>().get_pooled_object();
        if (bullet == null)
            return;

        bullet.transform.position = spawn_position.position;
        bullet.transform.rotation = spawn_position.rotation;
        bullet.GetComponent<movement>().direction = spawn_position.forward;
        bullet.SetActive(true);

        fire_interval_time = fire_rate;
    }

    float turn_around_time()
    {
        Vector3 to_target = Vector3.Normalize(target.position - transform.position);
        float dot = Vector3.Dot(heading, to_target);
        float coefficient = 0.5f;
        return (dot - 1.0f) * -coefficient;
    }

    void face_player()
    {
        Vector3 target_dir = target.position - pivot.position;
        float step = speed * Time.deltaTime;
        Vector3 new_dir = Vector3.RotateTowards(transform.forward, target_dir, step, 0.0f);
        pivot.rotation = Quaternion.LookRotation(new_dir);
    }

    Vector3 seek(Vector3 target_pos)
    {
        Vector3 des_vel = Vector3.Normalize(target_pos - transform.position) * speed;
        return (des_vel - body.velocity);
    }
}
