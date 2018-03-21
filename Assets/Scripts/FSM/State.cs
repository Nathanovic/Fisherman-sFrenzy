using UnityEngine;

//state voor vis
namespace FishFSM{
	public abstract class State {

		protected FishModel myData;
		protected FishConfig conf{
			get{ 
				return myData.conf;
			}
		}
		protected Fish fish;
		protected FiniteStateMachine fsm;

		public void Init(FiniteStateMachine _fsm, Fish _fish, FishModel data){
			fsm = _fsm;
			fish = _fish;
			myData = data;
		}

		public abstract void Enter ();
		public virtual void Run(){}
		public abstract Vector3 GetCombinedVector ();
		public abstract void Exit ();
	}

	public class DefaultState : State {

		public override void Enter (){}

		public override Vector3 GetCombinedVector (){
			return fish.Alignment() + fish.Cohesion() + fish.Separation() + fish.GoalSteering() + fish.Wander() + fish.BoundsLimitation();
		}

		public override void Exit (){}
	}

	public class CaughtState : State {

		public override void Enter (){
			fish.CaughtInNet ();
		}

		public override Vector3 GetCombinedVector (){
			return Vector3.zero;
		}

		public override void Exit (){
			
		}
	}

	public class EscapedState : State {

		public override void Enter (){
			fish.EscapeFromNet ();
		}

		public override void Run (){
			if (myData.DistToTarget () < myData.defaultDistToTargetThreshold) {
				fsm.TransitionToDefault ();
			}
		}

		public override Vector3 GetCombinedVector (){
			return fish.Alignment () + fish.Cohesion () + fish.Separation () + fish.GoalSteering () + fish.BoundsLimitation ();
		}

		public override void Exit (){
			
		}
	}
}
