using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

using JCSoftwares_CM.Models.Generics;
using JCSoftwares_CM.Models.Procurements;
using JCSoftwares_CM.Models.Sales;
using JCSoftwares_CM.Models.Inventorys;
using JCSoftwares_CM.Models.Accountings;
using JCSoftwares_CM.Models.POSs;
using JCSoftwares_CM.Models.Lendings;
using JCSoftwares_CM.Models.HRISs;
//using JCSoftwares_CM.Models.Payrolls;
using JCSoftwares_CM.Models.Systems;

using System.Data;
using System.Net.Http.Headers;
using System.Net.Mail;

namespace JCSoftwares_CM.Controllers
{
    public class MainController : ApiController
    {
        #region "INITIALIZATION"
        //Generics
        Common loCommon = new Common();
        //Procurements
        ProcurementDiscount loProcurementDiscount = new ProcurementDiscount();
        PurchaseRequest loPurchaseRequest = new PurchaseRequest();
        PurchaseRequestDetail loPurchaseRequestDetail = new PurchaseRequestDetail();
        PurchaseOrder loPurchaseOrder = new PurchaseOrder();
        PurchaseOrderDetail loPurchaseOrderDetail = new PurchaseOrderDetail();
        //Sales
        SalesDiscount loSalesDiscount = new SalesDiscount();
        SalesPerson loSalesPerson = new SalesPerson();
        PriceQuotation loPriceQuotation = new PriceQuotation();
        PriceQuotationDetail loPriceQuotationDetail = new PriceQuotationDetail();
        SalesOrder loSalesOrder = new SalesOrder();
        SalesOrderDetail loSalesOrderDetail = new SalesOrderDetail();
        //Inventorys
        Customer loCustomer = new Customer();
        Supplier loSupplier = new Supplier();
        InventoryGroup loInventoryGroup = new InventoryGroup();
        Category loCategory = new Category();
        Stock loStock = new Stock();
        Unit loUnit = new Unit();
        InventoryType loInventoryType = new InventoryType();
        Location loLocation = new Location();
        Inventory loInventory = new Inventory();
        InventoryDetail loInventoryDetail = new InventoryDetail();
        //Accountings
        ChartOfAccount loChartOfAccount = new ChartOfAccount();
        Classification loClassification = new Classification();
        SubClassification loSubClassification = new SubClassification();
        MainAccount loMainAccount = new MainAccount();
        Bank loBank = new Bank();
        Equipment loEquipment = new Equipment();
        Building loBuilding = new Building();
        JournalEntry loJournalEntry = new JournalEntry();
        JournalEntryDetail loJournalEntryDetail = new JournalEntryDetail();
        CashReceiptDetail loCashReceiptDetail = new CashReceiptDetail();
        CheckDetail loCheckDetail = new CheckDetail();
        CashDisbursementDetail loCashDisbursementDetail = new CashDisbursementDetail();
        //POS
        Cashier loCashier = new Cashier();
        ModeOfPayment loModeOfPayment = new ModeOfPayment();
        CashierPeriod loCashierPeriod = new CashierPeriod();
        POSTransaction loPOSTransaction = new POSTransaction();
        POSTransactionDetail loPOSTransactionDetail = new POSTransactionDetail();
        ReturnedItem loReturnedItem = new ReturnedItem();
        
        //Lendings
        Client loClient = new Client();
        ClientFamilyMember loClientFamilyMember = new ClientFamilyMember();
        ClientPersonalReference loClientPersonalReference = new ClientPersonalReference();
        ClientSourceOfIncome loClientSourceOfIncome = new ClientSourceOfIncome();
        ClientOwnedProperty loClientOwnedProperty = new ClientOwnedProperty();
        ClientCreditExperience loClientCreditExperience = new ClientCreditExperience();
        Area loArea = new Area();
        Branch loBranch = new Branch();
        Zone loZone = new Zone();
        Collector loCollector = new Collector();
        Product loProduct = new Product();
        LoanApplication loLoanApplication = new LoanApplication();
        LoanApplicationDetail loLoanApplicationDetail = new LoanApplicationDetail();
        LoanEndOfDay loLoanEndOfDay = new LoanEndOfDay();
        LoanEndOfDayDetail loLoanEndOfDayDetail = new LoanEndOfDayDetail();
        //HRISs
        Employee loEmployee = new Employee();
        EmploymentType loEmploymentType = new EmploymentType();
        Designation loDesignation = new Designation();
        Department loDepartment = new Department();
        LeaveType loLeaveType = new LeaveType();
        Holiday loHoliday = new Holiday();
        EarningType loEarningType = new EarningType();
        DeductionType loDeductionType = new DeductionType();
        TaxType loTaxType = new TaxType();
        IncomeTaxTable loIncomeTaxTable = new IncomeTaxTable();
        WorkSchedule loWorkSchedule = new WorkSchedule();
        //Payrolls

        //Systems
        User loUser = new User();
        UserGroup loUserGroup = new UserGroup();
        SystemConfiguration loSystemConfigurations = new SystemConfiguration();
        AuditTrail loAuditTrail = new AuditTrail();
        #endregion

        #region "GENERICS"
        [HttpGet]
        public string test()
        {
            return "Test Successful!";
        }

        [HttpGet]
        public DataTable getDataFromSearch(string pQueryString)
        {
            return loCommon.getDataFromSearch(pQueryString);
        }

        [HttpGet]
        public DataTable getUserGroupMenuItems(string pUsername)
        {
            return loCommon.getUserGroupMenuItems(pUsername);
        }

        [HttpGet]
        public DataTable getUserGroupRights(string pUsername)
        {
            return loCommon.getUserGroupRights(pUsername);
        }

        [HttpGet]
        public DataTable getMenuItems()
        {
            return loCommon.getMenuItems();
        }

        [HttpGet]
        public DataTable getAllMenuItems()
        {
            return loCommon.getAllMenuItems();
        }

        [HttpGet]
        public DataTable getAllRights(string pItemName)
        {
            return loCommon.getAllRights(pItemName);
        }

        [HttpGet]
        public DataTable getMenuItemsByGroup(string pUserGroupId)
        {
            return loCommon.getMenuItemsByGroup(pUserGroupId);
        }

        [HttpGet]
        public DataTable getEnableRights(string pItemName, string pUserGroupId)
        {
            return loCommon.getEnableRights(pItemName, pUserGroupId);
        }

        [HttpGet]
        public DataTable getEnableCompanys(string pUserGroupId)
        {
            return loCommon.getEnableCompanys(pUserGroupId);
        }

        [HttpGet]
        public bool sendEmail(string pFrom, string pTo, string pCC, string pSubject, string pBody, string pUsername, string pUserPassword)
        {
            return loCommon.sendEmail(pFrom, pTo, pCC, pSubject, pBody, pUsername, pUserPassword);
        }

        [HttpGet]
        public DataTable getTemplateNames(string pMenuName, string pUserId)
        {
            return loCommon.getTemplateNames(pMenuName, pUserId);
        }

        [HttpGet]
        public DataTable getTemplateName(string pId)
        {
            return loCommon.getTemplateName(pId);
        }

        [HttpGet]
        public DataTable getSearchFilters(string pTemplateId)
        {
            return loCommon.getSearchFilters(pTemplateId);
        }

        [HttpGet]
        public string insertSearchTemplate(string pTemplateName, string pItemName, string pPrivate, string pUserId)
        {
            return loCommon.insertSearchTemplate(pTemplateName, pItemName, pPrivate, pUserId);
        }

        [HttpGet]
        public bool removeSearchFilter(string pTemplateId)
        {
            return loCommon.removeSearchFilter(pTemplateId);
        }

        [HttpGet]
        public bool removeSearchTemplate(string pId)
        {
            return loCommon.removeSearchTemplate(pId);
        }

        [HttpGet]
        public bool renameSearchTemplate(string pId, string pTemplateName)
        {
            return loCommon.renameSearchTemplate(pId, pTemplateName);
        }

        [HttpGet]
        public bool updateSearchTemplate(string pId, string pTemplateName, string pItemName, string pPrivate)
        {
            return loCommon.updateSearchTemplate(pId, pTemplateName, pItemName, pPrivate);
        }

        [HttpGet]
        public bool insertSearchFilter(string pTemplateId, string pField, string pOperator, string pValue, string pCheckAnd, string pCheckOr, int pSequence)
        {
            return loCommon.insertSearchFilter(pTemplateId, pField, pOperator, pValue, pCheckAnd, pCheckOr,pSequence);
        }

        [HttpGet]
        public DataTable getViewDetails()
        {
            return loCommon.getViewDetails();
        }

        [HttpGet]
        public DataTable getStoredProcedureDetails(string pDatabaseName)
        {
            return loCommon.getStoredProcedureDetails(pDatabaseName);
        }

        [HttpGet]
        public DataTable getFunctionDetails(string pDatabaseName)
        {
            return loCommon.getFunctionDetails(pDatabaseName);
        }

        [HttpGet]
        public DataTable getTableDetails()
        {
            return loCommon.getTableDetails();
        }

        [HttpGet]
        public DataTable getMenuItemDetails()
        {
            return loCommon.getMenuItemDetails();
        }

        [HttpGet]
        public DataTable getItemRightDetails()
        {
            return loCommon.getItemRightDetails();
        }

        [HttpGet]
        public DataTable getSystemConfigurationDetails()
        {
            return loCommon.getSystemConfigurationDetails();
        }

        [HttpGet]
        public DataTable getNextTabelSequenceId(string pDescription)
        {
            return loCommon.getNextTabelSequenceId(pDescription);
        }
        #endregion "END OF GLOBAL"

        #region "PROCUREMENTS"
        #region "Procurement Discount"
        [HttpGet]
        public DataTable getProcurementDiscounts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loProcurementDiscount.getProcurementDiscounts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertProcurementDiscount([FromBody]ProcurementDiscount pProcurementDiscount)
        {
            return loProcurementDiscount.insertProcurementDiscount(pProcurementDiscount);
        }

        [HttpPost]
        public string updateProcurementDiscount([FromBody]ProcurementDiscount pProcurementDiscount)
        {
            return loProcurementDiscount.updateProcurementDiscount(pProcurementDiscount);
        }

        [HttpGet]
        public bool removeProcurementDiscount(string pId, string pUserId)
        {
            return loProcurementDiscount.removeProcurementDiscount(pId, pUserId);
        }
        #endregion

        #region "Purchase Request"
        [HttpGet]
        public DataTable getPurchaseRequests(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loPurchaseRequest.getPurchaseRequests(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getPurchaseRequestBySupplier(string pSupplierId, string pSearchString)
        {
            return loPurchaseRequest.getPurchaseRequestBySupplier(pSupplierId, pSearchString);
        }

        [HttpGet]
        public DataTable getPurchaseRequestStatus(string pId)
        {
            return loPurchaseRequest.getPurchaseRequestStatus(pId);
        }

        [HttpGet]
        public DataTable getNextPurchaseRequestId()
        {
            return loPurchaseRequest.getNextPurchaseRequestId();
        }

        [HttpPost]
        public string insertPurchaseRequest([FromBody]PurchaseRequest pPurchaseRequest)
        {
            return loPurchaseRequest.insertPurchaseRequest(pPurchaseRequest);
        }

        [HttpPost]
        public string updatePurchaseRequest([FromBody]PurchaseRequest pPurchaseRequest)
        {
            return loPurchaseRequest.updatePurchaseRequest(pPurchaseRequest);
        }

        [HttpGet]
        public bool removePurchaseRequest(string pId, string pUserId)
        {
            return loPurchaseRequest.removePurchaseRequest(pId, pUserId);
        }

        [HttpGet]
        public bool approvePurchaseRequest(string pId, string pUserId)
        {
            return loPurchaseRequest.approvePurchaseRequest(pId, pUserId);
        }

        [HttpGet]
        public bool cancelPurchaseRequest(string pId, string pCancelledReason, string pUserId)
        {
            return loPurchaseRequest.cancelPurchaseRequest(pId, pCancelledReason, pUserId);
        }
        #endregion ""

        #region "Purchase Request Detail"
        [HttpGet]
        public DataTable getPurchaseRequestDetails(string pDisplayType, string pId)
        {
            return loPurchaseRequestDetail.getPurchaseRequestDetails(pDisplayType, pId);
        }

        [HttpGet]
        public DataTable getStockPurchaseRequest(string pLocationId)
        {
            return loPurchaseRequestDetail.getStockPurchaseRequest(pLocationId);
        }

        [HttpGet]
        public DataTable getStockPurchaseRequestList(string pLocationId, string pSearchString)
        {
            return loPurchaseRequestDetail.getStockPurchaseRequestList(pLocationId, pSearchString);
        }
   
        [HttpPost]
        public bool insertPurchaseRequestDetail([FromBody]PurchaseRequestDetail pPurchaseRequestDetail)
        {
            return loPurchaseRequestDetail.insertPurchaseRequestDetail(pPurchaseRequestDetail);
        }

        [HttpPost]
        public bool updatePurchaseRequestDetail([FromBody]PurchaseRequestDetail pPurchaseRequestDetail)
        {
            return loPurchaseRequestDetail.updatePurchaseRequestDetail(pPurchaseRequestDetail);
        }

        [HttpGet]
        public bool removePurchaseRequestDetail(string pDetailId, string pUserId)
        {
            return loPurchaseRequestDetail.removePurchaseRequestDetail(pDetailId, pUserId);
        }
        #endregion ""

        #region "Purchase Order"
        [HttpGet]
        public DataTable getPurchaseOrders(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loPurchaseOrder.getPurchaseOrders(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getPurchaseOrderBySupplier(string pSupplierId, string pSearchString)
        {
            return loPurchaseOrder.getPurchaseOrderBySupplier(pSupplierId, pSearchString);
        }

        [HttpGet]
        public DataTable getCashDisbursementPOBySupplier(string pSupplierId, string pSearchString)
        {
            return loPurchaseOrder.getCashDisbursementPOBySupplier(pSupplierId, pSearchString);
        }

        [HttpGet]
        public DataTable getAccountPayables()
        {
            return loPurchaseOrder.getAccountPayables();
        }

        [HttpGet]
        public DataTable getAccountPayablesOverdue()
        {
            return loPurchaseOrder.getAccountPayablesOverdue();
        }

        [HttpGet]
        public DataTable getPurchaseOrderStatus(string pId)
        {
            return loPurchaseOrder.getPurchaseOrderStatus(pId);
        }

        [HttpPost]
        public string insertPurchaseOrder([FromBody]PurchaseOrder pPurchaseOrder)
        {
            return loPurchaseOrder.insertPurchaseOrder(pPurchaseOrder);
        }

        [HttpPost]
        public string updatePurchaseOrder([FromBody]PurchaseOrder pPurchaseOrder)
        {
            return loPurchaseOrder.updatePurchaseOrder(pPurchaseOrder);
        }

        [HttpGet]
        public bool removePurchaseOrder(string pId, string pUserId)
        {
            return loPurchaseOrder.removePurchaseOrder(pId, pUserId);
        }

        [HttpGet]
        public bool finalizePurchaseOrder(string pId, string pUserId)
        {
            return loPurchaseOrder.finalizePurchaseOrder(pId, pUserId);
        }

        [HttpGet]
        public bool cancelPurchaseOrder(string pId, string pCancelledReason, string pUserId)
        {
            return loPurchaseOrder.cancelPurchaseOrder(pId, pCancelledReason, pUserId);
        }

        [HttpGet]
        public bool postPurchaseOrder(string pId, string pUserId)
        {
            return loPurchaseOrder.postPurchaseOrder(pId, pUserId);
        }

        [HttpGet]
        public bool updatePORunningBalance(string pId, decimal pRunningBalance, string pUserId)
        {
            return loPurchaseOrder.updatePORunningBalance(pId, pRunningBalance, pUserId);
        }

        [HttpGet]
        public bool updatePOTotalAmount(string pId, decimal pTotalQtyIn, decimal pTotalVariance, decimal pTotalAmount, string pUserId)
        {
            return loPurchaseOrder.updatePOTotalAmount(pId, pTotalQtyIn, pTotalVariance, pTotalAmount, pUserId);
        }
        #endregion ""

        #region "Purchase Order Detail"
        [HttpGet]
        public DataTable getPurchaseOrderDetails(string pDisplayType, string pId)
        {
            return loPurchaseOrderDetail.getPurchaseOrderDetails(pDisplayType,pId);
        }

        [HttpGet]
        public DataTable getPurchaseOrderDetail(string pId)
        {
            return loPurchaseOrderDetail.getPurchaseOrderDetail(pId);
        }

        [HttpGet]
        public DataTable getPurchaseInventory(DateTime pStartDate, DateTime pEndDate)
        {
            return loPurchaseOrderDetail.getPurchaseInventory(pStartDate, pEndDate);
        }

        [HttpGet]
        public DataTable getPurchaseInventoryBy(DateTime pStartDate, DateTime pEndDate)
        {
            return loPurchaseOrderDetail.getPurchaseInventoryBy(pStartDate, pEndDate);
        }

        [HttpGet]
        public DataTable getStockPurchaseOrder(string pLocationId)
        {
            return loPurchaseOrderDetail.getStockPurchaseOrder(pLocationId);
        }

        [HttpGet]
        public DataTable getStockPurchaseOrderList(string pLocationId, string pSearchString)
        {
            return loPurchaseOrderDetail.getStockPurchaseOrderList(pLocationId, pSearchString);
        }

        [HttpPost]
        public bool insertPurchaseOrderDetail([FromBody]PurchaseOrderDetail pPurchaseOrderDetail)
        {
            return loPurchaseOrderDetail.insertPurchaseOrderDetail(pPurchaseOrderDetail);
        }

        [HttpPost]
        public bool updatePurchaseOrderDetail([FromBody]PurchaseOrderDetail pPurchaseOrderDetail)
        {
            return loPurchaseOrderDetail.updatePurchaseOrderDetail(pPurchaseOrderDetail);
        }

        [HttpGet]
        public bool removePurchaseOrderDetail(string pDetailId, string pUserId)
        {
            return loPurchaseOrderDetail.removePurchaseOrderDetail(pDetailId, pUserId);
        }

        [HttpGet]
        public bool updateQtyInPurchaseOrderDetail(string pDetailId, decimal pQtyIn, decimal pVariance)
        {
            return loPurchaseOrderDetail.updateQtyInPurchaseOrderDetail(pDetailId, pQtyIn, pVariance);
        }

        [HttpGet]
        public bool updateTotalPricePurchaseOrderDetail(string pDetailId, decimal pTotalPrice)
        {
            return loPurchaseOrderDetail.updateTotalPricePurchaseOrderDetail(pDetailId, pTotalPrice);
        }
        #endregion ""
        #endregion

        #region "SALES"
        #region "Sales Discount"
        [HttpGet]
        public DataTable getSalesDiscounts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loSalesDiscount.getSalesDiscounts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertSalesDiscount([FromBody]SalesDiscount pSalesDiscount)
        {
            return loSalesDiscount.insertSalesDiscount(pSalesDiscount);
        }

        [HttpPost]
        public string updateSalesDiscount([FromBody]SalesDiscount pSalesDiscount)
        {
            return loSalesDiscount.updateSalesDiscount(pSalesDiscount);
        }

        [HttpGet]
        public bool removeSalesDiscount(string pId, string pUserId)
        {
            return loSalesDiscount.removeSalesDiscount(pId, pUserId);
        }
        #endregion

        #region "Sales Person"
        [HttpGet]
        public DataTable getSalesPersons(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loSalesPerson.getSalesPersons(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getSalesPersonNames()
        {
            return loSalesPerson.getSalesPersonNames();
        }

        [HttpPost]
        public string insertSalesPerson([FromBody]SalesPerson pSalesPerson)
        {
            return loSalesPerson.insertSalesPerson(pSalesPerson);
        }

        [HttpPost]
        public string updateSalesPerson([FromBody]SalesPerson pSalesPerson)
        {
            return loSalesPerson.updateSalesPerson(pSalesPerson);
        }

        [HttpGet]
        public bool removeSalesPerson(string pId, string pUserId)
        {
            return loSalesPerson.removeSalesPerson(pId, pUserId);
        }
        #endregion ""

        #region "Price Quotation"
        [HttpGet]
        public DataTable getPriceQuotations(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loPriceQuotation.getPriceQuotations(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getPriceQuotationByCustomer(string pCustomerId, string pSearchString)
        {
            return loPriceQuotation.getPriceQuotationByCustomer(pCustomerId, pSearchString);
        }

        [HttpGet]
        public DataTable getPriceQuotationStatus(string pId)
        {
            return loPriceQuotation.getPriceQuotationStatus(pId);
        }

        [HttpGet]
        public DataTable getNextPriceQuotationId()
        {
            return loPriceQuotation.getNextPriceQuotationId();
        }

        [HttpPost]
        public string insertPriceQuotation([FromBody]PriceQuotation pPriceQuotation)
        {
            return loPriceQuotation.insertPriceQuotation(pPriceQuotation);
        }

        [HttpPost]
        public string updatePriceQuotation([FromBody]PriceQuotation pPriceQuotation)
        {
            return loPriceQuotation.updatePriceQuotation(pPriceQuotation);
        }

        [HttpGet]
        public bool removePriceQuotation(string pId, string pUserId)
        {
            return loPriceQuotation.removePriceQuotation(pId, pUserId);
        }

        [HttpGet]
        public bool approvePriceQuotation(string pId, string pUserId)
        {
            return loPriceQuotation.approvePriceQuotation(pId, pUserId);
        }

        [HttpGet]
        public bool cancelPriceQuotation(string pId, string pCancelledReason, string pUserId)
        {
            return loPriceQuotation.cancelPriceQuotation(pId, pCancelledReason, pUserId);
        }
        #endregion ""

        #region "Price Quoation Detail"
        [HttpGet]
        public DataTable getPriceQuotationDetails(string pDisplayType, string pId)
        {
            return loPriceQuotationDetail.getPriceQuotationDetails(pDisplayType, pId);
        }

        [HttpGet]
        public DataTable getStockPriceQuotation(string pLocationId)
        {
            return loPriceQuotationDetail.getStockPriceQuotation(pLocationId);
        }

        [HttpGet]
        public DataTable getStockPriceQuotationList(string pLocationId, string pSearchString)
        {
            return loPriceQuotationDetail.getStockPriceQuotationList(pLocationId, pSearchString);
        }

        [HttpPost]
        public bool insertPriceQuotationDetail([FromBody]PriceQuotationDetail pPriceQuotationDetail)
        {
            return loPriceQuotationDetail.insertPriceQuotationDetail(pPriceQuotationDetail);
        }

        [HttpPost]
        public bool updatePriceQuotationDetail([FromBody]PriceQuotationDetail pPriceQuotationDetail)
        {
            return loPriceQuotationDetail.updatePriceQuotationDetail(pPriceQuotationDetail);
        }

        [HttpGet]
        public bool removePriceQuotationDetail(string pDetailId, string pUserId)
        {
            return loPriceQuotationDetail.removePriceQuotationDetail(pDetailId, pUserId);
        }
        #endregion ""

        #region "Sales Order"
        [HttpGet]
        public DataTable getSalesOrders(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loSalesOrder.getSalesOrders(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getSalesOrderByCustomer(string pCustomerId, string pSearchString)
        {
            return loSalesOrder.getSalesOrderByCustomer(pCustomerId, pSearchString);
        }

        [HttpGet]
        public DataTable getCashReceiptSOByCustomer(string pCustomerId, string pSearchString)
        {
            return loSalesOrder.getCashReceiptSOByCustomer(pCustomerId, pSearchString);
        }

        [HttpGet]
        public DataTable getAccountReceivables()
        {
            return loSalesOrder.getAccountReceivables();
        }

        [HttpGet]
        public DataTable getAccountReceivablesOverdue()
        {
            return loSalesOrder.getAccountReceivablesOverdue();
        }

        [HttpGet]
        public DataTable getStatementOfAccount(string pCustomerId)
        {
            return loSalesOrder.getStatementOfAccount(pCustomerId);
        }

        [HttpGet]
        public DataTable getSalesOrderStatus(string pId)
        {
            return loSalesOrder.getSalesOrderStatus(pId);
        }

        [HttpGet]
        public DataTable getTotalRunningBalance(string pCustomerId)
        {
            return loSalesOrder.getTotalRunningBalance(pCustomerId);
        }

        [HttpPost]
        public string insertSalesOrder([FromBody]SalesOrder pSalesOrder)
        {
            return loSalesOrder.insertSalesOrder(pSalesOrder);
        }

        [HttpPost]
        public string updateSalesOrder([FromBody]SalesOrder pSalesOrder)
        {
            return loSalesOrder.updateSalesOrder(pSalesOrder);
        }

        [HttpGet]
        public bool removeSalesOrder(string pId, string pUserId)
        {
            return loSalesOrder.removeSalesOrder(pId, pUserId);
        }

        [HttpGet]
        public bool finalizeSalesOrder(string pId, string pUserId)
        {
            return loSalesOrder.finalizeSalesOrder(pId, pUserId);
        }

        [HttpGet]
        public bool cancelSalesOrder(string pId, string pCancelledReason, string pUserId)
        {
            return loSalesOrder.cancelSalesOrder(pId, pCancelledReason, pUserId);
        }

        [HttpGet]
        public bool postSalesOrder(string pId, string pUserId)
        {
            return loSalesOrder.postSalesOrder(pId, pUserId);
        }

        [HttpGet]
        public bool updateSORunningBalance(string pId, decimal pRunningBalance, string pUserId)
        {
            return loSalesOrder.updateSORunningBalance(pId, pRunningBalance, pUserId);
        }

        [HttpGet]
        public bool updateSOTotalAmount(string pId, decimal pTotalQtyOut, decimal pTotalVariance, decimal pTotalAmount, string pUserId)
        {
            return loSalesOrder.updateSOTotalAmount(pId, pTotalQtyOut, pTotalVariance, pTotalAmount, pUserId);
        }
        #endregion ""

        #region "Sales Order Detail"
        [HttpGet]
        public DataTable getSalesOrderDetails(string pDisplayType, string pId)
        {
            return loSalesOrderDetail.getSalesOrderDetails(pDisplayType, pId);
        }

        [HttpGet]
        public DataTable getSalesOrderDetail(string pId)
        {
            return loSalesOrderDetail.getSalesOrderDetail(pId);
        }

        [HttpGet]
        public DataTable getStockSalesOrder(string pLocationId)
        {
            return loSalesOrderDetail.getStockSalesOrder(pLocationId);
        }

        [HttpGet]
        public DataTable getStockSalesOrderList(string pLocationId, string pSearchString)
        {
            return loSalesOrderDetail.getStockSalesOrderList(pLocationId, pSearchString);
        }

        [HttpPost]
        public bool insertSalesOrderDetail([FromBody]SalesOrderDetail pSalesOrderDetail)
        {
            return loSalesOrderDetail.insertSalesOrderDetail(pSalesOrderDetail);
        }

        [HttpPost]
        public bool updateSalesOrderDetail([FromBody]SalesOrderDetail pSalesOrderDetail)
        {
            return loSalesOrderDetail.updateSalesOrderDetail(pSalesOrderDetail);
        }

        [HttpGet]
        public bool removeSalesOrderDetail(string pDetailId, string pUserId)
        {
            return loSalesOrderDetail.removeSalesOrderDetail(pDetailId, pUserId);
        }

        [HttpGet]
        public bool updateQtyOutSalesOrderDetail(string pDetailId, decimal pQtyOut, decimal pVariance)
        {
            return loSalesOrderDetail.updateQtyOutSalesOrderDetail(pDetailId, pQtyOut, pVariance);
        }

        [HttpGet]
        public bool updateTotalPriceSalesOrderDetail(string pDetailId, decimal pTotalPrice)
        {
            return loSalesOrderDetail.updateTotalPriceSalesOrderDetail(pDetailId, pTotalPrice);
        }
        #endregion ""
        #endregion

        #region "INVENTORYS"
        #region "Customer"
        [HttpGet]
        public DataTable getCustomers(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCustomer.getCustomers(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getCustomerDefault()
        {
            return loCustomer.getCustomerDefault();
        }

        [HttpGet]
        public DataTable getCustomerCreditLimit(string pCustomerId)
        {
            return loCustomer.getCustomerCreditLimit(pCustomerId);
        }

        [HttpPost]
        public string insertCustomer([FromBody]Customer pCustomer)
        {
            return loCustomer.insertCustomer(pCustomer);
        }

        [HttpPost]
        public string updateCustomer([FromBody]Customer pCustomer)
        {
            return loCustomer.updateCustomer(pCustomer);
        }

        [HttpGet]
        public bool removeCustomer(string pId, string pUserId)
        {
            return loCustomer.removeCustomer(pId, pUserId);
        }
        #endregion ""

        #region "Supplier"
        [HttpGet]
        public DataTable getSuppliers(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loSupplier.getSuppliers(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertSupplier([FromBody]Supplier pSupplier)
        {
            return loSupplier.insertSupplier(pSupplier);
        }

        [HttpPost]
        public string updateSupplier([FromBody]Supplier pSupplier)
        {
            return loSupplier.updateSupplier(pSupplier);
        }

        [HttpGet]
        public bool removeSupplier(string pId, string pUserId)
        {
            return loSupplier.removeSupplier(pId, pUserId);
        }
        #endregion ""

        #region "Inventory Group"
        [HttpGet]
        public DataTable getInventoryGroups(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loInventoryGroup.getInventoryGroups(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertInventoryGroup([FromBody]InventoryGroup pInventoryGroup)
        {
            return loInventoryGroup.insertInventoryGroup(pInventoryGroup);
        }

        [HttpPost]
        public string updateInventoryGroup([FromBody]InventoryGroup pInventoryGroup)
        {
            return loInventoryGroup.updateInventoryGroup(pInventoryGroup);
        }

        [HttpGet]
        public bool removeInventoryGroup(string pId, string pUserId)
        {
            return loInventoryGroup.removeInventoryGroup(pId, pUserId);
        }
        #endregion ""

        #region "Category"
        [HttpGet]
        public DataTable getCategorys(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCategory.getCategorys(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertCategory([FromBody]Category pCategory)
        {
            return loCategory.insertCategory(pCategory);
        }

        [HttpPost]
        public string updateCategory([FromBody]Category pCategory)
        {
            return loCategory.updateCategory(pCategory);
        }

        [HttpGet]
        public bool removeCategory(string pId, string pUserId)
        {
            return loCategory.removeCategory(pId, pUserId);
        }
        #endregion ""

        #region "Stock"
        [HttpGet]
        public DataTable getStocks(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loStock.getStocks(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getStocksByCode(string pCode)
        {
            return loStock.getStocksByCode(pCode);
        }

        [HttpGet]
        public DataTable getSaleableStocks()
        {
            return loStock.getSaleableStocks();
        }

        [HttpGet]
        public DataTable getSaleableStock(string pCode, string pDescription)
        {
            return loStock.getSaleableStock(pCode, pDescription);
        }

        [HttpGet]
        public DataTable getStockCard(DateTime pFromDate, DateTime pToDate, string pStockId, string pLocationId)
        {
            return loStock.getStockCard(pFromDate, pToDate, pStockId, pLocationId);
        }

        [HttpGet]
        public DataTable getStockCardBegBal(DateTime pFromDate, string pStockId, string pLocationIld)
        {
            return loStock.getStockCardBegBal(pFromDate, pStockId, pLocationIld);
        }

        [HttpGet]
        public DataTable getStockQtyOnHand(string pLocationId, string pStockId)
        {
            return loStock.getStockQtyOnHand(pLocationId, pStockId);
        }

        [HttpGet]
        public DataTable getReorderLevel()
        {
            return loStock.getReorderLevel();
        }

        [HttpPost]
        public string insertStock([FromBody]Stock pStock)
        {
            return loStock.insertStock(pStock);
        }

        [HttpPost]
        public string updateStock([FromBody]Stock pStock)
        {
            return loStock.updateStock(pStock);
        }

        [HttpGet]
        public bool removeStock(string pId, string pUserId)
        {
            return loStock.removeStock(pId, pUserId);
        }
        #endregion ""

        #region "Unit"
        [HttpGet]
        public DataTable getUnits(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUnit.getUnits(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertUnit([FromBody]Unit pUnit)
        {
            return loUnit.insertUnit(pUnit);
        }

        [HttpPost]
        public string updateUnit([FromBody]Unit pUnit)
        {
            return loUnit.updateUnit(pUnit);
        }

        [HttpGet]
        public bool removeUnit(string pId, string pUserId)
        {
            return loUnit.removeUnit(pId, pUserId);
        }
        #endregion ""

        #region "Inventory Type"
        [HttpGet]
        public DataTable getInventoryTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loInventoryType.getInventoryTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertInventoryType([FromBody]InventoryType pInventoryType)
        {
            return loInventoryType.insertInventoryType(pInventoryType);
        }

        [HttpPost]
        public string updateInventoryType([FromBody]InventoryType pInventoryType)
        {
            return loInventoryType.updateInventoryType(pInventoryType);
        }

        [HttpGet]
        public bool removeInventoryType(string pId, string pUserId)
        {
            return loInventoryType.removeInventoryType(pId, pUserId);
        }
        #endregion ""

        #region "Location"
        [HttpGet]
        public DataTable getLocations(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLocation.getLocations(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertLocation([FromBody]Location pLocation)
        {
            return loLocation.insertLocation(pLocation);
        }

        [HttpPost]
        public string updateLocation([FromBody]Location pLocation)
        {
            return loLocation.updateLocation(pLocation);
        }

        [HttpGet]
        public bool removeLocation(string pId, string pUserId)
        {
            return loLocation.removeLocation(pId, pUserId);
        }
        #endregion ""

        #region "Inventory"
        [HttpGet]
        public DataTable getInventorys(string pType, string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loInventory.getInventorys(pType, pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getNextInventoryId()
        {
            return loInventory.getNextInventoryId();
        }

        [HttpGet]
        public DataTable getInventoryStatus(string pId)
        {
            return loInventory.getInventoryStatus(pId);
        }

        [HttpGet]
        public DataTable getStockTransferOut(string pToLocationId, string pSearchString)
        {
            return loInventory.getStockTransferOut(pToLocationId, pSearchString);
        }

        [HttpPost]
        public string insertInventory([FromBody]Inventory pInventory)
        {
            return loInventory.insertInventory(pInventory);
        }

        [HttpPost]
        public string updateInventory([FromBody]Inventory pInventory)
        {
            return loInventory.updateInventory(pInventory);
        }

        [HttpGet]
        public bool removeInventory(string pId, string pUserId)
        {
            return loInventory.removeInventory(pId, pUserId);
        }

        [HttpGet]
        public bool finalInventory(string pId, string pUserId)
        {
            return loInventory.finalInventory(pId, pUserId);
        }

        [HttpGet]
        public bool cancelInventory(string pId, string pCancelledReason, string pUserId)
        {
            return loInventory.cancelInventory(pId, pCancelledReason, pUserId);
        }
        #endregion ""

        #region "Inventory Detail"
        [HttpGet]
        public DataTable getInventoryDetails(string pDisplayType, string pId)
        {
            return loInventoryDetail.getInventoryDetails(pDisplayType, pId);
        }

        [HttpGet]
        public DataTable getStockInventory(string pSearchString)
        {
            return loInventoryDetail.getStockInventory(pSearchString);
        }

        [HttpGet]
        public DataTable getStockInventoryByLocation(string pLocationId, string pSearchString)
        {
            return loInventoryDetail.getStockInventoryByLocation(pLocationId, pSearchString);
        }

        [HttpGet]
        public DataTable getStockInventoryList(string pLocationId, string pSearchString)
        {
            return loInventoryDetail.getStockInventoryList(pLocationId, pSearchString);
        }

        [HttpPost]
        public bool insertInventoryDetail([FromBody]InventoryDetail pInventoryDetail)
        {
            return loInventoryDetail.insertInventoryDetail(pInventoryDetail);
        }

        [HttpPost]
        public bool updateInventoryDetail([FromBody]InventoryDetail pInventoryDetail)
        {
            return loInventoryDetail.updateInventoryDetail(pInventoryDetail);
        }

        [HttpGet]
        public bool removeInventoryDetail(string pDetailId, string pUserId)
        {
            return loInventoryDetail.removeInventoryDetail(pDetailId, pUserId);
        }
        #endregion ""
        #endregion

        #region "ACCOUNTINGS"
        #region "Chart of Account"
        [HttpGet]
        public DataTable getChartOfAccounts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loChartOfAccount.getChartOfAccounts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertChartOfAccount([FromBody]ChartOfAccount pChartOfAccount)
        {
            return loChartOfAccount.insertChartOfAccount(pChartOfAccount);
        }

        [HttpPost]
        public string updateChartOfAccount([FromBody]ChartOfAccount pChartOfAccount)
        {
            return loChartOfAccount.updateChartOfAccount(pChartOfAccount);
        }

        [HttpGet]
        public bool removeChartOfAccount(string pId, string pUserId)
        {
            return loChartOfAccount.removeChartOfAccount(pId, pUserId);
        }
        #endregion ""

        #region "Classification"
        [HttpGet]
        public DataTable getClassifications(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loClassification.getClassifications(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertClassification([FromBody]Classification pClassification)
        {
            return loClassification.insertClassification(pClassification);
        }

        [HttpPost]
        public string updateClassification([FromBody]Classification pClassification)
        {
            return loClassification.updateClassification(pClassification);
        }

        [HttpGet]
        public bool removeClassification(string pId, string pUserId)
        {
            return loClassification.removeClassification(pId, pUserId);
        }
        #endregion ""

        #region "Sub Classification"
        [HttpGet]
        public DataTable getSubClassifications(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loSubClassification.getSubClassifications(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertSubClassification([FromBody]SubClassification pSubClassification)
        {
            return loSubClassification.insertSubClassification(pSubClassification);
        }

        [HttpPost]
        public string updateSubClassification([FromBody]SubClassification pSubClassification)
        {
            return loSubClassification.updateSubClassification(pSubClassification);
        }

        [HttpGet]
        public bool removeSubClassification(string pId, string pUserId)
        {
            return loSubClassification.removeSubClassification(pId, pUserId);
        }
        #endregion ""

        #region "Main Account"
        [HttpGet]
        public DataTable getMainAccounts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loMainAccount.getMainAccounts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertMainAccount([FromBody]MainAccount pMainAccount)
        {
            return loMainAccount.insertMainAccount(pMainAccount);
        }

        [HttpPost]
        public string updateMainAccount([FromBody]MainAccount pMainAccount)
        {
            return loMainAccount.updateMainAccount(pMainAccount);
        }

        [HttpGet]
        public bool removeMainAccount(string pId, string pUserId)
        {
            return loMainAccount.removeMainAccount(pId, pUserId);
        }
        #endregion ""

        #region "Bank"
        [HttpGet]
        public DataTable getBanks(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loBank.getBanks(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertBank([FromBody]Bank pBank)
        {
            return loBank.insertBank(pBank);
        }

        [HttpPost]
        public string updateBank([FromBody]Bank pBank)
        {
            return loBank.updateBank(pBank);
        }

        [HttpGet]
        public bool removeBank(string pId, string pUserId)
        {
            return loBank.removeBank(pId, pUserId);
        }
        #endregion ""

        #region "Equipment"
        [HttpGet]
        public DataTable getEquipments(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEquipment.getEquipments(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertEquipment([FromBody]Equipment pEquipment)
        {
            return loEquipment.insertEquipment(pEquipment);
        }

        [HttpPost]
        public string updateEquipment([FromBody]Equipment pEquipment)
        {
            return loEquipment.updateEquipment(pEquipment);
        }

        [HttpGet]
        public bool removeEquipment(string pId, string pUserId)
        {
            return loEquipment.removeEquipment(pId, pUserId);
        }
        #endregion ""

        #region "Building"
        [HttpGet]
        public DataTable getBuildings(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loBuilding.getBuildings(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertBuilding([FromBody]Building pBuilding)
        {
            return loBuilding.insertBuilding(pBuilding);
        }

        [HttpPost]
        public string updateBuilding([FromBody]Building pBuilding)
        {
            return loBuilding.updateBuilding(pBuilding);
        }

        [HttpGet]
        public bool removeBuilding(string pId, string pUserId)
        {
            return loBuilding.removeBuilding(pId, pUserId);
        }
        #endregion ""

        #region "Journal Entry"
        [HttpGet]
        public DataTable getJournalEntrys(string pJournal, string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loJournalEntry.getJournalEntrys(pJournal, pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getJournalEntryStatus(string pJournalEntryId)
        {
            return loJournalEntry.getJournalEntryStatus(pJournalEntryId);
        }

        [HttpGet]
        public DataTable getJournalEntryBySOId(string pSOId)
        {
            return loJournalEntry.getJournalEntryBySOId(pSOId);
        }

        [HttpGet]
        public DataTable getJournalEntryByPOId(string pPOId)
        {
            return loJournalEntry.getJournalEntryByPOId(pPOId);
        }

        [HttpGet]
        public DataTable getJournalEntryReport(int pFinancialYear)
        {
            return loJournalEntry.getJournalEntryReport(pFinancialYear);
        }

        [HttpPost]
        public string insertJournalEntry([FromBody]JournalEntry pJournalEntry)
        {
            return loJournalEntry.insertJournalEntry(pJournalEntry);
        }

        [HttpPost]
        public string updateJournalEntry([FromBody]JournalEntry pJournalEntry)
        {
            return loJournalEntry.updateJournalEntry(pJournalEntry);
        }

        [HttpGet]
        public bool removeJournalEntry(string pJournalEntryId, string pUserId)
        {
            return loJournalEntry.removeJournalEntry(pJournalEntryId, pUserId);
        }

        [HttpGet]
        public bool postJournalEntry(string pJournalEntryId, string pUserId)
        {
            return loJournalEntry.postJournalEntry(pJournalEntryId, pUserId);
        }

        [HttpGet]
        public bool cancelJournalEntry(string pJournalEntryId, string pCancelledReason, string pUserId)
        {
            return loJournalEntry.cancelJournalEntry(pJournalEntryId, pCancelledReason, pUserId);
        }
        #endregion ""

        #region "Journal Entry Detail"
        [HttpGet]
        public DataTable getJournalEntryDetails(string pDisplayType, string pId)
        {
            return loJournalEntryDetail.getJournalEntryDetails(pDisplayType, pId);
        }

        #region "REPORT"
        [HttpGet]
        public DataTable getGeneralLedgerAccounts(int pFinancialYear)
        {
            return loJournalEntryDetail.getGeneralLedgerAccounts(pFinancialYear);
        }

        [HttpGet]
        public DataTable getGeneralLedgerDetails(string pAccountId, int pFinancialYear)
        {
            return loJournalEntryDetail.getGeneralLedgerDetails(pAccountId, pFinancialYear);
        }

        [HttpGet]
        public DataTable getGeneralLedgerDetailsByDate(string pAccountId, int pFinancialYear, DateTime pDate)
        {
            return loJournalEntryDetail.getGeneralLedgerDetailsByDate(pAccountId, pFinancialYear, pDate);
        }

        [HttpGet]
        public DataTable getSubsidiaryLedgerAccounts(int pFinancialYear)
        {
            return loJournalEntryDetail.getSubsidiaryLedgerAccounts(pFinancialYear);
        }

        [HttpGet]
        public DataTable getSubsidiaries(string pAccountId, string pSubsidiary, int pFinancialYear)
        {
            return loJournalEntryDetail.getSubsidiaries(pAccountId, pSubsidiary, pFinancialYear);
        }

        [HttpGet]
        public DataTable getSubsidiaryLedgerDetails(string pAccountId, string pSubsidiaryId, string pSubsidiary, int pFinancialYear)
        {
            return loJournalEntryDetail.getSubsidiaryLedgerDetails(pAccountId, pSubsidiaryId, pSubsidiary, pFinancialYear);
        }

        [HttpGet]
        public DataTable getSubsidiaryLedgerDetailsByDate(string pAccountId, string pSubsidiaryId, string pSubsidiary, int pFinancialYear, DateTime pDate)
        {
            return loJournalEntryDetail.getSubsidiaryLedgerDetailsByDate(pAccountId, pSubsidiaryId, pSubsidiary, pFinancialYear, pDate);
        }

        [HttpGet]
        public DataTable getTrialBalance(int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getTrialBalance(pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetAccounts(int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetAccounts(pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetBeginningBalance(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetBeginningBalance(pAccountCode, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetTrialBalance(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetTrialBalance(pAccountCode, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetAdjustment(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetAdjustment(pAccountCode, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetBalanceSheet(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetBalanceSheet(pAccountCode, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetIncomeStatement(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetIncomeStatement(pAccountCode, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getWorkSheetClosingEntry(string pAccountCode, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getWorkSheetClosingEntry(pAccountCode, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getBalanceSheetClassifications(string pClassification, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getBalanceSheetClassifications(pClassification, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getAccountBeginningBalance(int pFinancialYear, string pAccountCode)
        {
            return loJournalEntryDetail.getAccountBeginningBalance(pFinancialYear, pAccountCode);
        }

        [HttpGet]
        public DataTable getBalanceSheetSubClassifications(string pClassification, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getBalanceSheetSubClassifications(pClassification, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getBalanceSheetMainAccounts(string pSubClassification, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getBalanceSheetMainAccounts(pSubClassification, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getBalanceSheetMainAccountsForRetainedEarnings(string pSubClassification, int pFinancialYear, string pAsOf)
        {
            return loJournalEntryDetail.getBalanceSheetMainAccountsForRetainedEarnings(pSubClassification, pFinancialYear, pAsOf);
        }

        [HttpGet]
        public DataTable getCOABeginningBalance(int pFinancialYear, string pAccountCode, string pAsOf)
        {
            return loJournalEntryDetail.getCOABeginningBalance(pFinancialYear, pAccountCode, pAsOf);
        }
        #endregion

        [HttpGet]
        public DataTable getIncomeStatementForClosingEntry(int pFinancialYear, string pClassification)
        {
            return loJournalEntryDetail.getIncomeStatementForClosingEntry(pFinancialYear, pClassification);
        }

        [HttpGet]
        public DataTable getBalanceForwardedAccounts(int pFinancialYear)
        {
            return loJournalEntryDetail.getBalanceForwardedAccounts(pFinancialYear);
        }

        [HttpPost]
        public bool insertJournalEntryDetail([FromBody]JournalEntryDetail pJournalEntryDetail)
        {
            return loJournalEntryDetail.insertJournalEntryDetail(pJournalEntryDetail);
        }

        [HttpPost]
        public bool updateJournalEntryDetail([FromBody]JournalEntryDetail pJournalEntryDetail)
        {
            return loJournalEntryDetail.updateJournalEntryDetail(pJournalEntryDetail);
        }

        [HttpGet]
        public bool removeJournalEntryDetail(string pDetailId, string pUserId)
        {
            return loJournalEntryDetail.removeJournalEntryDetail(pDetailId, pUserId);
        }
        #endregion ""

        #region "Cash Receipt Detail"
        [HttpGet]
        public DataTable getCashReceiptDetails(string pJournalEntryId)
        {
            return loCashReceiptDetail.getCashReceiptDetails(pJournalEntryId);
        }

        [HttpPost]
        public bool insertCashReceiptDetail([FromBody]CashReceiptDetail pCashReceiptDetail)
        {
            return loCashReceiptDetail.insertCashReceiptDetail(pCashReceiptDetail);
        }

        [HttpPost]
        public bool updateCashReceiptDetail([FromBody]CashReceiptDetail pCashReceiptDetail)
        {
            return loCashReceiptDetail.updateCashReceiptDetail(pCashReceiptDetail);
        }

        [HttpGet]
        public bool removeCashReceiptDetail(string pDetailId, string pUserId)
        {
            return loCashReceiptDetail.removeCashReceiptDetail(pDetailId, pUserId);
        }
        #endregion ""

        #region "Cash Disbursement Detail"
        [HttpGet]
        public DataTable getCashDisbursementDetails(string pJournalEntryId)
        {
            return loCashDisbursementDetail.getCashDisbursementDetails(pJournalEntryId);
        }

        [HttpGet]
        public DataTable getCashDisbursementDetailsForEdit(string pJournalEntryId)
        {
            return loCashDisbursementDetail.getCashDisbursementDetailsForEdit(pJournalEntryId);
        }

        [HttpPost]
        public bool insertCashDisbursementDetail([FromBody]CashDisbursementDetail pCashDisbursementDetail)
        {
            return loCashDisbursementDetail.insertCashDisbursementDetail(pCashDisbursementDetail);
        }

        [HttpPost]
        public bool updateCashDisbursementDetail([FromBody]CashDisbursementDetail pCashDisbursementDetail)
        {
            return loCashDisbursementDetail.updateCashDisbursementDetail(pCashDisbursementDetail);
        }

        [HttpGet]
        public bool removeCashDisbursementDetail(string pDetailId, string pUserId)
        {
            return loCashDisbursementDetail.removeCashDisbursementDetail(pDetailId, pUserId);
        }
        #endregion ""

        #region "Check Detail"
        [HttpGet]
        public DataTable getCheckDetails(string pJournalEntryId)
        {
            return loCheckDetail.getCheckDetails(pJournalEntryId);
        }

        [HttpGet]
        public DataTable getCheckDetail(string pDetailId)
        {
            return loCheckDetail.getCheckDetail(pDetailId);
        }

        [HttpGet]
        public DataTable getCheckDetailsForEdit(string pJournalEntryId)
        {
            return loCheckDetail.getCheckDetailsForEdit(pJournalEntryId);
        }

        [HttpGet]
        public DataTable getCheckIssuance(DateTime pStartDate, DateTime pEndDate)
        {
            return loCheckDetail.getCheckIssuance(pStartDate, pEndDate);
        }

        [HttpPost]
        public bool insertCheckDetail([FromBody]CheckDetail pCheckDetail)
        {
            return loCheckDetail.insertCheckDetail(pCheckDetail);
        }

        [HttpPost]
        public bool updateCheckDetail([FromBody]CheckDetail pCheckDetail)
        {
            return loCheckDetail.updateCheckDetail(pCheckDetail);
        }

        [HttpGet]
        public bool removeCheckDetail(string pDetailId, string pUserId)
        {
            return loCheckDetail.removeCheckDetail(pDetailId, pUserId);
        }
        #endregion ""
        #endregion

        #region "POS"
        #region "Cashier"
        [HttpGet]
        public DataTable getCashiers(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCashier.getCashiers(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getCashierDetails(string pUserId)
        {
            return loCashier.getCashierDetails(pUserId);
        }

        [HttpPost]
        public string insertCashier([FromBody]Cashier pCashier)
        {
            return loCashier.insertCashier(pCashier);
        }

        [HttpPost]
        public string updateCashier([FromBody]Cashier pCashier)
        {
            return loCashier.updateCashier(pCashier);
        }

        [HttpGet]
        public bool removeCashier(string pId, string pUserId)
        {
            return loCashier.removeCashier(pId, pUserId);
        }
        #endregion ""

        #region "Mode of Payment"
        [HttpGet]
        public DataTable getModeOfPayments(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loModeOfPayment.getModeOfPayments(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getModeOfPaymentDefault()
        {
            return loModeOfPayment.getModeOfPaymentDefault();
        }

        [HttpPost]
        public string insertModeOfPayment([FromBody]ModeOfPayment pModeOfPayment)
        {
            return loModeOfPayment.insertModeOfPayment(pModeOfPayment);
        }

        [HttpPost]
        public string updateModeOfPayment([FromBody]ModeOfPayment pModeOfPayment)
        {
            return loModeOfPayment.updateModeOfPayment(pModeOfPayment);
        }

        [HttpGet]
        public bool removeModeOfPayment(string pId, string pUserId)
        {
            return loModeOfPayment.removeModeOfPayment(pId, pUserId);
        }
        #endregion ""

        #region "Cashier Period"
        [HttpGet]
        public DataTable getCashierPeriods(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCashierPeriod.getCashierPeriods(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getCashierPeriodOpen()
        {
            return loCashierPeriod.getCashierPeriodOpen();
        }

        [HttpGet]
        public DataTable getCashierPeriodStockSold(string pCashierPeriodId)
        {
            return loCashierPeriod.getCashierPeriodStockSold(pCashierPeriodId);
        }

        [HttpGet]
        public DataTable getCashierPeriodReturnedItem(string pCashierPeriodId)
        {
            return loCashierPeriod.getCashierPeriodReturnedItem(pCashierPeriodId);
        }

        [HttpGet]
        public DataTable getCashierPeriodByDate(DateTime pStartDate, DateTime pEndDate)
        {
            return loCashierPeriod.getCashierPeriodByDate(pStartDate, pEndDate);
        }

        [HttpPost]
        public string insertCashierPeriod([FromBody]CashierPeriod pCashierPeriod)
        {
            return loCashierPeriod.insertCashierPeriod(pCashierPeriod);
        }

        [HttpPost]
        public string updateCashierPeriod([FromBody]CashierPeriod pCashierPeriod)
        {
            return loCashierPeriod.updateCashierPeriod(pCashierPeriod);
        }

        [HttpGet]
        public bool openCashierPeriod(string pCashierId, decimal pCashDeposit, string pRemarks, string pUserId)
        {
            return loCashierPeriod.openCashierPeriod(pCashierId, pCashDeposit, pRemarks, pUserId);
        }

        [HttpGet]
        public bool closeCashierPeriod(string pId, string pCashierId, decimal pTotalSales, decimal pReturnedItemTotal,
            decimal pTotalDiscount, decimal pNetSales, decimal pNonCashSales,
            decimal pCashSales, decimal pNetCashSales, decimal pCashCount, decimal pVariance,
            string pRemarks, string pUserId)
        {
            return loCashierPeriod.closeCashierPeriod(pId, pCashierId, pTotalSales, pReturnedItemTotal,
                pTotalDiscount, pNetSales, pNonCashSales,
                pCashSales, pNetCashSales, pCashCount, pVariance, pRemarks, pUserId);
        }

        [HttpGet]
        public bool removeCashierPeriod(string pId, string pUserId)
        {
            return loCashierPeriod.removeCashierPeriod(pId, pUserId);
        }
        #endregion ""

        #region "POS Transaction"
        [HttpGet]
        public DataTable getPOSTransactions(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loPOSTransaction.getPOSTransactions(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getPOSTransactionsByDate(DateTime pStartDate, DateTime pEndDate)
        {
            return loPOSTransaction.getPOSTransactionsByDate(pStartDate, pEndDate);
        }

        [HttpGet]
        public DataTable getPOSTransaction(string pId)
        {
            return loPOSTransaction.getPOSTransaction(pId);
        }

        [HttpGet]
        public DataTable getPOSTransactionLists(string pCashierPeriodId)
        {
            return loPOSTransaction.getPOSTransactionLists(pCashierPeriodId);
        }

        [HttpGet]
        public DataTable getTotalSalesByCashierPeriod(string pCashierPeriodId)
        {
            return loPOSTransaction.getTotalSalesByCashierPeriod(pCashierPeriodId);
        }

        [HttpGet]
        public DataTable getTotalReturnedByCashierPeriod(string pCashierPeriodId)
        {
            return loPOSTransaction.getTotalReturnedByCashierPeriod(pCashierPeriodId);
        }

        [HttpGet]
        public DataTable getTotalDiscountByCashierPeriod(string pCashierPeriodId)
        {
            return loPOSTransaction.getTotalDiscountByCashierPeriod(pCashierPeriodId);
        }

        [HttpGet]
        public DataTable getSalesByCashierPeriod(string pCashierPeriodId)
        {
            return loPOSTransaction.getSalesByCashierPeriod(pCashierPeriodId);
        }

        [HttpPost]
        public string insertPOSTransaction([FromBody]POSTransaction pPOSTransaction)
        {
            return loPOSTransaction.insertPOSTransaction(pPOSTransaction);
        }

        [HttpPost]
        public string updatePOSTransaction([FromBody]POSTransaction pPOSTransaction)
        {
            return loPOSTransaction.updatePOSTransaction(pPOSTransaction);
        }

        [HttpGet]
        public bool removePOSTransaction(string pId, string pUserId)
        {
            return loPOSTransaction.removePOSTransaction(pId, pUserId);
        }
        #endregion ""

        #region "POS Transaction Detail"
        [HttpGet]
        public DataTable getPOSTransactionDetails(string pTransactionId)
        {
            return loPOSTransactionDetail.getPOSTransactionDetails(pTransactionId);
        }

        [HttpGet]
        public DataTable getPOSTransactionDetailsForEdit(string pTransactionId)
        {
            return loPOSTransactionDetail.getPOSTransactionDetailsForEdit(pTransactionId);
        }

        [HttpGet]
        public DataTable getSalesInventory(DateTime pStartDate, DateTime pEndDate)
        {
            return loPOSTransactionDetail.getSalesInventory(pStartDate, pEndDate);
        }

        [HttpGet]
        public DataTable getSalesInventoryBy(DateTime pStartDate, DateTime pEndDate)
        {
            return loPOSTransactionDetail.getSalesInventoryBy(pStartDate, pEndDate);
        }

        [HttpGet]
        public DataTable getReturnedItems(DateTime pStartDate, DateTime pEndDate)
        {
            return loPOSTransactionDetail.getReturnedItems(pStartDate, pEndDate);
        }

        [HttpPost]
        public bool insertPOSTransactionDetail([FromBody]POSTransactionDetail pPOSTransactionDetail)
        {
            return loPOSTransactionDetail.insertPOSTransactionDetail(pPOSTransactionDetail);
        }

        [HttpPost]
        public bool updatePOSTransactionDetail([FromBody]POSTransactionDetail pPOSTransactionDetail)
        {
            return loPOSTransactionDetail.updatePOSTransactionDetail(pPOSTransactionDetail);
        }

        [HttpGet]
        public bool removePOSTransactionDetail(string pDetailId, string pUserId)
        {
            return loPOSTransactionDetail.removePOSTransactionDetail(pDetailId, pUserId);
        }
        #endregion ""

        #region "Returned Item"
        /*
        [HttpGet]
        public DataTable getReturnedItems(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loReturnedItem.getReturnedItems(pDisplayType,pPrimaryKey, pSearchString);
        }
        */
        [HttpPost]
        public string insertReturnedItem([FromBody]ReturnedItem pReturnedItem)
        {
            return loReturnedItem.insertReturnedItem(pReturnedItem);
        }

        [HttpPost]
        public string updateReturnedItem([FromBody]ReturnedItem pReturnedItem)
        {
            return loReturnedItem.updateReturnedItem(pReturnedItem);
        }

        [HttpGet]
        public bool removeReturnedItem(string pId, string pUserId)
        {
            return loReturnedItem.removeReturnedItem(pId, pUserId);
        }
        #endregion ""
        #endregion

        #region "LENDINGS"
        #region "Client"
        [HttpGet]
        public DataTable getClients(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loClient.getClients(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getClientLists()
        {
            return loClient.getClientLists();
        }

        [HttpPost]
        public string insertClient([FromBody]Client pClient)
        {
            return loClient.insertClient(pClient);
        }

        [HttpPost]
        public string updateClient([FromBody]Client pClient)
        {
            return loClient.updateClient(pClient);
        }

        [HttpGet]
        public bool removeClient(string pId, string pUserId)
        {
            return loClient.removeClient(pId, pUserId);
        }
        #endregion

        #region "Client Family Member"
        [HttpGet]
        public DataTable getClientFamilyMembers(string pClientId, string pPrimaryKey)
        {
            return loClientFamilyMember.getClientFamilyMembers(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientFamilyMember([FromBody]ClientFamilyMember pClientFamilyMember)
        {
            return loClientFamilyMember.insertClientFamilyMember(pClientFamilyMember);
        }

        [HttpPost]
        public string updateClientFamilyMember([FromBody]ClientFamilyMember pClientFamilyMember)
        {
            return loClientFamilyMember.updateClientFamilyMember(pClientFamilyMember);
        }

        [HttpGet]
        public bool removeClientFamilyMember(string pId, string pUserId)
        {
            return loClientFamilyMember.removeClientFamilyMember(pId, pUserId);
        }
        #endregion

        #region "Client Personal Reference"
        [HttpGet]
        public DataTable getClientPersonalReferences(string pClientId, string pPrimaryKey)
        {
            return loClientPersonalReference.getClientPersonalReferences(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientPersonalReference([FromBody]ClientPersonalReference pClientPersonalReference)
        {
            return loClientPersonalReference.insertClientPersonalReference(pClientPersonalReference);
        }

        [HttpPost]
        public string updateClientPersonalReference([FromBody]ClientPersonalReference pClientPersonalReference)
        {
            return loClientPersonalReference.updateClientPersonalReference(pClientPersonalReference);
        }

        [HttpGet]
        public bool removeClientPersonalReference(string pId, string pUserId)
        {
            return loClientPersonalReference.removeClientPersonalReference(pId, pUserId);
        }
        #endregion

        #region "Client Source Of Income"
        [HttpGet]
        public DataTable getClientSourceOfIncomes(string pClientId, string pPrimaryKey)
        {
            return loClientSourceOfIncome.getClientSourceOfIncomes(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientSourceOfIncome([FromBody]ClientSourceOfIncome pClientSourceOfIncome)
        {
            return loClientSourceOfIncome.insertClientSourceOfIncome(pClientSourceOfIncome);
        }

        [HttpPost]
        public string updateClientSourceOfIncome([FromBody]ClientSourceOfIncome pClientSourceOfIncome)
        {
            return loClientSourceOfIncome.updateClientSourceOfIncome(pClientSourceOfIncome);
        }

        [HttpGet]
        public bool removeClientSourceOfIncome(string pId, string pUserId)
        {
            return loClientSourceOfIncome.removeClientSourceOfIncome(pId, pUserId);
        }
        #endregion

        #region "Client Owned Property"
        [HttpGet]
        public DataTable getClientOwnedPropertys(string pClientId, string pPrimaryKey)
        {
            return loClientOwnedProperty.getClientOwnedPropertys(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientOwnedProperty([FromBody]ClientOwnedProperty pClientOwnedProperty)
        {
            return loClientOwnedProperty.insertClientOwnedProperty(pClientOwnedProperty);
        }

        [HttpPost]
        public string updateClientOwnedProperty([FromBody]ClientOwnedProperty pClientOwnedProperty)
        {
            return loClientOwnedProperty.updateClientOwnedProperty(pClientOwnedProperty);
        }

        [HttpGet]
        public bool removeClientOwnedProperty(string pId, string pUserId)
        {
            return loClientOwnedProperty.removeClientOwnedProperty(pId, pUserId);
        }
        #endregion

        #region "Client Credit Experience"
        [HttpGet]
        public DataTable getClientCreditExperiences(string pClientId, string pPrimaryKey)
        {
            return loClientCreditExperience.getClientCreditExperiences(pClientId, pPrimaryKey);
        }

        [HttpPost]
        public string insertClientCreditExperience([FromBody]ClientCreditExperience pClientCreditExperience)
        {
            return loClientCreditExperience.insertClientCreditExperience(pClientCreditExperience);
        }

        [HttpPost]
        public string updateClientCreditExperience([FromBody]ClientCreditExperience pClientCreditExperience)
        {
            return loClientCreditExperience.updateClientCreditExperience(pClientCreditExperience);
        }

        [HttpGet]
        public bool removeClientCreditExperience(string pId, string pUserId)
        {
            return loClientCreditExperience.removeClientCreditExperience(pId, pUserId);
        }
        #endregion

        #region "Area"
        [HttpGet]
        public DataTable getAreas(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loArea.getAreas(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertArea([FromBody]Area pArea)
        {
            return loArea.insertArea(pArea);
        }

        [HttpPost]
        public string updateArea([FromBody]Area pArea)
        {
            return loArea.updateArea(pArea);
        }

        [HttpGet]
        public bool removeArea(string pId, string pUserId)
        {
            return loArea.removeArea(pId, pUserId);
        }
        #endregion ""

        #region "Branch"
        [HttpGet]
        public DataTable getBranchs(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loBranch.getBranchs(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertBranch([FromBody]Branch pBranch)
        {
            return loBranch.insertBranch(pBranch);
        }

        [HttpPost]
        public string updateBranch([FromBody]Branch pBranch)
        {
            return loBranch.updateBranch(pBranch);
        }

        [HttpGet]
        public bool removeBranch(string pId, string pUserId)
        {
            return loBranch.removeBranch(pId, pUserId);
        }
        #endregion ""

        #region "Zone"
        [HttpGet]
        public DataTable getZones(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loZone.getZones(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertZone([FromBody]Zone pZone)
        {
            return loZone.insertZone(pZone);
        }

        [HttpPost]
        public string updateZone([FromBody]Zone pZone)
        {
            return loZone.updateZone(pZone);
        }

        [HttpGet]
        public bool removeZone(string pId, string pUserId)
        {
            return loZone.removeZone(pId, pUserId);
        }
        #endregion ""

        #region "Collector"
        [HttpGet]
        public DataTable getCollectors(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loCollector.getCollectors(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertCollector([FromBody]Collector pCollector)
        {
            return loCollector.insertCollector(pCollector);
        }

        [HttpPost]
        public string updateCollector([FromBody]Collector pCollector)
        {
            return loCollector.updateCollector(pCollector);
        }

        [HttpGet]
        public bool removeCollector(string pId, string pUserId)
        {
            return loCollector.removeCollector(pId, pUserId);
        }
        #endregion ""

        #region "Product"
        [HttpGet]
        public DataTable getProducts(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loProduct.getProducts(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertProduct([FromBody]Product pProduct)
        {
            return loProduct.insertProduct(pProduct);
        }

        [HttpPost]
        public string updateProduct([FromBody]Product pProduct)
        {
            return loProduct.updateProduct(pProduct);
        }

        [HttpGet]
        public bool removeProduct(string pId, string pUserId)
        {
            return loProduct.removeProduct(pId, pUserId);
        }
        #endregion ""

        #region "Loan Application"
        [HttpGet]
        public DataTable getLoanApplications(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLoanApplication.getLoanApplications(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getLoanApplicationStatus(string pLoanApplicationId)
        {
            return loLoanApplication.getLoanApplicationStatus(pLoanApplicationId);
        }

        [HttpGet]
        public DataTable getForReleaseSheet(DateTime pReleaseDate, string pCollectorId)
        {
            return loLoanApplication.getForReleaseSheet(pReleaseDate, pCollectorId);
        }

        [HttpPost]
        public string insertLoanApplication([FromBody]LoanApplication pLoanApplication)
        {
            return loLoanApplication.insertLoanApplication(pLoanApplication);
        }

        [HttpPost]
        public string updateLoanApplication([FromBody]LoanApplication pLoanApplication)
        {
            return loLoanApplication.updateLoanApplication(pLoanApplication);
        }

        [HttpGet]
        public bool removeLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.removeLoanApplication(pId, pUserId);
        }

        [HttpGet]
        public bool approveLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.approveLoanApplication(pId, pUserId);
        }

        [HttpGet]
        public bool cancelLoanApplication(string pId, string pReason, string pUserId)
        {
            return loLoanApplication.cancelLoanApplication(pId, pReason, pUserId);
        }

        [HttpGet]
        public bool postLoanApplication(string pId, string pUserId)
        {
            return loLoanApplication.postLoanApplication(pId, pUserId);
        }
        #endregion ""

        #region "Loan Application Detail"
        [HttpGet]
        public DataTable getLoanApplicationDetails(string pLoanApplicationId)
        {
            return loLoanApplicationDetail.getLoanApplicationDetails(pLoanApplicationId);
        }

        [HttpGet]
        public DataTable getLoanApplicationDetail(string pDetailId)
        {
            return loLoanApplicationDetail.getLoanApplicationDetail(pDetailId);
        }

        [HttpGet]
        public DataTable getDailyCollectionSheet(DateTime pCollectionDate, string pCollectorId)
        {
            return loLoanApplicationDetail.getDailyCollectionSheet(pCollectionDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getUploadCollectionList(DateTime pCollectionDate, string pCollectorId)
        {
            return loLoanApplicationDetail.getUploadCollectionList(pCollectionDate, pCollectorId);
        }

        [HttpGet]
        public DataTable getEODLoanApplicationDetail(DateTime pDate, string pBranchId)
        {
            return loLoanApplicationDetail.getEODLoanApplicationDetail(pDate, pBranchId);
        }

        [HttpGet]
        public DataTable getEODLoanApplicationDetailList(DateTime pDate, string pBranchId)
        {
            return loLoanApplicationDetail.getEODLoanApplicationDetailList(pDate, pBranchId);
        }

        [HttpPost]
        public bool insertLoanApplicationDetail([FromBody]LoanApplicationDetail pLoanApplicationDetail)
        {
            return loLoanApplicationDetail.insertLoanApplicationDetail(pLoanApplicationDetail);
        }

        [HttpPost]
        public bool updateLoanApplicationDetail([FromBody]LoanApplicationDetail pLoanApplicationDetail)
        {
            return loLoanApplicationDetail.updateLoanApplicationDetail(pLoanApplicationDetail);
        }

        [HttpGet]
        public bool removeLoanApplicationDetail(string pDetailId, string pUserId)
        {
            return loLoanApplicationDetail.removeLoanApplicationDetail(pDetailId, pUserId);
        }

        [HttpGet]
        public bool updatePayment(string pDetailId, decimal pPayment, decimal pNewBalance, decimal pVariance,
            string pPastDueReason, string pRemarks,string pCollectorId, string pUserId)
        {
            return loLoanApplicationDetail.updatePayment(pDetailId, pPayment, pNewBalance, pVariance, pPastDueReason, pRemarks,pCollectorId, pUserId);
        }

        [HttpGet]
        public bool updateEODLoanTransactionDetail(string pDetailId, string pEODId, string pUserId)
        {
            return loLoanApplicationDetail.updateEODLoanTransactionDetail(pDetailId, pEODId, pUserId);
        }
        #endregion ""

        #region "Loan End of Day"
        [HttpGet]
        public DataTable getLoanEndOfDays(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLoanEndOfDay.getLoanEndOfDays(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getLoanEndOfDayByBranch(string pBranchId)
        {
            return loLoanEndOfDay.getLoanEndOfDayByBranch(pBranchId);
        }
        
        [HttpPost]
        public string insertLoanEndOfDay([FromBody]LoanEndOfDay pLoanEndOfDay)
        {
            return loLoanEndOfDay.insertLoanEndOfDay(pLoanEndOfDay);
        }

        [HttpPost]
        public string updateLoanEndOfDay([FromBody]LoanEndOfDay pLoanEndOfDay)
        {
            return loLoanEndOfDay.updateLoanEndOfDay(pLoanEndOfDay);
        }

        [HttpGet]
        public bool removeLoanEndOfDay(string pId, string pUserId)
        {
            return loLoanEndOfDay.removeLoanEndOfDay(pId, pUserId);
        }
        #endregion ""

        #region "Loan End of Day Detail"
        [HttpGet]
        public DataTable getLoanEndOfDayDetails(string pLoanEndOfDayId)
        {
            return loLoanEndOfDayDetail.getLoanEndOfDayDetails(pLoanEndOfDayId);
        }

        [HttpPost]
        public bool insertLoanEndOfDayDetail([FromBody]LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            return loLoanEndOfDayDetail.insertLoanEndOfDayDetail(pLoanEndOfDayDetail);
        }

        [HttpPost]
        public bool updateLoanEndOfDayDetail([FromBody]LoanEndOfDayDetail pLoanEndOfDayDetail)
        {
            return loLoanEndOfDayDetail.updateLoanEndOfDayDetail(pLoanEndOfDayDetail);
        }

        [HttpGet]
        public bool removeLoanEndOfDayDetail(string pDetailId, string pUserId)
        {
            return loLoanEndOfDayDetail.removeLoanEndOfDayDetail(pDetailId, pUserId);
        }
        #endregion ""

        #endregion

        #region "HRISS"
        #region "Employee"
        [HttpGet]
        public DataTable getEmployees(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEmployee.getEmployees(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public DataTable getEmployeeNames()
        {
            return loEmployee.getEmployeeNames();
        }

        [HttpPost]
        public string insertEmployee([FromBody]Employee pEmployee)
        {
            return loEmployee.insertEmployee(pEmployee);
        }

        [HttpPost]
        public string updateEmployee([FromBody]Employee pEmployee)
        {
            return loEmployee.updateEmployee(pEmployee);
        }

        [HttpGet]
        public bool removeEmployee(string pId, string pUserId)
        {
            return loEmployee.removeEmployee(pId, pUserId);
        }
        #endregion ""

        #region "Employment Type"
        [HttpGet]
        public DataTable getEmploymentTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEmploymentType.getEmploymentTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertEmploymentType([FromBody]EmploymentType pEmploymentType)
        {
            return loEmploymentType.insertEmploymentType(pEmploymentType);
        }

        [HttpPost]
        public string updateEmploymentType([FromBody]EmploymentType pEmploymentType)
        {
            return loEmploymentType.updateEmploymentType(pEmploymentType);
        }

        [HttpGet]
        public bool removeEmploymentType(string pId, string pUserId)
        {
            return loEmploymentType.removeEmploymentType(pId, pUserId);
        }
        #endregion ""

        #region "Designation"
        [HttpGet]
        public DataTable getDesignations(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loDesignation.getDesignations(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertDesignation([FromBody]Designation pDesignation)
        {
            return loDesignation.insertDesignation(pDesignation);
        }

        [HttpPost]
        public string updateDesignation([FromBody]Designation pDesignation)
        {
            return loDesignation.updateDesignation(pDesignation);
        }

        [HttpGet]
        public bool removeDesignation(string pId, string pUserId)
        {
            return loDesignation.removeDesignation(pId, pUserId);
        }
        #endregion ""

        #region "Department"
        [HttpGet]
        public DataTable getDepartments(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loDepartment.getDepartments(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertDepartment([FromBody]Department pDepartment)
        {
            return loDepartment.insertDepartment(pDepartment);
        }

        [HttpPost]
        public string updateDepartment([FromBody]Department pDepartment)
        {
            return loDepartment.updateDepartment(pDepartment);
        }

        [HttpGet]
        public bool removeDepartment(string pId, string pUserId)
        {
            return loDepartment.removeDepartment(pId, pUserId);
        }
        #endregion ""

        #region "Leave Type"
        [HttpGet]
        public DataTable getLeaveTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loLeaveType.getLeaveTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertLeaveType([FromBody]LeaveType pLeaveType)
        {
            return loLeaveType.insertLeaveType(pLeaveType);
        }

        [HttpPost]
        public string updateLeaveType([FromBody]LeaveType pLeaveType)
        {
            return loLeaveType.updateLeaveType(pLeaveType);
        }

        [HttpGet]
        public bool removeLeaveType(string pId, string pUserId)
        {
            return loLeaveType.removeLeaveType(pId, pUserId);
        }
        #endregion ""

        #region "Holiday"
        [HttpGet]
        public DataTable getHolidays(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loHoliday.getHolidays(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertHoliday([FromBody]Holiday pHoliday)
        {
            return loHoliday.insertHoliday(pHoliday);
        }

        [HttpPost]
        public string updateHoliday([FromBody]Holiday pHoliday)
        {
            return loHoliday.updateHoliday(pHoliday);
        }

        [HttpGet]
        public bool removeHoliday(string pId, string pUserId)
        {
            return loHoliday.removeHoliday(pId, pUserId);
        }
        #endregion ""

        #region "Earning Type"
        [HttpGet]
        public DataTable getEarningTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loEarningType.getEarningTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertEarningType([FromBody]EarningType pEarningType)
        {
            return loEarningType.insertEarningType(pEarningType);
        }

        [HttpPost]
        public string updateEarningType([FromBody]EarningType pEarningType)
        {
            return loEarningType.updateEarningType(pEarningType);
        }

        [HttpGet]
        public bool removeEarningType(string pId, string pUserId)
        {
            return loEarningType.removeEarningType(pId, pUserId);
        }
        #endregion ""

        #region "Deduction Type"
        [HttpGet]
        public DataTable getDeductionTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loDeductionType.getDeductionTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertDeductionType([FromBody]DeductionType pDeductionType)
        {
            return loDeductionType.insertDeductionType(pDeductionType);
        }

        [HttpPost]
        public string updateDeductionType([FromBody]DeductionType pDeductionType)
        {
            return loDeductionType.updateDeductionType(pDeductionType);
        }

        [HttpGet]
        public bool removeDeductionType(string pId, string pUserId)
        {
            return loDeductionType.removeDeductionType(pId, pUserId);
        }
        #endregion ""

        #region "Tax Type"
        [HttpGet]
        public DataTable getTaxTypes(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loTaxType.getTaxTypes(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertTaxType([FromBody]TaxType pTaxType)
        {
            return loTaxType.insertTaxType(pTaxType);
        }

        [HttpPost]
        public string updateTaxType([FromBody]TaxType pTaxType)
        {
            return loTaxType.updateTaxType(pTaxType);
        }

        [HttpGet]
        public bool removeTaxType(string pId, string pUserId)
        {
            return loTaxType.removeTaxType(pId, pUserId);
        }
        #endregion ""

        #region "Income Tax Table"
        [HttpGet]
        public DataTable getIncomeTaxTables(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loIncomeTaxTable.getIncomeTaxTables(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertIncomeTaxTable([FromBody]IncomeTaxTable pIncomeTaxTable)
        {
            return loIncomeTaxTable.insertIncomeTaxTable(pIncomeTaxTable);
        }

        [HttpPost]
        public string updateIncomeTaxTable([FromBody]IncomeTaxTable pIncomeTaxTable)
        {
            return loIncomeTaxTable.updateIncomeTaxTable(pIncomeTaxTable);
        }

        [HttpGet]
        public bool removeIncomeTaxTable(string pId, string pUserId)
        {
            return loIncomeTaxTable.removeIncomeTaxTable(pId, pUserId);
        }
        #endregion ""

        #region "Work Schedules"
        [HttpGet]
        public DataTable getWorkSchedules(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loWorkSchedule.getWorkSchedules(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertWorkSchedule([FromBody]WorkSchedule pWorkSchedule)
        {
            return loWorkSchedule.insertWorkSchedule(pWorkSchedule);
        }

        [HttpPost]
        public string updateWorkSchedule([FromBody]WorkSchedule pWorkSchedule)
        {
            return loWorkSchedule.updateWorkSchedule(pWorkSchedule);
        }

        [HttpGet]
        public bool removeWorkSchedule(string pId, string pUserId)
        {
            return loWorkSchedule.removeWorkSchedule(pId, pUserId);
        }
        #endregion ""
        #endregion

        #region "PAYROLLS"

        #endregion

        #region "SYSTEMS"
        #region "Users"
        [HttpGet]
        public DataTable authenticateUser(string pUsername, string pPassword)
        {
            if (pPassword == null)
            {
                pPassword = "";
            }
            return loUser.authenticateUser(pUsername, pPassword);
        }

        [HttpGet]
        public DataTable getUsers(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUser.getUsers(pDisplayType, pPrimaryKey, pSearchString);
        }

        [HttpGet]
        public bool checkUserPassword(string pUserId, string pCurrentPassword)
        {
            return loUser.checkUserPassword(pUserId, pCurrentPassword);
        }

        [HttpGet]
        public bool changePassword(string pUserId,string pNewPassword)
        {
            return loUser.changePassword(pUserId, pNewPassword);
        }

        [HttpPost]
        public string insertUser([FromBody]User pUser)
        {
            return loUser.insertUser(pUser);
        }

        [HttpPost]
        public string updateUser([FromBody]User pUser)
        {
            return loUser.updateUser(pUser);
        }

        [HttpGet]
        public bool removeUser(string pId,string pUserId)
        {
            return loUser.removeUser(pId, pUserId);
        }
        #endregion ""

        #region "User Groups"
        [HttpGet]
        public DataTable getUserGroups(string pDisplayType, string pPrimaryKey, string pSearchString)
        {
            return loUserGroup.getUserGroups(pDisplayType,pPrimaryKey, pSearchString);
        }

        [HttpPost]
        public string insertUserGroup([FromBody]UserGroup pUserGroup)
        {
            return loUserGroup.insertUserGroup(pUserGroup);
        }

        [HttpPost]
        public string updateUserGroup([FromBody]UserGroup pUserGroup)
        {
            return loUserGroup.updateUserGroup(pUserGroup);
        }

        [HttpGet]
        public bool removeUserGroup(string pId, string pUserId)
        {
            return loUserGroup.removeUserGroup(pId, pUserId);
        }

        [HttpGet]
        public bool removeAllUserGroup(string pUserGroupId)
        {
            return loUserGroup.removeAllUserGroup(pUserGroupId);
        }

        [HttpGet]
        public bool updateUserGroupMenuItems(string pUserGroupId, string pMenuItem, string pItemName)
        {
            return loUserGroup.updateUserGroupMenuItems(pUserGroupId, pMenuItem, pItemName);
        }

        [HttpGet]
        public bool removeAllRights(string pUserGroupId, string pItemName)
        {
            return loUserGroup.removeAllRights(pUserGroupId, pItemName);
        }

        [HttpGet]
        public bool updateUserGroupRights(string pUserGroupId, string pItemName, string pRights)
        {
            return loUserGroup.updateUserGroupRights(pUserGroupId, pItemName, pRights);
        }
        #endregion ""

        #region "System Configurations"
        [HttpGet]
        public DataTable getSystemConfigurations()
        {
            return loSystemConfigurations.getSystemConfigurations();
        }

        [HttpPost]
        public bool updateSystemConfiguration([FromBody]SystemConfiguration pSystemConfiguration)
        {
            return loSystemConfigurations.updateSystemConfiguration(pSystemConfiguration);
        }
        #endregion ""

        #region "Audit Trail"
        [HttpGet]
        public DataTable getAuditTrailByDate(DateTime pFrom, DateTime pTo)
        {
            return loAuditTrail.getAuditTrailByDate(pFrom, pTo);
        }

        [HttpGet]
        public bool removeAuditTrail(DateTime pFrom, DateTime pTo)
        {
            return loAuditTrail.removeAuditTrail(pFrom, pTo);
        }
        #endregion ""

        #region "Backup / Restore Database"
        [HttpGet]
        public bool backupDatabase(string pSaveFileTo, string pBackupMySqlDumpAddress,
            string pUserId, string pPassword, string pServer, string pDatabase)
        {
            return loCommon.backupDatabase(pSaveFileTo, pBackupMySqlDumpAddress, pUserId, pPassword, pServer, pDatabase);
        }

        [HttpGet]
        public bool restoreDatabase(string pSQLFileFrom, string pRestoreMySqlAddress,
            string pUserId, string pPassword, string pServer, string pDatabase)
        {
            return loCommon.restoreDatabase(pSQLFileFrom, pRestoreMySqlAddress, pUserId, pPassword, pServer, pDatabase);
        }

        #endregion ""

        #endregion
    }
}
