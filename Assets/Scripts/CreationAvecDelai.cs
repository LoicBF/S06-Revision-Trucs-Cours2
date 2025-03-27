using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationAvecDelai : MonoBehaviour
{
    [SerializeField ] private GameObject _objetACreer;
    [SerializeField] private GameObject _objetPlacemenent;
    [SerializeField] private float _onVeutNombreCopie;

    private float _nombreCopie = 0f;

    void Start()
    {
        // �xecute la m�thode CreerObjet apr�s un d�lai de 5s
        //Invoke("CreerObjet", 5f);
        // �xecute la m�thode CreerObjet apr�s un d�lai initiale de 3s et � chaque 1s apr�s
        //InvokeRepeating("CreerObjet", 3f, 0.5f);
        // Cancelle tous les Invoke() actifs
        //CancelInvoke();
    }

    void CreerObjet()
    {

        if ( _nombreCopie == _onVeutNombreCopie)
        {
            CancelInvoke();
            Debug.Log("stop");
        }
        else
        {
            _nombreCopie += 1;
            Debug.Log(_nombreCopie);
        }
        // Instancie un nouveau objet et garde une r�f�rence � lui
        GameObject nouvelleCopie = Instantiate(_objetACreer, _objetPlacemenent.transform.position, _objetPlacemenent.transform.rotation);

        // Prends une r�f�rence a le Rigidbody attach� au nouveau objet
        Rigidbody _rbNouvelleCopie = nouvelleCopie.GetComponent<Rigidbody>();

        // Applique une force de translation initiale al�atoire
        _rbNouvelleCopie.AddRelativeForce(0, 2f + Random.value, 0, ForceMode.Impulse);

        // Applique une force de rotation initiale al�atoire
        _rbNouvelleCopie.AddRelativeTorque(0f, Random.value, Random.value, ForceMode.Impulse);



    }

    public void BtnCreer(){
        _nombreCopie = 1f;
        InvokeRepeating("CreerObjet", 3f, 0.5f);
            
      
        
    }

    public void Nombre5(){
        _onVeutNombreCopie = 5;
    }
    public void Nombre10(){
        _onVeutNombreCopie = 10;
    }
}
