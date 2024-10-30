using System;

public abstract class User
{
    private int userID;
    private string name;
    private string phoneNumber;


    public User()
    {
        userID += 1;
        name = "No name";
        phoneNumber = "None";
    }
    public void setUserID(int userID)
    {
        this.userID = userID;
    }

    public int getUserID()
    {
        return this.userID;
    }

    public void setname(string name)
        { this.name = name; }
    public string getname()
    { return this.name; }

    public void setphoneNumber(string phoneNumber)
    { this.phoneNumber = phoneNumber; }
    public string getphoneNumber()
    { return this.phoneNumber; }

    public void register()
    {
        
        Console.Write(" Enter your name : ");
        name = Console.ReadLine();

        Console.Write(" Enter your phoneNumber : ");
        phoneNumber = Console.ReadLine();
        
    }

    public void displayProfile()
    {

        Console.WriteLine(" Your name : "+this.getname());

        Console.WriteLine(" Your phoneNumber : "+ this.getphoneNumber());
    }
}

public class Rider : User
{
    List<Trip> rideHistory = new List<Trip>();
    Trip trip = new Trip();
    public Trip requestRide(Trip trip)
    {
        Console.Write(" Enter your current location : ");
        trip.setstartLocation(Console.ReadLine());
        Console.Write(" Enter your destination : ");
        trip.setdestinationn(Console.ReadLine());
        trip.setRiderName(this.getname());
        rideHistory.Add(trip);
        return trip;
    }

    public void viewRideHistory()
    {
        foreach (Trip trip in rideHistory)
        {
            trip.displayTripDetails();
        }
    }
}


public class Driver : User
{
    private int driverID;
    private string vehicleDetails;
    private bool isAvailable;
    List<Trip> triphistory = new List<Trip>();



    public void setdriverID(int driverID)
    {
        this.driverID = driverID;
    }

    public int getdriverIDD()
    {
        return this.driverID;
    }

    public void setvehicleDetails(string vehicleDetails)
    { this.vehicleDetails = vehicleDetails; }
    public string getvehicleDetails()
    { return vehicleDetails; }

    public void setisAvailable(bool isAvailable)
    {
        this.isAvailable = isAvailable;
    }

    public bool getisAvailable()
    {
        return isAvailable;
    }

    public void acceptRide()
    {
        this.isAvailable = false;

    }


}
public class Trip
{
    private int tripID;
    private string RiderName;
    private string driverName;
    private string startLocation;
    private string destination;
    private decimal fare;
    private bool status;

    public Trip()
    {
        tripID++;
        RiderName = "NULL";
    }

    public void settripID(int tripID)
    {
        this.tripID = tripID;
    }

    public int gettripID()
    {
        return this.tripID;
    }

    public void setRiderName(string RiderName)
    { this.RiderName = RiderName; }
    public string getRiderName()
    { return this.RiderName; }

    public void setdriverName(string driverName)
    { this.driverName = driverName; }
    public string getdriverName()
    { return this.driverName; }


    public void setstartLocation(string startLocation)
    { this.startLocation = startLocation; }
    public string getstartLocation()
    { return this.startLocation; }

    public void setdestinationn(string destination)
    { this.destination = destination; }
    public string getdestination()
    { return this.destination; }

    public void setfare(decimal fare)
    { this.fare = fare; }
    public decimal getfare()
    {
        return fare;
    }

    public void setstatus(bool status)
    {
        this.status = status;
    }

    public bool getstatus()
    {
        return status;
    }

    public decimal calculateFare()
    {
        return 25;
    }
    public void startTrip()
    {
        
    }

    public void endTrip()
    {

    }

    public void displayTripDetails()
    {
        Console.WriteLine(" Trip ID  : " + this.gettripID());

        Console.WriteLine(" Rider : " + this.getRiderName());

        Console.WriteLine(" Driver: " + this.getdriverName());

        Console.WriteLine(" From: " + this.getstartLocation());

        Console.WriteLine(" To: " + this.getdestination());

        Console.WriteLine(" Fare: " + this.getfare()+"$");
    }
}


public class RideSharingSystem
{
    public List<Rider> registeredRiders = new List<Rider>();
    public List<Driver> registeredDrivers = new List<Driver>();
    public List<Trip> availableTrips = new List<Trip>();
    Trip trip = new Trip();
    public void registerUserAsDriver(Driver driver)
    {
        registeredDrivers.Add(driver);
        driver.displayProfile();
        Console.WriteLine(" this driver is registed successfully ");
        Console.ReadLine();
    }

    public void registerUserAsRider(Rider rider)
    {
        registeredRiders.Add(rider);
        rider.displayProfile();
        Console.WriteLine(" this rider is registed successfully ");
        Console.ReadLine();
    }
 
    public void findAvaibleDriver()
    {

    }

    public void completeTrip()
    {

    }

    public void displayAllTrips()
    {
        foreach (Trip trip in availableTrips)
        {
            trip.displayTripDetails();
        }
    }

    public void displayrides()
    {
        foreach (Trip trip in availableTrips)
        {
            trip.displayTripDetails();
        }
    }


}

class Program
{
    static void Main(string[] args)
    {
        RideSharingSystem rideSharingSystem = new RideSharingSystem();
        while(true)
        {
            Console.Clear();
            Console.WriteLine(" Welcome to the Ride Sharing System ");
            Console.WriteLine(" 1. Register as Rider");
            Console.WriteLine(" 2. Register as Driver");
            Console.WriteLine(" 3. Request a Ride (Rider)");
            Console.WriteLine(" 4. Accept a Ride (Driver) ");
            Console.WriteLine(" 5. Complete a Trip (Driver) ");
            Console.WriteLine(" 6. View Ride History (Rider) ");
            Console.WriteLine(" 7. Riders and Drivers ");
            Console.WriteLine(" 8. Display all Trips ");
            Console.WriteLine(" 9. Exit ");
            List<Trip> trips = new List<Trip>();
             List<Rider> registeredRiders = new List<Rider>();
           List<Driver> registeredDrivers = new List<Driver>();
            Console.Write(" Choose an option from above :");
            int choice = Convert.ToInt32(Console.ReadLine());
            Rider rider = new Rider();
            Driver driver = new Driver();
            Trip trip = new Trip();

            if (choice == 1)
            {
                
                rider.register();
                registeredRiders.Add(rider);
                rideSharingSystem.registerUserAsRider(rider);

            }
            else if(choice == 2)
            {
               
                driver.register();
                registeredDrivers.Add(driver);
                rideSharingSystem.registerUserAsDriver(driver);
            }
            else if( choice == 3)
            {
                trips.Add(rider.requestRide(trip));
                Console.ReadLine();
            }
            else if (choice == 4)
            {
                Console.WriteLine(rideSharingSystem.registeredDrivers[0].getname()+" acccepted the ride from "+ rideSharingSystem.registeredRiders[0].getname() );
                Console.ReadLine();
            }
            else if (choice == 5)
            {

            }
            else if (choice == 6)
            {

            }
            else if (choice == 7)
            {
                foreach(Rider riderd in registeredRiders)
                {
                    riderd.displayProfile();
                }


                foreach (Driver drivers in registeredDrivers)
                {
                    drivers.displayProfile();
                }

                Console.ReadLine() ;
            }
            else if (choice == 8)
            {
                foreach(Trip tripp in trips)
                {
                    tripp.displayTripDetails();
                }
                Console.ReadLine();
            }
            else if (choice == 9)
            {
                break;
            }
            else
            {
                Console.WriteLine(" Please Enter a valid Choice ");
                Console.ReadLine();
            }



        }
    }
}
