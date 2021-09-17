using System;

public class Live {
    public static void Main() {
        Human me = new Man();
        me.Name = "Ilya";
        me.LastName = "Okunev";
        while(me.IsLive){
            me.SelfImprove();
            if(me.FindJob()){
                me.HardWork();
                me.UpSkills();
                me.MotivationToWork++;
            }
        }
    }
}