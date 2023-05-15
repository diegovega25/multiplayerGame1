using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : NetworkBehaviour
{
    [SyncVar(hook = nameof(CambiarColor))]
    [SerializeField] private Color color;
    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SetMyColor(Color.red);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SetMyColor(Color.green);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetMyColor(Color.blue);
        }
    }
#region server
    [Server]
    public void SetColorPlayer(Color color)
    {
        this.color = color;
    }

    [Command]
    public void CmdSetColor(Color color)
    {
        SetColorPlayer(color);
    }
#endregion

#region cliente
    public void CambiarColor(Color oldColor, Color newColor)
    {
        GetComponent<Renderer>().material.color = newColor;
    }

   // [ContextMenu("Cambiar el color del jugador")]
    public void SetMyColor(Color color)
    {
        CmdSetColor(color);
    }
#endregion
}
