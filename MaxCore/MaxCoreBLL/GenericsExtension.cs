using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace MaxCoreBLL
{
    public static class GenericsExtension
    {
        /// <summary>
        /// (Overload) Extension method to convert a IEnumerable List<T> To a DataSet
        /// </summary>
        /// <typeparam name="T">List type that is being converted<typeparam>
        /// <param name="list">The list itself that is being converted</param>
        /// <param name="name">Name of the DataTable to be added to the DataSet</param>
        /// <returns>A populated DataSet</returns>
        public static DataSet ConvertGenericList<T>(this IEnumerable<T> list, string name)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            DataSet converted = new DataSet(name);
            converted.Tables.Add(newTable(name, list));
            return converted;
        }

        /// <summary>
        /// Extension method to convert a IEnumerable List<T> To a DataSet
        /// </summary>
        /// <typeparam name="T">List type that is being converted</typeparam>
        /// <param name="list">The list itself that is being converted</param>
        /// <returns>A populated DataSet</returns>
        public static DataSet ConvertGenericList<T>(this IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            DataSet converted = new DataSet();
            converted.Tables.Add(newTable(list));
            return converted;
        }

        /// <summary>
        /// (Overload) Method for getting and populating the DataTable that
        /// will be in the converted DataSet
        /// </summary>
        /// <typeparam name="T">List type that is being converted</typeparam>
        /// <param name="name">Name of the DataTable we want</param>
        /// <param name="list">The list being converted</param>
        /// <returns>A populated DataTable</returns>
        private static DataTable newTable<T>(string name, IEnumerable<T> list)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();

            DataTable table = Table<T>(name, list, pi);

            IEnumerator<T> e = list.GetEnumerator();

            while (e.MoveNext())
                table.Rows.Add(newRow<T>(table.NewRow(), e.Current, pi));

            return table;
        }

        /// <summary>
        /// Method for getting and populating the DataTable that
        /// will be in the converted DataSet
        /// </summary>
        /// <typeparam name="T">List type that is being converted</typeparam>
        /// <param name="list">The list being converted</param>
        /// <returns>A populated DataTable</returns>
        private static DataTable newTable<T>(IEnumerable<T> list)
        {
            PropertyInfo[] pi = typeof(T).GetProperties();

            DataTable table = Table<T>(list, pi);

            IEnumerator<T> e = list.GetEnumerator();

            while (e.MoveNext())
                table.Rows.Add(newRow<T>(table.NewRow(), e.Current, pi));

            return table;
        }

        /// <summary>
        /// Method for getting the data from the list then create a new
        /// DataRow with the property values in the PropertyInfo being
        /// provided, then return the row to be added to the Dataable
        /// </summary>
        /// <typeparam name="T">Type of the Generic list being converted</typeparam>
        /// <param name="row">DatRow to populate and add</param>
        /// <param name="listItem">The current item in the list</param>
        /// <param name="pi">Properties for the current item in the list</param>
        /// <returns>A populated DataRow</returns>
        private static DataRow newRow<T>(DataRow row, T listItem, PropertyInfo[] pi)
        {
            foreach (PropertyInfo p in pi)
                row[p.Name.ToString()] = p.GetValue(listItem, null);

            return row;
        }

        /// <summary>
        /// (Overoad) Method resposible for the generation of the DataTable
        /// </summary>
        /// <typeparam name="T">Type of the List being converted</typeparam>
        /// <param name="name">Name for the DataTable</param>
        /// <param name="list">List being converted</param>
        /// <param name="pi">Properties for the list</param>
        /// <returns></returns>
        private static DataTable Table<T>(string name, IEnumerable<T> list, PropertyInfo[] pi)
        {
            DataTable table = new DataTable(name);

            foreach (PropertyInfo p in pi)
                table.Columns.Add(p.Name, p.PropertyType);

            return table;
        }

        /// <summary>
        /// Method resposible for the generation of the DataTable
        /// </summary>
        /// <typeparam name="T">Type of the List being converted</typeparam>
        /// <param name="list">List being converted</param>
        /// <param name="pi">Properties for the list</param>
        /// <returns></returns>
        private static DataTable Table<T>(IEnumerable<T> list, PropertyInfo[] pi)
        {
            DataTable table = new DataTable();

            foreach (PropertyInfo p in pi)
                table.Columns.Add(p.Name, p.PropertyType);

            return table;
        }

        //public DataSet ToDataSet()
        //{
        //    //create a generic list
        //    List<string> list = new List<string>();

        //    //add 2 items to our list (In real world this can and probably
        //    //will be more complex than this simple example
        //    list.Add("Hello");
        //    list.Add("World");

        //    //now create a new DataSet
        //    DataSet converted = list.ConvertGenericList("TestTable");

        //    return converted;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static XmlDocument ConvertDSToXML(DataSet ds)
        {
            XmlDocument xd = new XmlDocument();

            using (MemoryStream ms = new MemoryStream())
            {
                ds.WriteXmlSchema(ms);

                // Reset the position to the start of the stream
                ms.Seek(0, SeekOrigin.Begin);
                xd.Load(ms);
            }

            return xd;
        }


        public static XmlDocument ConvertGenericListToXML<T>(this IEnumerable<T> list)
        {
            XmlDocument xd = new XmlDocument();
            MemoryStream ms = new MemoryStream();

            XmlSerializer xs = new XmlSerializer(typeof(IEnumerable<T>));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, Encoding.UTF8);

            xs.Serialize(xmlTextWriter, list);
            ms = (MemoryStream)xmlTextWriter.BaseStream;
            ms.Position = 0;

            //System.Data.SqlTypes.SqlXml obj = new System.Data.SqlTypes.SqlXml(memoryStream);
            xd.Load(ms);

            return xd;
        }

        public static XmlDocument ConvertListToXML<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlDocument xd = new XmlDocument();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                //return stringWriter.ToString();

                xd.LoadXml(stringWriter.ToString());

                return xd;
            }
        }
    }
}
