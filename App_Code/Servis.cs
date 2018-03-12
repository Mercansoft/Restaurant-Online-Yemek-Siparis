using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

/// <summary>
/// Summary description for Servis
/// </summary>
public class Servis
{
	public Servis()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private System.Timers.Timer threadingTimer;

    public void ServisBaslat()
    {
        //if (null == threadingTimer)
        //{
        //    threadingTimer =
        //    new Timer(new TimerCallback(),
        //        null, 0, 10000);
        //}
    }

    public void ServisDurdur()
    {
        if (null != threadingTimer)
        {
            threadingTimer.Dispose();
        }
    }
}