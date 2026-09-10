/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test 1
        // Scenario: Add one customer and serve the customer.
        // Expected Result: The added customer is displayed.
        // Defect(s) Found: ServeCustomer removed the customer before reading it.
        Console.WriteLine("Test 1");
        var cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.ServeCustomer();

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve both customers.
        // Expected Result: Customers display in FIFO order.
        // Defect(s) Found: None.
        Console.WriteLine("Test 2");
        cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {cs}");
        cs.ServeCustomer();
        cs.ServeCustomer();
        Console.WriteLine($"After serving customers: {cs}");

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Serve a customer from an empty queue.
        // Expected Result: An error message is displayed.
        // Defect(s) Found: ServeCustomer attempted to remove an item from an empty queue.
        Console.WriteLine("Test 3");
        cs = new CustomerService(4);
        cs.ServeCustomer();

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add five customers to a queue with maximum size four.
        // Expected Result: The fifth customer is rejected.
        // Defect(s) Found: The full check used > instead of >=.
        Console.WriteLine("Test 4");
        cs = new CustomerService(4);
        cs.AddNewCustomer(); cs.AddNewCustomer(); cs.AddNewCustomer(); cs.AddNewCustomer(); cs.AddNewCustomer();
        Console.WriteLine($"Service Queue: {cs}");

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a queue with an invalid maximum size.
        // Expected Result: The maximum size defaults to 10.
        // Defect(s) Found: None.
        Console.WriteLine("Test 5");
        cs = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {cs}");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in the queue");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
