using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID
{
    public class InterfaceSegregation
    {
        public class Document
        {
            public string Name { get; set; }
            public string Path { get; set; }
        }

        //Avoid the Big one Interface that contain all the functions 
        // alot of atomic Interface per function
        public interface IScannner
        {
            void Scan(Document document);
        }
        public interface IPrinter
        {
            void Print(Document document);
        }
        public interface IMultiFunctionDevice : IScannner, IPrinter
        {
        }
        //decator pattern 
        public class MultiFunctionMachine: IMultiFunctionDevice
        {
            private IPrinter printer;
            private IScannner scanner;
            public MultiFunctionMachine(IPrinter printer , IScannner scanner)
            {
                this.printer = printer;
                this.scanner = scanner; 
            }

            public void Print(Document document)
            {
                printer.Print(document);
            }

            public void Scan(Document document)
            {
                scanner.Scan(document); 
            }
        }
    }
}
