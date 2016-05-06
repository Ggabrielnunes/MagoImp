using UnityEngine;
using System.Collections;

public class Lista_Magias : MonoBehaviour {
}

public class Spells {
	
	public string name;
	public int type;
	public float carga;
	public float spellCost;
	public float dmg;
	public DmgS Scri;
	public GameObject icon;
	public SIcon icon_Script;   

	public Spells () {
	}
	
	public virtual void Usar() {
	}
	public virtual void parar() {
	}
	public void setCarga(float c) {
		icon_Script.setCargaS (c);
	}
	public float getCarg() {
		return icon_Script.getCargaS ();
	}
}

public class Fireball : Spells {
	
	public GameObject fb;
	
	public Fireball() {
		name = "Fireball";
		type = 1;
		carga = 10.0f;
		spellCost = 1.5f;
		dmg = 100.0f;
		
		icon = (GameObject)GameObject.Instantiate (Resources.Load ("SpellIcons/FireballI"));
		icon_Script = icon.GetComponent<SIcon> ();
		
	}
	
	public override void Usar() {
		fb = (GameObject)GameObject.Instantiate(Resources.Load("Magias/Fireball"));
		fb.gameObject.GetComponent<DmgS> ().damg = dmg;	
	}
}

public class IceShard : Spells {
	GameObject IC;
	
	public IceShard() {
		name = "Ice Shards";
		type = 1;
		carga = 10.0f;
		spellCost = 2.0f;
		dmg = 80.0f;
		
		icon = (GameObject)GameObject.Instantiate (Resources.Load ("SpellIcons/ICI"));
		icon_Script = icon.GetComponent<SIcon> ();
	}
	
	public override void Usar() {
		IC = (GameObject)GameObject.Instantiate(Resources.Load("Magias/IceS"));
		IC.gameObject.GetComponent<DmgS_IC> ().damg = dmg;	
	}
}

public class Spectral : Spells {
	
	public Color c1 = Color.cyan;
	public Color c2 = Color.blue;
	private GameObject lineGO;
	private LineRenderer lineRenderer;


	private int i = 0;
	
	public Spectral() {
		
		name = "SpecBlade";
		type = 0;
		carga = 10.0f;
		spellCost = 50.0f;
		dmg = 100.0f;
	
		icon = (GameObject)GameObject.Instantiate(Resources.Load("SpellIcons/SpecSw"));
		icon_Script = icon.GetComponent<SIcon>();
				
		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineGO.AddComponent<DmgS>();
        
		lineRenderer = lineGO.GetComponent<LineRenderer>();
		lineRenderer.material = new Material (Shader.Find ("Mobile/Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.1f, 0);
		lineRenderer.SetVertexCount(0);		
		
	}
	
	public override void Usar() {
		
		lineRenderer.SetVertexCount (i + 1);
		Vector3 mPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 15);
		lineRenderer.SetPosition (i, Camera.main.ScreenToWorldPoint (mPosition));
		i++;
		
		BoxCollider2D bc = lineGO.AddComponent<BoxCollider2D> ();
		bc.transform.position = lineRenderer.transform.position;
		bc.size = new Vector2 (1f, 1f);	
		lineGO.GetComponent<DmgS> ().damg = dmg;
		
	}
	
	public override void parar() {
		lineRenderer.SetVertexCount(0);
		i = 0;
		
		BoxCollider2D[] lineColliders = lineGO.GetComponents<BoxCollider2D>();
		
		foreach(BoxCollider2D b in lineColliders)
		{
			GameObject.Destroy (b);
		}
	}
}

public class VineWall : Spells
{

    public Color c1 = Color.black;
    public Color c2 = Color.green;
    private GameObject lineGO;
    private LineRenderer lineRenderer;
    private int i = 0;
    float tim;

    public VineWall()
    {

        name = "Nature's Defense";
        type = 0;
        carga = 10.0f;
        spellCost = 7.0f;
        dmg = 0.0f;
        tim = 0.0f;


        icon = (GameObject)GameObject.Instantiate(Resources.Load("SpellIcons/NatDef"));
        icon_Script = icon.GetComponent<SIcon>();

        lineGO = new GameObject("Line");
        lineGO.AddComponent<LineRenderer>();
        lineGO.AddComponent<DmgS>();
        lineRenderer = lineGO.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.3f, 0);
        lineRenderer.SetVertexCount(0);
    }

    public override void Usar()
    {

        lineRenderer.SetVertexCount(i + 1);
        Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
        lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
        i++;

        BoxCollider2D bc = lineGO.AddComponent<BoxCollider2D>();
        bc.transform.position = lineRenderer.transform.position;
        bc.size = new Vector2(1f, 1f);       
    }

    public override void parar()
    {
        if (tim < 3.0f)
        {
           tim += Time.deltaTime;
        } else
        {

            lineRenderer.SetVertexCount(0);
            i = 0;

            BoxCollider2D[] lineColliders = lineGO.GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D b in lineColliders)
            {
                GameObject.Destroy(b);
            }
            tim = 0;
        }       
    }
}

public class Explosion : Spells {
	
	public GameObject exp; 
	
	public Explosion() {
		name = "Explosion";
		type = 1;
		carga = 10.0f;
		spellCost = 5.0f;
		dmg = 200.0f;

		icon = (GameObject)GameObject.Instantiate (Resources.Load ("SpellIcons/ExpI"));
		icon_Script = icon.GetComponent<SIcon> ();

	}
	
	public override void Usar() {
		Vector3 mPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		exp = (GameObject)GameObject.Instantiate(Resources.Load("Magias/Explosion"));
		exp.transform.position = Camera.main.ScreenToWorldPoint (mPosition);
		exp.gameObject.GetComponent<DmgS> ().damg = dmg;
		parar ();
	}
	
	public override void parar() {
		GameObject.Destroy(exp, 1.2f);
	}
}

public class IcePool : Spells {
	
	public GameObject IceP; 
	
	public IcePool() {
		name = "IcePool";
		type = 1;
		carga = 10.0f;
		spellCost = 7.0f;
		dmg = 0.0f;
		
		icon = (GameObject)GameObject.Instantiate (Resources.Load ("SpellIcons/FrozenPoolI"));
		icon_Script = icon.GetComponent<SIcon> ();
		
	}
	
	public override void Usar() {
		Vector3 mPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		IceP = (GameObject)GameObject.Instantiate(Resources.Load("Magias/FrozenPool"));
		IceP.transform.position = Camera.main.ScreenToWorldPoint (mPosition);
		parar ();
	}
	
	public override void parar() {
		GameObject.Destroy(IceP, 5.0f);
	}
}


public class Meteor : Spells {
	public GameObject mt;
	
	public Meteor(){
		name = "Meteor";
		type = 3;
		carga = 10.0f;
		spellCost = 9.0f;
		dmg = 500.0f;

		icon = (GameObject)GameObject.Instantiate (Resources.Load ("SpellIcons/MeteorI"));
		icon_Script = icon.GetComponent<SIcon> ();

	}
	
	public override void Usar() {
		mt = (GameObject)GameObject.Instantiate(Resources.Load("Magias/Meteor"));
	}
}

public class Blizzard : Spells {
	public GameObject bl;
	public Blizzard(){
		name = "Blizzard";
		carga = 10.0f;
		spellCost = 10.0f;
		dmg = 0.0f;
		icon = (GameObject)GameObject.Instantiate (Resources.Load ("SpellIcons/BlizzardI"));
		icon_Script = icon.GetComponent<SIcon> ();
	}
	public override void Usar() {
		Vector3 mPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		bl = (GameObject)GameObject.Instantiate(Resources.Load("Magias/Blizzard"));
		bl.transform.position = Camera.main.ScreenToWorldPoint (mPosition);
		GameObject.Destroy(bl, 5.0f);	
	}
}


