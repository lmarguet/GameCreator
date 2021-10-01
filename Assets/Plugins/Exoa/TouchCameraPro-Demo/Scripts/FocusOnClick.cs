using Exoa.Events;
using Lean.Common;

public class FocusOnClick : LeanSelectableBehaviour
{
    public bool follow;
    public bool focusOnFollow;


    protected override void OnSelected()
    {
        print("OnSelect " + gameObject.name);
        if (follow)
            CameraEvents.OnRequestObjectFollow?.Invoke(gameObject, focusOnFollow);
        else
            CameraEvents.OnRequestObjectFocus?.Invoke(gameObject);
    }

    protected override void OnDeselected()
    {
        print("OnDeselect " + gameObject.name);
        if (follow)
            CameraEvents.OnRequestObjectFollow?.Invoke(null, focusOnFollow);
    }
}
