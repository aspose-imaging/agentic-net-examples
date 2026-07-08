using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Multithreading;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.png",
                @"C:\Images\Input2.jpg"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Images\Output\Out1.bmp",
                @"C:\Images\Output\Out2.bmp"
            };

            // Verify each input file exists
            for (int i = 0; i < inputPaths.Length; i++)
            {
                if (!File.Exists(inputPaths[i]))
                {
                    Console.Error.WriteLine($"File not found: {inputPaths[i]}");
                    return;
                }
            }

            // Ensure output directories exist
            for (int i = 0; i < outputPaths.Length; i++)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPaths[i]));
            }

            // Cancellation token source for user‑initiated abort
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                // Task that waits for the user to press 'c' to cancel
                Task.Run(() =>
                {
                    Console.WriteLine("Press 'c' to cancel processing...");
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.KeyChar == 'c' || key.KeyChar == 'C')
                        {
                            cts.Cancel();
                            break;
                        }
                    }
                });

                // Interrupt monitor used by Aspose.Imaging to stop operations
                InterruptMonitor monitor = new InterruptMonitor();

                for (int i = 0; i < inputPaths.Length; i++)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Processing cancelled by user.");
                        break;
                    }

                    // Set thread‑local monitor so Aspose can be interrupted
                    InterruptMonitor.ThreadLocalInstance = monitor;

                    try
                    {
                        using (Image image = Image.Load(inputPaths[i]))
                        {
                            // Example conversion: save as BMP
                            BmpOptions saveOptions = new BmpOptions();
                            image.Save(outputPaths[i], saveOptions);
                        }
                    }
                    catch (Aspose.Imaging.CoreExceptions.OperationInterruptedException)
                    {
                        Console.WriteLine($"Operation interrupted for {inputPaths[i]}");
                    }
                    finally
                    {
                        // Reset the thread‑local monitor
                        InterruptMonitor.ThreadLocalInstance = null;
                    }

                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("Processing cancelled by user.");
                        break;
                    }
                }

                // If cancellation was requested, signal Aspose to interrupt any ongoing work
                if (cts.IsCancellationRequested)
                {
                    monitor.Interrupt();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a desktop image conversion utility that batch‑processes PNG and JPEG files into BMP format with Aspose.Imaging, a developer can let users abort the operation instantly by pressing ‘c’ using a CancellationToken.
 * 2. When implementing a server‑side image‑processing pipeline that applies filters to multiple uploaded photos, a CancellationToken enables graceful termination if the client cancels the request or a timeout occurs.
 * 3. When creating a long‑running photo‑editing batch job that runs in a background thread, the code lets a user interrupt the process from the console without corrupting partially saved BMP outputs.
 * 4. When integrating Aspose.Imaging’s multithreading filter engine into a Windows service that monitors a folder for new images, a CancellationToken allows the service to stop processing when the service is stopped or restarted.
 * 5. When developing an automated testing suite that validates filter performance on a set of sample images, a developer can use the CancellationToken to halt the test run early if a critical failure is detected.
 */