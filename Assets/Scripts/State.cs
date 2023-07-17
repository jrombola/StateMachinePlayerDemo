
using UnityEngine;
public abstract class State
{
    protected float time { get; set; }
    protected float fixedtime { get; set; }
    protected float latetime { get; set; }

    public StateMachine stateMachine;

    //Called at the beginning to set in initial variables
    public virtual void OnEnter(StateMachine _stateMachine) 
    {
        Debug.Log(this);
        stateMachine = _stateMachine;   
    }
    //Called every frame to update the state
    public virtual void OnUpdate() 
    {
        time += Time.deltaTime;
    }

    public virtual void OnFixedUpdate()
    {
        fixedtime += Time.deltaTime;
    }

    public virtual void OnLateUpdate()
    {
        latetime += Time.deltaTime;
    }

    //Called at the end to clean up any data
    public virtual void OnExit() 
    {
    
    }
    #region Passthrough Methods

    //passthrough to destroy object
    protected static void Destroy(UnityEngine.Object obj)
    {
        UnityEngine.Object.Destroy(obj);
    }

    //returns the component of type T if the gameobject has one attached
    protected T GetComponent<T>() where T : Component { return stateMachine.GetComponent<T>(); }

    //returns componenet of type <paramref name = "/type"/> e.g getComponenet(typeof(Animator)) as Animator
    protected Component GetComponent(System.Type type) { return stateMachine.GetComponent(type); }
    //return component of Type with string  e.g getComponenet("Animatior") as Animator
    protected Component GetComponent(string type) { return stateMachine.GetComponent(type); }
    #endregion
}
