using System;

public class ShitTest
{
	private float _dermo = 100f;

	public float Dermo
    {
        get
        {
            return _dermo;
        }
        set
        {
            _dermo = value;
        }
    }

    private void zalupa()
    {
        Dermo = 20f;
    }
}
