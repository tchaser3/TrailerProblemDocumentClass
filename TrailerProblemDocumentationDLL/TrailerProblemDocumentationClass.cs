/* Title:           Trailer Problem Documentation Class
 * Date:            9-26-19
 * Author:          Terry Holmes
 * 
 * Description:     This class is used for trailer documentation */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace TrailerProblemDocumentationDLL
{
    public class TrailerProblemDocumentationClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        TrailerProblemDocumentationDataSet aTrailerProblemDocumentationDataSet;
        TrailerProblemDocumentationDataSetTableAdapters.trailerproblemdocumentationTableAdapter aTrailerProblemDocumentationTableAdapter;

        InsertTrailerProblemDocumentationEntryTableAdapters.QueriesTableAdapter aInsertTrailerProblemDocumentationTableAdapter;

        FindTrailerProblemDocumentsByTrailerIDDataSet aFindTrailerProblemDocumentsByTrailerIDDataSet;
        FindTrailerProblemDocumentsByTrailerIDDataSetTableAdapters.FindTrailerDocumentsByTrailerIDTableAdapter aFindTrailerProblemDocumentsByTrailerIDTableAdapter;

        FindTrailerDocumentsByProblemIDDataSet aFindTrailerDocumentsByProblemIDDataSet;
        FindTrailerDocumentsByProblemIDDataSetTableAdapters.FindTrailerDocumentsByProblemIDTableAdapter aFindTrailerDocumentsByProblemIDTableAdapter;

        public  FindTrailerDocumentsByProblemIDDataSet FindTrailerDocumentsByProblemID(int intProblemID)
        {
            try
            {
                aFindTrailerDocumentsByProblemIDDataSet = new FindTrailerDocumentsByProblemIDDataSet();
                aFindTrailerDocumentsByProblemIDTableAdapter = new FindTrailerDocumentsByProblemIDDataSetTableAdapters.FindTrailerDocumentsByProblemIDTableAdapter();
                aFindTrailerDocumentsByProblemIDTableAdapter.Fill(aFindTrailerDocumentsByProblemIDDataSet.FindTrailerDocumentsByProblemID, intProblemID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Documentation Class // Find Trailer Documents By Problem ID " + Ex.Message);
            }

            return aFindTrailerDocumentsByProblemIDDataSet;
        }
        public FindTrailerProblemDocumentsByTrailerIDDataSet FindTrailerProblemDocumentsByTrailerID(int intTrailerID)
        {
            try
            {
                aFindTrailerProblemDocumentsByTrailerIDDataSet = new FindTrailerProblemDocumentsByTrailerIDDataSet();
                aFindTrailerProblemDocumentsByTrailerIDTableAdapter = new FindTrailerProblemDocumentsByTrailerIDDataSetTableAdapters.FindTrailerDocumentsByTrailerIDTableAdapter();
                aFindTrailerProblemDocumentsByTrailerIDTableAdapter.Fill(aFindTrailerProblemDocumentsByTrailerIDDataSet.FindTrailerDocumentsByTrailerID, intTrailerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Documentation Class // Find Trailer Problem Documents By Trailer ID " + Ex.Message);
            }

            return aFindTrailerProblemDocumentsByTrailerIDDataSet;
        }
        public bool InsertTrailerProblemDocumentation(int intTrailerID, int intProblemID, string strDocumentPath)
        {
            bool blnFatalError = false;

            try
            {
                aInsertTrailerProblemDocumentationTableAdapter = new InsertTrailerProblemDocumentationEntryTableAdapters.QueriesTableAdapter();
                aInsertTrailerProblemDocumentationTableAdapter.InsertTrailerProblemDocumentation(intTrailerID, intProblemID, strDocumentPath);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Documentation Class // Insert Trailer Problem Documentation " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public TrailerProblemDocumentationDataSet GetTrailerProblemDocumentationInfo()
        {
            try
            {
                aTrailerProblemDocumentationDataSet = new TrailerProblemDocumentationDataSet();
                aTrailerProblemDocumentationTableAdapter = new TrailerProblemDocumentationDataSetTableAdapters.trailerproblemdocumentationTableAdapter();
                aTrailerProblemDocumentationTableAdapter.Fill(aTrailerProblemDocumentationDataSet.trailerproblemdocumentation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Documentation Class // Get Trailer Problem Documentation Info " + Ex.Message);
            }

            return aTrailerProblemDocumentationDataSet;
        }
        public void UpdateTrailerProblemDocumentationDB(TrailerProblemDocumentationDataSet aTrailerProblemDocumentationDataSet)
        {
            try
            {
                aTrailerProblemDocumentationTableAdapter = new TrailerProblemDocumentationDataSetTableAdapters.trailerproblemdocumentationTableAdapter();
                aTrailerProblemDocumentationTableAdapter.Update(aTrailerProblemDocumentationDataSet.trailerproblemdocumentation);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Problem Documentation Class // Update Trailer Problem Documentation DB " + Ex.Message);
            }
        }
    }
}
