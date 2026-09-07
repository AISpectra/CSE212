using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    // Expected Result: Items are returned from highest priority to lowest priority.
    // Defect(s) Found: Dequeue did not inspect the final item and did not remove the returned item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 10);
        priorityQueue.Enqueue("middle", 5);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("middle", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with tied highest priorities and then dequeue from an empty queue.
    // Expected Result: Tied items follow FIFO order; an empty queue throws the required exception.
    // Defect(s) Found: Using >= broke FIFO ordering for tied priorities; the empty-queue behavior was already correct.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 7);
        priorityQueue.Enqueue("second", 7);
        priorityQueue.Enqueue("third", 3);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());

        var exception = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
        });
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    // Add more test cases as needed below.
}
