using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public enum Type
    {
        Player
    }
    public interface GameRule
    {
        bool HasPermission(InputHandler inputHandler, Type type);
    }
    static public GameRule gameRule;

    public Type type;

    public interface InputReceiver
    {
        void OnHorizontalAxis(float horizontalAxis);
        void OnVerticalAxis(float verticalAxis);
        void OnJumpButtonDown();
    }
    private HashSet<InputReceiver> inputReceivers;
    private HashSet<InputReceiver> inputReceiverRegisterAwaiters;
    private HashSet<InputReceiver> inputReceiverUnregisterAwaiters;

    private void Awake()
    {
        inputReceivers = new HashSet<InputReceiver>();
        inputReceiverRegisterAwaiters = new HashSet<InputReceiver>();
        inputReceiverUnregisterAwaiters = new HashSet<InputReceiver>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputReceivers.UnionWith(inputReceiverRegisterAwaiters);
        inputReceiverRegisterAwaiters.Clear();
        inputReceivers.ExceptWith(inputReceiverUnregisterAwaiters);
        inputReceiverUnregisterAwaiters.Clear();

        if(gameRule != null && gameRule.HasPermission(this, type))
        {
            foreach(var receiver in inputReceivers)
            {
                receiver.OnHorizontalAxis(Input.GetAxis("Horizontal"));
                receiver.OnVerticalAxis(Input.GetAxis("Vertical"));
                
                if (Input.GetButtonDown("Jump"))
                    receiver.OnJumpButtonDown();
            }
        }
    }

    public void AddInputReceiverRegisterAwaiter(InputReceiver inputReceiver)
    {
        inputReceiverRegisterAwaiters.Add(inputReceiver);
    }

    public void AddInputReceiverUnregisterAwaiter(InputReceiver inputReceiver)
    {
        inputReceiverUnregisterAwaiters.Add(inputReceiver);
    }

}
