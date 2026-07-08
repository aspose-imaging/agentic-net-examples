using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.txt";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Password used for the digital signature
                string password = "yourPassword";

                // Fast check if the image is digitally signed
                bool isSigned = image.IsDigitalSigned(password);

                // Analyze confidence percentage if signed
                int confidence = 0;
                if (isSigned)
                {
                    confidence = image.AnalyzePercentageDigitalSignature(password);
                }

                // Prepare result string
                string result = $"Signed: {isSigned}, Confidence: {confidence}%";

                // Write result to output file
                File.WriteAllText(outputPath, result);

                // Also display on console
                Console.WriteLine(result);
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
 * 1. When a financial institution processes scanned checks in JPEG format, it can use this code to verify the embedded digital signature and determine the confidence level before approving the transaction.
 * 2. A legal document management system can employ the snippet to confirm that JPEG evidence photos are digitally signed and assess signature confidence to ensure admissibility in court.
 * 3. In a secure media publishing workflow, developers can run this routine to check that uploaded JPEG images carry a valid digital signature and report the confidence percentage for quality‑control audits.
 * 4. For a forensic analysis tool, the code enables investigators to quickly detect whether a suspect’s JPEG files are signed and gauge the signature’s reliability using the provided password.
 * 5. An enterprise archiving solution can integrate this example to automatically validate the authenticity of archived JPEG assets by reading the digital signature and logging its confidence score.
 */