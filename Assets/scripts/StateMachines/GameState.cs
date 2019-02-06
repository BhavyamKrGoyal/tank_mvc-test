namespace StateMachines
{
    public abstract class GameState
    {
        public States stateName {get ;  protected set; }
        public virtual void Update(){

        } 
        public virtual void OnStateEnter(){
            
        } 
        public virtual void OnStateExit(){
            
        } 
    }
}