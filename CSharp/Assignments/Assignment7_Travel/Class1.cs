using System;

namespace Assignment7_Travel
{
    public class TravelConcession
    {
        public string CalculateConcession(int age, double total)
        {
            if (age <= 5)
            {
                return "Little Champs-Free Ticket";
            }
            else if (age > 60)
            {
                double discount = total - (total * 0.30);
                return "Senior Citizen-Fare after 30% concession:" + discount;
            }
            else
            {
                return "Ticket Booked-Fare:" + total;
            }
        }
    }
}