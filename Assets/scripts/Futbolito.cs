using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Random = UnityEngine.Random;

public class Futbolito : Agent

{

    public GameObject[] EquipoArr;
    public GameObject[] EquipoRivalArr;
    
    public GameObject agente;
    public GameObject balon;

    string[] nombresPalo= {"Palo1-","Palo2-","Palo3-","Palo4-"};

    public int palos = 4;

    void Start()
    {
        EquipoArr = new GameObject[palos];
        EquipoRivalArr = new GameObject[palos];
        

        char team = this.name[this.name.Length-1];
        char rival = 'B';

        if(team == 'B'){
            rival = 'R';
        }

        for (int i = 0; i < palos; i++)
        {
            EquipoRivalArr[i] = GameObject.Find(nombresPalo[i] + rival);
            EquipoArr[i] = GameObject.Find(nombresPalo[i] + team);
        }
        balon =  GameObject.FindWithTag("Pelota");

    }
    public override void OnEpisodeBegin()
    {
        //Se reinicia la posicion y rotacion del palo
        this.agente.GetComponent<Transform>().localPosition=new Vector3(0,0,0);
        this.agente.GetComponent<Transform>().localRotation = new Quaternion(0, 0, 0, 0);


        //Reset the parameters when the Agent is reset.
 
    }


    public override void CollectObservations(VectorSensor sensor){
        
        for (int i = 0; i < palos; i++)
        {
            sensor.AddObservation(EquipoArr[i].transform.position.z);
            sensor.AddObservation(EquipoArr[i].transform.position.x);
            sensor.AddObservation(EquipoArr[i].transform.rotation.z);

            sensor.AddObservation(EquipoRivalArr[i].transform.position.z);
            sensor.AddObservation(EquipoRivalArr[i].transform.position.x);
            sensor.AddObservation(EquipoRivalArr[i].transform.rotation.z);
        } 

        sensor.AddObservation(balon.transform.position.x);
        sensor.AddObservation(balon.transform.position.y);
        sensor.AddObservation(balon.transform.position.z);
        sensor.AddObservation(balon.GetComponent<Rigidbody>().velocity);
        

    }
    
    public override void Heuristic(in ActionBuffers salidaAcciones){
        var acciones = salidaAcciones.ContinuousActions;
        acciones[0] = Input.GetAxis("Horizontal");
        acciones[1] = Input.GetAxis("Vertical");
    }

    public override void OnActionReceived(ActionBuffers acc){
        Vector3 control = Vector3.zero;
        control.z = acc.ContinuousActions[0];
        Vector3 controlRot = Vector3.zero;
        controlRot.z = acc.ContinuousActions[1];
        
        this.agente.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,acc.ContinuousActions[1]*5);
        this.agente.GetComponent<Rigidbody>().AddTorque(0f,0f,acc.ContinuousActions[0]*5);

        if(this.name[this.name.Length - 1] == 'R')
        {
            if (this.balon.transform.localPosition.x < -15)
            {
                SetReward(1.0f);
                EndEpisode();
            }
            if(this.balon.transform.localPosition.x > 15)
            {
                SetReward(-1.0f);
                EndEpisode();
            }
        }

        if (this.name[this.name.Length - 1] == 'B')
        {
            if (this.balon.transform.localPosition.x < -15)
            {
                SetReward(-1.0f);
                EndEpisode();
            }
            if (this.balon.transform.localPosition.x > 15)
            {
                
                SetReward(1.0f);
                EndEpisode();
            }
        }


        if (this.balon.transform.localPosition.y < 0)
        {
            EndEpisode();
        }


        /*float distancia = Vector3.Distance(this.transform.localPosition, objetivo.localPosition);
        if (distancia < 1.2f){
            SetReward(1.0f);
            EndEpisode();
        }
        */
    }
}
