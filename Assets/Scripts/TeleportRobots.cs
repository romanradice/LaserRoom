using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRobots : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip laserSong;

    private Animator animatorRouge;
    private Animator animatorVert;
    private Animator animatorBleu;
    private Animator animatorJaune;


    public GameObject prefabRobotRouge;
    public GameObject prefabRobotVert;
    public GameObject prefabRobotBleu;
    public GameObject prefabRobotJaune;

    public float delayTp;
    public GameObject[] positionsRobots;
    public GameObject CircleParticleSystemRouge;
    public GameObject CircleParticleSystemBleu;
    public GameObject CircleParticleSystemVert;
    public GameObject CircleParticleSystemJaune1;
    public GameObject CircleParticleSystemJaune2;

    private List<GameObject> robots = new List<GameObject>();

    private List<GameObject> particles = new List<GameObject>();
    private void Awake()
    {
        //animatorRouge = prefabRobotRouge.GetComponent<Animator>();
        //animatorVert = prefabRobotVert.GetComponent<Animator>();
        //animatorBleu = prefabRobotBleu.GetComponent<Animator>();
        //animatorJaune = prefabRobotJaune.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stop_spawn()
    {
        StopAllCoroutines();
        foreach (var robot in robots)
        {
            robots.Remove(robot);
            Destroy(robot);
        }
        foreach (var particle in particles)
        {
            particles.Remove(particle);
            Destroy(particle);
        }

    }

    public IEnumerator TpCooldownRouge()
    {
        int delayTpRandom = Random.Range(1, 3);
        yield return new WaitForSeconds(delayTpRandom);
        int caseRandom = Random.Range(0, 63);
        //GameObject g = Instantiate(prefabRobotRouge, positionsRobots[caseRandom].transform.position, Quaternion.identity) as GameObject; ;
        GameObject robotRouge = Instantiate(prefabRobotRouge, positionsRobots[caseRandom].transform.position, prefabRobotRouge.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        robots.Add(robotRouge);
        //add
        animatorRouge = robotRouge.GetComponent<Animator>();
        yield return new WaitForSeconds(0.5f);
        //
        GameObject robotRougeParticles = Instantiate(CircleParticleSystemRouge, positionsRobots[caseRandom].transform.position, prefabRobotRouge.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotRougeParticles);
        yield return new WaitForSeconds(1f);
        animatorRouge.SetBool("shoot", true);
        yield return new WaitForSeconds(1f);
        audio.PlayOneShot(laserSong);
        //robotRougeParticles.transform.Rotate(90f, 0f, 0f);
        yield return new WaitForSeconds(delayTp);
        robots.Remove(robotRouge);
        particles.Remove(robotRougeParticles);
        Destroy(robotRouge, 1.0f);
        Destroy(robotRougeParticles, 1.0f);

        StartCoroutine(TpCooldownRouge());
        //foreach (GameObject objet in positionsRobots)
        //{
        //Instantiate(prefabRobotRouge, objet.transform.position, Quaternion.identity);
        //objet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphaLevel);
        //}
        //Instantiate(prefabRobotRouge, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public IEnumerator TpCooldownBleu()
    {
        int delayTpRandom = Random.Range(1, 3);
        yield return new WaitForSeconds(delayTpRandom);
        int caseRandom = Random.Range(0, 63);
        //GameObject g = Instantiate(prefabRobotRouge, positionsRobots[caseRandom].transform.position, Quaternion.identity) as GameObject; ;
        GameObject robotBleu = Instantiate(prefabRobotBleu, positionsRobots[caseRandom].transform.position, prefabRobotBleu.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        robots.Add(robotBleu);
        //add
        animatorBleu = robotBleu.GetComponent<Animator>();
        yield return new WaitForSeconds(0.5f);
        animatorBleu.SetBool("shoot", true);
        audio.PlayOneShot(laserSong);
        //

        GameObject robotBleuParticles = Instantiate(CircleParticleSystemBleu, positionsRobots[caseRandom].transform.position, prefabRobotBleu.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotBleuParticles);
        
        yield return new WaitForSeconds(0.5f);
        audio.PlayOneShot(laserSong);
        GameObject robotBleuParticles2 = Instantiate(CircleParticleSystemBleu, positionsRobots[caseRandom].transform.position, prefabRobotBleu.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotBleuParticles2);
        yield return new WaitForSeconds(0.5f);
        GameObject robotBleuParticles3 = Instantiate(CircleParticleSystemBleu, positionsRobots[caseRandom].transform.position, prefabRobotBleu.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotBleuParticles3);
        //robotRougeParticles.transform.Rotate(90f, 0f, 0f);
        yield return new WaitForSeconds(delayTp);
        robots.Remove(robotBleu);
        particles.Remove(robotBleuParticles);
        particles.Remove(robotBleuParticles2);
        particles.Remove(robotBleuParticles3);
        Destroy(robotBleu, 1.0f);
        Destroy(robotBleuParticles, 1.0f);
        Destroy(robotBleuParticles2, 1.0f);
        Destroy(robotBleuParticles3, 1.0f);


        StartCoroutine(TpCooldownBleu());
        //foreach (GameObject objet in positionsRobots)
        //{
        //Instantiate(prefabRobotRouge, objet.transform.position, Quaternion.identity);
        //objet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphaLevel);
        //}
        //Instantiate(prefabRobotRouge, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public IEnumerator TpCooldownVert()
    {
        int delayTpRandom = Random.Range(1, 3);
        yield return new WaitForSeconds(delayTpRandom);
        int caseRandom = Random.Range(0, 63);
        //GameObject g = Instantiate(prefabRobotRouge, positionsRobots[caseRandom].transform.position, Quaternion.identity) as GameObject; ;
        GameObject robotVert = Instantiate(prefabRobotVert, positionsRobots[caseRandom].transform.position, prefabRobotVert.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        robots.Add(robotVert);
        //add
        animatorVert = robotVert.GetComponent<Animator>();
        yield return new WaitForSeconds(0.5f);
        
        //

        GameObject robotVertParticles = Instantiate(CircleParticleSystemVert, new Vector3(1f, 1f, 4.9f), prefabRobotVert.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotVertParticles);
        yield return new WaitForSeconds(0.5f);
        GameObject robotVertParticles2 = Instantiate(CircleParticleSystemVert, new Vector3(1f, 1f, 4.9f), prefabRobotVert.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotVertParticles2);
        yield return new WaitForSeconds(0.5f);
        GameObject robotVertParticles3 = Instantiate(CircleParticleSystemVert, new Vector3(1f, 1f, 4.9f), prefabRobotVert.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotVertParticles3);
        
        yield return new WaitForSeconds(0.5f);
        animatorVert.SetBool("shoot", true);
        audio.PlayOneShot(laserSong);
        //robotRougeParticles.transform.Rotate(90f, 0f, 0f);
        yield return new WaitForSeconds(delayTp);
        robots.Remove(robotVert);
        particles.Remove(robotVertParticles);
        particles.Remove(robotVertParticles2);
        particles.Remove(robotVertParticles3);
        Destroy(robotVert, 1.0f);
        Destroy(robotVertParticles, 1.0f);
        Destroy(robotVertParticles2, 1.0f);
        Destroy(robotVertParticles3, 1.0f);


        StartCoroutine(TpCooldownVert());
        //foreach (GameObject objet in positionsRobots)
        //{
        //Instantiate(prefabRobotRouge, objet.transform.position, Quaternion.identity);
        //objet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphaLevel);
        //}
        //Instantiate(prefabRobotRouge, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public IEnumerator TpCooldownJaune()
    {
        int delayTpRandom = Random.Range(1, 3);
        yield return new WaitForSeconds(delayTpRandom);
        int caseRandom = Random.Range(0, 63);
        //GameObject g = Instantiate(prefabRobotRouge, positionsRobots[caseRandom].transform.position, Quaternion.identity) as GameObject; ;
        GameObject robotJaune = Instantiate(prefabRobotJaune, positionsRobots[caseRandom].transform.position, prefabRobotJaune.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        robots.Add(robotJaune);
        //add
        animatorJaune = robotJaune.GetComponent<Animator>();
        yield return new WaitForSeconds(0.5f);
        animatorJaune.SetBool("shoot", true);
        
        yield return new WaitForSeconds(2f);
        audio.PlayOneShot(laserSong);
        //
        GameObject robotJauneParticles = Instantiate(CircleParticleSystemJaune1, positionsRobots[caseRandom].transform.position, prefabRobotJaune.transform.rotation * Quaternion.Euler(90f, 180f, 0f)) as GameObject;
        particles.Add(robotJauneParticles);
        GameObject robotJauneParticles2 = Instantiate(CircleParticleSystemJaune1, positionsRobots[caseRandom].transform.position, prefabRobotJaune.transform.rotation * Quaternion.Euler(90f, 90f, 0f)) as GameObject;
        particles.Add(robotJauneParticles2);



        //robotRougeParticles.transform.Rotate(90f, 0f, 0f);
        yield return new WaitForSeconds(delayTp);
        robots.Remove(robotJaune);
        particles.Remove(robotJauneParticles);
        particles.Remove(robotJauneParticles2);
        Destroy(robotJaune, 1.0f);
        Destroy(robotJauneParticles, 1.0f);
        Destroy(robotJauneParticles2, 1.0f);


        StartCoroutine(TpCooldownJaune());
        //foreach (GameObject objet in positionsRobots)
        //{
        //Instantiate(prefabRobotRouge, objet.transform.position, Quaternion.identity);
        //objet.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphaLevel);
        //}
        //Instantiate(prefabRobotRouge, new Vector3(0, 0, 0), Quaternion.identity);

    }

}
