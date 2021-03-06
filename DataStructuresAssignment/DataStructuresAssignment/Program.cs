﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int iAnswer = 0;
            do {
                Console.WriteLine("Please enter an integer 1-4.");
                Console.WriteLine("1. Stack\n2. Queue\n3. Dictionary\n4. Exit");
                
                Boolean bException = false;
                while(bException == false) {
                    try {
                        string sAnswer = Console.ReadLine();
                        iAnswer = Convert.ToInt32(sAnswer);
                        bException = true;
                    }
                    catch {
                        Console.WriteLine("Please enter an integer 1-4.");
                        Console.WriteLine("1. Stack\n2. Queue\n3. Dictionary\n4. Exit");
                    }
                }
            } while (iAnswer < 1 || iAnswer > 4);

            switch (iAnswer) {
                case 1:
                    Console.WriteLine("Stack");
                    //Eric Pickard
                    //9/27/16
                    //create stack and instantiate variables
                    Stack<string> myStack = new Stack<string>();
                    int userInput = 0;
                    Boolean bError = false;
                    Boolean bStop = false;

                    //dowhile loop to until user enters 7 to return to main menu
                    do
                    {
                        //stack menu
                        Console.WriteLine("1. Add one item to Stack");
                        Console.WriteLine("2. Add Huge List of Items to Stack");
                        Console.WriteLine("3. Display Stack");
                        Console.WriteLine("4. Delete from Stack");
                        Console.WriteLine("5. Clear Stack");
                        Console.WriteLine("6. Search Stack");
                        Console.WriteLine("7. Return to Main Menu");
                        Console.WriteLine();

                        do
                        {
                            //put error back at false
                            bError = false;

                            //try/catch
                            try
                            {
                                //read input
                                userInput = Convert.ToInt32(Console.ReadLine());

                                //check for anything not 1 through 7
                                if (userInput < 1 || userInput > 7)
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception e)
                            {
                                bError = true;
                                Console.WriteLine("\nPlease enter a positive integer between 1 and 7\n", e);
                            }
                        } while (bError == true);

                        //swtich statement to decided which menu item was selected
                        switch (userInput)
                        {
                            case 1: //add one item
                                //ask user to enter string
                                Console.Write("\nPlease enter a string to be inserted into the stack: ");

                                //enter string into stack
                                myStack.Push(Console.ReadLine());
                                break;
                            case 2: //add huge list of items
                                //clear stack
                                myStack.Clear();

                                //generate 2000 items with value of "New Entry" concatinated with entry number and add to stack
                                for (int iCount = 0; iCount < 2000; iCount++)
                                {
                                    myStack.Push("New Entry " + (iCount + 1));
                                }
                                break;
                            case 3:  //display
                                //reset bError to false
                                try
                                {
                                    //see if there is anything in the stack
                                    if (myStack.Count == 0)
                                    {
                                        throw new Exception();
                                    }

                                    //use foreach loop to display content of stack
                                    foreach (string value in myStack)
                                    {
                                        Console.WriteLine(value);
                                    }
                                }
                                catch
                                {
                                    bError = true;
                                    Console.WriteLine("\nThere is nothing in the stack.  Please insert an item into the stack before displaying contents.");
                                }
                                break;
                            case 4: //delete from
                                do
                                {
                                    //set bError to false
                                    bError = false;

                                    try
                                    {
                                        //see if anything is in the stack to delete
                                        if (myStack.Count() == 0)
                                        {
                                            throw new Exception();
                                        }

                                        //ask what user wants to delete
                                        Console.Write("\nWhat item would you like to delete: ");
                                        string sDelete = Console.ReadLine();

                                        //see if item is in stack
                                        if (myStack.Contains(sDelete))
                                        {
                                            //create bFound for dowhile loop
                                            Boolean bFound = false;

                                            //create tempStack
                                            Stack<string> tempStack = new Stack<string>();

                                            //loop to see if the top of the stack is the item that needs to be deleted
                                            do
                                            {                                            
                                                //check to see if top of stack is item to be deleted
                                                if (myStack.Peek().Equals(sDelete))
                                                {
                                                    bFound = true;
                                                }
                                                else
                                                {
                                                    tempStack.Push(myStack.Pop());
                                                }
                                            } while (bFound == false);

                                            //pop off item user requested to be deleted
                                            myStack.Pop();

                                            //add back items in tempStack to myStack
                                            for (int iCount = 0; iCount < tempStack.Count(); iCount++)
                                            {
                                                myStack.Push(tempStack.Pop());
                                            }

                                            //tell user item was deleted
                                            Console.WriteLine(sDelete + " was deleted from the stack!");
                                        }
                                        else
                                        {
                                            Console.Write("\n" + sDelete + " is not in the stack. Do you want to try a different item: (y/n) ");
                                            string sAnswer = Console.ReadLine();

                                            if (sAnswer.Equals("y"))
                                            {
                                                bError = true;
                                            }
                                            else
                                            {
                                                bError = false;
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\nThere is nothing in the stack to delete");
                                    }

                                } while (bError == true);
                                break;
                            case 5: //clear
                                //clear myStack
                                myStack.Clear();
                                break;
                            case 6: //search
                                //create stopwatch called sw
                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                                //ask what user want to search for
                                Console.Write("What do you want to search for?: ");
                                string sUserInput = Console.ReadLine();

                                //start stopwatch
                                sw.Start();

                                //search myStack
                                Boolean bContains = myStack.Contains(sUserInput);               

                                //stop stopwatch
                                sw.Stop();

                                //return whether or not it was found
                                if (bContains)
                                {
                                    Console.WriteLine("\nThe item was found in the stack.");
                                }
                                else
                                {
                                    Console.WriteLine("\nThe item was not found in the stack.");
                                }

                                //return how long it took to search
                                Console.WriteLine("The search took " + (sw.ElapsedTicks * 100) + " nanoseconds.");

                                break;
                            case 7: //return
                                bStop = true;
                                break;
                        }
                        //add blank line for readabilty when repeating menu
                        Console.WriteLine();
                    } while (bStop == false);
                    
                    break;
                case 2:
                    Console.WriteLine("Queue");
                    break;
                case 3:
                    Console.WriteLine("Dictionary");
                    break;
                case 4:
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Please enter an integer 1-4.");
                    Console.WriteLine("1. Stack\n2. Queue\n3. Dictionary\n4. Exit");
                    break;
            }

            string sEnd = Console.ReadLine();
        }
    }
}
