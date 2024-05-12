using MBT;
using System;
using UnityEngine;

[AddComponentMenu("")]
public class AICharacterVariable : Variable<AICharacter>
{
    protected override bool ValueEquals(AICharacter val1, AICharacter val2)
    {
        return val1 == val2;
    }
}

[Serializable]
public class AICharacterReference : VariableReference<AICharacterVariable, AICharacter>
{
    public AICharacterReference(VarRefMode mode = VarRefMode.EnableConstant)
    {
        SetMode(mode);
    }

    public AICharacterReference(AICharacter defaultConstant)
    {
        useConstant = true;
        constantValue = defaultConstant;
    }

    public AICharacter Value
    {
        get
        {
            return (useConstant) ? constantValue : this.GetVariable().Value;
        }
        set
        {
            if (useConstant)
            {
                constantValue = value;
            }
            else
            {
                this.GetVariable().Value = value;
            }
        }
    }
}