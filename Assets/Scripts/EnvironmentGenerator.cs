using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]

public class NewBehaviourScript : MonoBehaviour
{
   
    [SerializeField] private SpriteShapeController _spriteShapeController; 
    [SerializeField, Range(3,200)] private int _levelLength = 200;
    [SerializeField, Range(1f,50f)] private float _xMultiPlayer = 2f;
    [SerializeField, Range(1f,50f)] private float _yMultiPlayer = 2f;
    [SerializeField, Range(0f,1f)] private float _curveSmoothness = 0.5f;
    [SerializeField] private float _noiseStep = 0.7f;
    [SerializeField] private float _bottom = 10f;

    private Vector3 _lastPos; 

    private void OnValidate(){
        _spriteShapeController.spline.Clear();
        for(int i=0; i<_levelLength; i++){
            _lastPos = transform.position + new Vector3(i*_xMultiPlayer, Mathf.PerlinNoise(0,i*_noiseStep)*_yMultiPlayer);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);
            if(i !=0 && i !=_levelLength-1){
                _spriteShapeController.spline.SetTangentMode(i,ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left*_xMultiPlayer*_curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right*_xMultiPlayer*_curveSmoothness);
            }           
        }
        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, transform.position.y - _bottom));
        _spriteShapeController.spline.InsertPointAt(_levelLength+1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }
}
