using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment_03
{
    internal class Exercise5 : IExercise
    {
        public void Run()
        {
            Queue<string> printQueue = new Queue<string>();

            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            //1.
            foreach(string document in printQueue)
            {
                Console.WriteLine(document);
            }

            Console.WriteLine($"Count: {printQueue.Count}");

            //2.
            Console.WriteLine($"\nNext document: {printQueue.Peek()}");

            //3.
            while (printQueue.Count > 0)
            {
                string document = printQueue.Dequeue();

                Console.WriteLine($"Printing: {document}");
            }

            //4.
            bool success = printQueue.TryDequeue(out string nextDocument);

            Console.WriteLine($"\nTryDequeue succeeded: {success}");
        }
    }
}
