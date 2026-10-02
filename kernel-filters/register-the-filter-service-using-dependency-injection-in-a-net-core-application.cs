// HOW-TO: Register Custom Image Filter Service with Dependency Injection in .NET Core (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;

namespace ImagingNet
{
    public interface IFilterService
    {
        void Apply(string inputPath, string outputPath);
    }

    public class FilterService : IFilterService
    {
        public void Apply(string inputPath, string outputPath)
        {
            // Simple example: copy the file (replace with real filter logic)
            File.Copy(inputPath, outputPath, true);
        }
    }

    public class ServiceCollection
    {
        private readonly Dictionary<Type, Func<object>> _services = new Dictionary<Type, Func<object>>();

        public void AddSingleton<TService, TImplementation>()
            where TImplementation : TService, new()
        {
            _services[typeof(TService)] = () => new TImplementation();
        }

        public ServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_services);
        }
    }

    public class ServiceProvider
    {
        private readonly Dictionary<Type, Func<object>> _services;

        public ServiceProvider(Dictionary<Type, Func<object>> services)
        {
            _services = services;
        }

        public T GetService<T>()
        {
            return (T)_services[typeof(T)]();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                var services = new ServiceCollection();
                services.AddSingleton<IFilterService, FilterService>();
                var provider = services.BuildServiceProvider();

                var filterService = provider.GetService<IFilterService>();
                filterService.Apply(inputPath, outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building an ASP.NET Core web API that receives JPEG uploads and needs to apply a custom image filter before storing the files.
 * 2. When creating a background worker that batch‑processes PNG images and you want the filter logic injected for easy configuration and testing.
 * 3. When developing a console utility that copies and transforms TIFF files, using DI to resolve the filter service at runtime.
 * 4. When writing unit tests for an image‑processing pipeline and need to swap the real filter with a mock via the service container.
 * 5. When integrating Aspose.Imaging into a microservice and want to manage different filter implementations through .NET Core’s built‑in dependency injection.
 */
