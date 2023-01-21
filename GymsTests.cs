using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]

        public void CheckIfAthletePropAreOk()
        {
            Athlete athlete = new Athlete("John");

            Assert.AreEqual(athlete.FullName, "John");
            Assert.IsFalse(athlete.IsInjured);

        }

        [Test]

        public void CheckIfGymSetsValues()
        {
            Gym gym = new Gym("John", 10);

            Assert.AreEqual(gym.Name, "John");


            Assert.AreEqual(gym.Capacity, 10);
            Assert.AreEqual(gym.Count, 0);

        }


        [Test]
        public void CheckIfGymNameThrowsError()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Gym("", 10));

        }
        [Test]
        public void CheckIfGymCapacityThrowsError()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Bon", -10));

            Assert.Throws<ArgumentException>(() => new Gym("Bon", -1));

        }
        [Test]

        public void CheckAddsProperly()
        {
            Gym gym = new Gym("John", 1);
            Athlete athlete = new Athlete("John");
            gym.AddAthlete(athlete);
            Assert.AreEqual(gym.Count, 1);
           

        }
        [Test]

        public void CheckCountEqualCapacity()
        {
            Gym gym = new Gym("John", 1);
            Athlete athlete = new Athlete("John");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Marta")));
        }
        [Test]

        public void CheckCantRemovesProperly()
        {
            Gym gym = new Gym("John", 1);
            Athlete athlete = new Athlete("John");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Marta"));

        }
        [Test]

        public void ChecRemovesProperly()
        {
            Gym gym = new Gym("John", 1);
            Athlete athlete1 = new Athlete("John");
            gym.AddAthlete(athlete1);
            gym.RemoveAthlete("John");
            Assert.AreEqual(gym.Count, 0);

        }

        [Test]

        public void ChecThrowsInJuredErrorProperly()
        {
            Gym gym = new Gym("John", 1);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Marta"));

        }
        [Test]

        public void ChecInJuredErrorProperly()
        {
            Gym gym = new Gym("John", 1);
            Athlete athlete1 = new Athlete("John");
            gym.AddAthlete(athlete1);
            gym.InjureAthlete("John");
            
            Assert.AreEqual(gym.InjureAthlete("John"), athlete1);
            

        }
        [Test]

        public void CheckReport()
        {
            Gym gym = new Gym("John", 2);
            Athlete athlete1 = new Athlete("John");
            Athlete athlete2 = new Athlete("Eimy");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.InjureAthlete("John");
            gym.InjureAthlete("Eimy");
            gym.Report();

            
            Assert.AreEqual(gym.Report(), "Active athletes at John: ");

        }
    }
}

