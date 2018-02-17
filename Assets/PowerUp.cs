
using UnityEngine;
public interface PowerUp {
    Sprite getIcone();
    void setIcone(Sprite newIcone);
    Vector3 powerUpEffect(Vector3 target);
    Vector3 changePlataform();
}