using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity("Breathing", "Relax through breathing.", 30);
        ListingActivity listing = new ListingActivity("Listing", "List your thoughts.", 45, new List<string>());
        ReflectingActivity reflecting = new ReflectingActivity("Reflecting", "Reflect on your day.", 60, new List<string>(), new List<string>());
    }
}
