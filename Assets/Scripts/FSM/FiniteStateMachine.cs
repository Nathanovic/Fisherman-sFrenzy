using UnityEngine;
using System.Collections.Generic;

namespace FishFSM{
	public class FiniteStateMachine {

		private DefaultState defaultState;
		private CaughtState caughtState;
		private EscapedState escapedState;

		public State currentState{get;private set;}

		public FiniteStateMachine (Fish f, FishModel fData){

			defaultState = new DefaultState ();
			defaultState.Init (this, f, fData);
			caughtState = new CaughtState ();
			caughtState.Init (this, f, fData);
			escapedState = new EscapedState ();
			escapedState.Init (this, f, fData);

			fData.onCaught += TransitionToCaught;
			fData.onEscaped += TransitionToEscaped;

			EnterState (defaultState);
		}

		public void EnterState(State nextState){
			if (currentState != null) {
				currentState.Exit ();
			}

			currentState = nextState;
			currentState.Enter ();
		}

		public void RunState(){
			currentState.Run ();
		}

		void TransitionToCaught(){
			EnterState (caughtState);
		}
		void TransitionToEscaped(){
			EnterState (escapedState);
		}
		public void TransitionToDefault(){
			EnterState (defaultState);			
		}
	}
}
