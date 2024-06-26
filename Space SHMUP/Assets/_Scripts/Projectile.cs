using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private BoundsCheck bndCheck;
	private Renderer rend;
	
	[Header("Set Dynamically")]
	public Rigidbody rigid;
	[SerializeField]
	private WeaponType _type;
	
	public WeaponType type{
		get{
			return(_type);
		}
		set{
			SetType(value);
		}
	}
	
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
		rend = GetComponent<Renderer>();
		rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (bndCheck.offUp){
	       Destroy(gameObject);
		}
	}
	
	/// Sets the _type private field and colors this projectile to match the
	/// WeaponDefinition.
	/// </summary>
	/// <param name="eType">The WeaponType to use.</param>
	public void SetType( WeaponType eType ) { // e
	// Set the _type
	_type = eType;
	WeaponDefinition def = Main.GetWeaponDefinition( _type );
	rend.material.color = def.projectileColor;
	}
}
