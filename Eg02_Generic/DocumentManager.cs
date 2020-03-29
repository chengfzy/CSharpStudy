using System;
using System.Collections.Generic;
using System.Xml;

namespace Eg02_Generic
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    public class Document : IDocument
    {
        public Document()
        {
        }

        public Document(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class DocumentManager<TDocument> where TDocument : IDocument
    {
        private readonly Queue<TDocument> _documentQueue = new Queue<TDocument>();

        public void AddDocument(TDocument doc)
        {
            lock (this)
            {
                _documentQueue.Enqueue(doc);
            }
        }

        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);
            lock (this)
            {
                doc = _documentQueue.Dequeue();
            }

            return doc;
        }

        public void DisplayAllDocuments()
        {
            System.Console.WriteLine("All Documents");
            foreach (TDocument doc in _documentQueue)
            {
                System.Console.WriteLine(((IDocument) doc).Title);
            }
        }

        public bool IsDocumentAvailable => _documentQueue.Count > 0;
    }
}