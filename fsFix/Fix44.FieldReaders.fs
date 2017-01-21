module Fix44.FieldReaders


open System
open System.IO
open Fix44.Fields
open Conversions
open RawField


let ReadAccount (bs:byte[]) (pos:int) (len:int): Account =
    ReadFieldStr bs pos len Account.Account


let ReadAdvId (bs:byte[]) (pos:int) (len:int): AdvId =
    ReadFieldStr bs pos len AdvId.AdvId


let ReadAdvRefID (bs:byte[]) (pos:int) (len:int): AdvRefID =
    ReadFieldStr bs pos len AdvRefID.AdvRefID


let ReadAdvSide (bs:byte[]) (pos:int) (len:int): AdvSide =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"B"B -> AdvSide.Buy
    |"S"B -> AdvSide.Sell
    |"X"B -> AdvSide.Cross
    |"T"B -> AdvSide.Trade
    | x -> failwith (sprintf "ReadAdvSide unknown fix tag: %A"  x) 


let ReadAdvTransType (bs:byte[]) (pos:int) (len:int): AdvTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"N"B -> AdvTransType.New
    |"C"B -> AdvTransType.Cancel
    |"R"B -> AdvTransType.Replace
    | x -> failwith (sprintf "ReadAdvTransType unknown fix tag: %A"  x) 


let ReadAvgPx (bs:byte[]) (pos:int) (len:int): AvgPx =
    ReadFieldDecimal bs pos len AvgPx.AvgPx


let ReadBeginSeqNo (bs:byte[]) (pos:int) (len:int): BeginSeqNo =
    ReadFieldUInt bs pos len BeginSeqNo.BeginSeqNo


let ReadBeginString (bs:byte[]) (pos:int) (len:int): BeginString =
    ReadFieldStr bs pos len BeginString.BeginString


let ReadBodyLength (bs:byte[]) (pos:int) (len:int): BodyLength =
    ReadFieldUInt bs pos len BodyLength.BodyLength


let ReadCheckSum (bs:byte[]) (pos:int) (len:int): CheckSum =
    ReadFieldStr bs pos len CheckSum.CheckSum


let ReadClOrdID (bs:byte[]) (pos:int) (len:int): ClOrdID =
    ReadFieldStr bs pos len ClOrdID.ClOrdID


let ReadCommission (bs:byte[]) (pos:int) (len:int): Commission =
    ReadFieldDecimal bs pos len Commission.Commission


let ReadCommType (bs:byte[]) (pos:int) (len:int): CommType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> CommType.PerUnit
    |"2"B -> CommType.Percentage
    |"3"B -> CommType.Absolute
    |"4"B -> CommType.PercentageWaivedCashDiscount
    |"5"B -> CommType.PercentageWaivedEnhancedUnits
    |"6"B -> CommType.PointsPerBondOrOrContract
    | x -> failwith (sprintf "ReadCommType unknown fix tag: %A"  x) 


let ReadCumQty (bs:byte[]) (pos:int) (len:int): CumQty =
    ReadFieldDecimal bs pos len CumQty.CumQty


let ReadCurrency (bs:byte[]) (pos:int) (len:int): Currency =
    ReadFieldStr bs pos len Currency.Currency


let ReadEndSeqNo (bs:byte[]) (pos:int) (len:int): EndSeqNo =
    ReadFieldUInt bs pos len EndSeqNo.EndSeqNo


let ReadExecID (bs:byte[]) (pos:int) (len:int): ExecID =
    ReadFieldStr bs pos len ExecID.ExecID


let ReadExecInst (bs:byte[]) (pos:int) (len:int): ExecInst =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ExecInst.NotHeld
    |"2"B -> ExecInst.Work
    |"3"B -> ExecInst.GoAlong
    |"4"B -> ExecInst.OverTheDay
    |"5"B -> ExecInst.Held
    |"6"B -> ExecInst.ParticipateDontInitiate
    |"7"B -> ExecInst.StrictScale
    |"8"B -> ExecInst.TryToScale
    |"9"B -> ExecInst.StayOnBidside
    |"0"B -> ExecInst.StayOnOfferside
    |"A"B -> ExecInst.NoCross
    |"B"B -> ExecInst.OkToCross
    |"C"B -> ExecInst.CallFirst
    |"D"B -> ExecInst.PercentOfVolume
    |"E"B -> ExecInst.DoNotIncrease
    |"F"B -> ExecInst.DoNotReduce
    |"G"B -> ExecInst.AllOrNone
    |"H"B -> ExecInst.ReinstateOnSystemFailure
    |"I"B -> ExecInst.InstitutionsOnly
    |"J"B -> ExecInst.ReinstateOnTradingHalt
    |"K"B -> ExecInst.CancelOnTradingHalt
    |"L"B -> ExecInst.LastPeg
    |"M"B -> ExecInst.MidPrice
    |"N"B -> ExecInst.NonNegotiable
    |"O"B -> ExecInst.OpeningPeg
    |"P"B -> ExecInst.MarketPeg
    |"Q"B -> ExecInst.CancelOnSystemFailure
    |"R"B -> ExecInst.PrimaryPeg
    |"S"B -> ExecInst.Suspend
    |"T"B -> ExecInst.FixedPegToLocalBestBidOrOfferAtTimeOfOrder
    |"U"B -> ExecInst.CustomerDisplayInstruction
    |"V"B -> ExecInst.Netting
    |"W"B -> ExecInst.PegToVwap
    |"X"B -> ExecInst.TradeAlong
    |"Y"B -> ExecInst.TryToStop
    |"Z"B -> ExecInst.CancelIfNotBest
    |"a"B -> ExecInst.TrailingStopPeg
    |"b"B -> ExecInst.StrictLimit
    |"c"B -> ExecInst.IgnorePriceValidityChecks
    |"d"B -> ExecInst.PegToLimitPrice
    |"e"B -> ExecInst.WorkToTargetStrategy
    | x -> failwith (sprintf "ReadExecInst unknown fix tag: %A"  x) 


let ReadExecRefID (bs:byte[]) (pos:int) (len:int): ExecRefID =
    ReadFieldStr bs pos len ExecRefID.ExecRefID


let ReadHandlInst (bs:byte[]) (pos:int) (len:int): HandlInst =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> HandlInst.AutomatedExecutionOrderPrivate
    |"2"B -> HandlInst.AutomatedExecutionOrderPublic
    |"3"B -> HandlInst.ManualOrder
    | x -> failwith (sprintf "ReadHandlInst unknown fix tag: %A"  x) 


let ReadSecurityIDSource (bs:byte[]) (pos:int) (len:int): SecurityIDSource =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SecurityIDSource.Cusip
    |"2"B -> SecurityIDSource.Sedol
    |"3"B -> SecurityIDSource.Quik
    |"4"B -> SecurityIDSource.IsinNumber
    |"5"B -> SecurityIDSource.RicCode
    |"6"B -> SecurityIDSource.IsoCurrencyCode
    |"7"B -> SecurityIDSource.IsoCountryCode
    |"8"B -> SecurityIDSource.ExchangeSymbol
    |"9"B -> SecurityIDSource.ConsolidatedTapeAssociation
    |"A"B -> SecurityIDSource.BloombergSymbol
    |"B"B -> SecurityIDSource.Wertpapier
    |"C"B -> SecurityIDSource.Dutch
    |"D"B -> SecurityIDSource.Valoren
    |"E"B -> SecurityIDSource.Sicovam
    |"F"B -> SecurityIDSource.Belgian
    |"G"B -> SecurityIDSource.Common
    |"H"B -> SecurityIDSource.ClearingHouseClearingOrganization
    |"I"B -> SecurityIDSource.IsdaFpmlProductSpecification
    |"J"B -> SecurityIDSource.OptionsPriceReportingAuthority
    | x -> failwith (sprintf "ReadSecurityIDSource unknown fix tag: %A"  x) 


let ReadIOIid (bs:byte[]) (pos:int) (len:int): IOIid =
    ReadFieldStr bs pos len IOIid.IOIid


let ReadIOIQltyInd (bs:byte[]) (pos:int) (len:int): IOIQltyInd =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"L"B -> IOIQltyInd.Low
    |"M"B -> IOIQltyInd.Medium
    |"H"B -> IOIQltyInd.High
    | x -> failwith (sprintf "ReadIOIQltyInd unknown fix tag: %A"  x) 


let ReadIOIRefID (bs:byte[]) (pos:int) (len:int): IOIRefID =
    ReadFieldStr bs pos len IOIRefID.IOIRefID


let ReadIOIQty (bs:byte[]) (pos:int) (len:int): IOIQty =
    ReadFieldStr bs pos len IOIQty.IOIQty


let ReadIOITransType (bs:byte[]) (pos:int) (len:int): IOITransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"N"B -> IOITransType.New
    |"C"B -> IOITransType.Cancel
    |"R"B -> IOITransType.Replace
    | x -> failwith (sprintf "ReadIOITransType unknown fix tag: %A"  x) 


let ReadLastCapacity (bs:byte[]) (pos:int) (len:int): LastCapacity =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> LastCapacity.Agent
    |"2"B -> LastCapacity.CrossAsAgent
    |"3"B -> LastCapacity.CrossAsPrincipal
    |"4"B -> LastCapacity.Principal
    | x -> failwith (sprintf "ReadLastCapacity unknown fix tag: %A"  x) 


let ReadLastMkt (bs:byte[]) (pos:int) (len:int): LastMkt =
    ReadFieldStr bs pos len LastMkt.LastMkt


let ReadLastPx (bs:byte[]) (pos:int) (len:int): LastPx =
    ReadFieldDecimal bs pos len LastPx.LastPx


let ReadLastQty (bs:byte[]) (pos:int) (len:int): LastQty =
    ReadFieldDecimal bs pos len LastQty.LastQty


let ReadLinesOfText (bs:byte[]) (pos:int) (len:int): LinesOfText =
    ReadFieldInt bs pos len LinesOfText.LinesOfText


let ReadMsgSeqNum (bs:byte[]) (pos:int) (len:int): MsgSeqNum =
    ReadFieldUInt bs pos len MsgSeqNum.MsgSeqNum


let ReadMsgType (bs:byte[]) (pos:int) (len:int): MsgType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MsgType.Heartbeat
    |"1"B -> MsgType.TestRequest
    |"2"B -> MsgType.ResendRequest
    |"3"B -> MsgType.Reject
    |"4"B -> MsgType.SequenceReset
    |"5"B -> MsgType.Logout
    |"6"B -> MsgType.IndicationOfInterest
    |"7"B -> MsgType.Advertisement
    |"8"B -> MsgType.ExecutionReport
    |"9"B -> MsgType.OrderCancelReject
    |"A"B -> MsgType.Logon
    |"B"B -> MsgType.News
    |"C"B -> MsgType.Email
    |"D"B -> MsgType.NewOrderSingle
    |"E"B -> MsgType.NewOrderList
    |"F"B -> MsgType.OrderCancelRequest
    |"G"B -> MsgType.OrderCancelReplaceRequest
    |"H"B -> MsgType.OrderStatusRequest
    |"J"B -> MsgType.AllocationInstruction
    |"K"B -> MsgType.ListCancelRequest
    |"L"B -> MsgType.ListExecute
    |"M"B -> MsgType.ListStatusRequest
    |"N"B -> MsgType.ListStatus
    |"P"B -> MsgType.AllocationInstructionAck
    |"Q"B -> MsgType.DontKnowTrade
    |"R"B -> MsgType.QuoteRequest
    |"S"B -> MsgType.Quote
    |"T"B -> MsgType.SettlementInstructions
    |"V"B -> MsgType.MarketDataRequest
    |"W"B -> MsgType.MarketDataSnapshotFullRefresh
    |"X"B -> MsgType.MarketDataIncrementalRefresh
    |"Y"B -> MsgType.MarketDataRequestReject
    |"Z"B -> MsgType.QuoteCancel
    |"a"B -> MsgType.QuoteStatusRequest
    |"b"B -> MsgType.MassQuoteAcknowledgement
    |"c"B -> MsgType.SecurityDefinitionRequest
    |"d"B -> MsgType.SecurityDefinition
    |"e"B -> MsgType.SecurityStatusRequest
    |"f"B -> MsgType.SecurityStatus
    |"g"B -> MsgType.TradingSessionStatusRequest
    |"h"B -> MsgType.TradingSessionStatus
    |"i"B -> MsgType.MassQuote
    |"j"B -> MsgType.BusinessMessageReject
    |"k"B -> MsgType.BidRequest
    |"l"B -> MsgType.BidResponse
    |"m"B -> MsgType.ListStrikePrice
    |"n"B -> MsgType.XmlMessage
    |"o"B -> MsgType.RegistrationInstructions
    |"p"B -> MsgType.RegistrationInstructionsResponse
    |"q"B -> MsgType.OrderMassCancelRequest
    |"r"B -> MsgType.OrderMassCancelReport
    |"s"B -> MsgType.NewOrderCross
    |"t"B -> MsgType.CrossOrderCancelReplaceRequest
    |"u"B -> MsgType.CrossOrderCancelRequest
    |"v"B -> MsgType.SecurityTypeRequest
    |"w"B -> MsgType.SecurityTypes
    |"x"B -> MsgType.SecurityListRequest
    |"y"B -> MsgType.SecurityList
    |"z"B -> MsgType.DerivativeSecurityListRequest
    |"AA"B -> MsgType.DerivativeSecurityList
    |"AB"B -> MsgType.NewOrderMultileg
    |"AC"B -> MsgType.MultilegOrderCancelReplaceRequest
    |"AD"B -> MsgType.TradeCaptureReportRequest
    |"AE"B -> MsgType.TradeCaptureReport
    |"AF"B -> MsgType.OrderMassStatusRequest
    |"AG"B -> MsgType.QuoteRequestReject
    |"AH"B -> MsgType.RFQRequest
    |"AI"B -> MsgType.QuoteStatusReport
    |"AJ"B -> MsgType.QuoteResponse
    |"AK"B -> MsgType.Confirmation
    |"AL"B -> MsgType.PositionMaintenanceRequest
    |"AM"B -> MsgType.PositionMaintenanceReport
    |"AN"B -> MsgType.RequestForPositions
    |"AO"B -> MsgType.RequestForPositionsAck
    |"AP"B -> MsgType.PositionReport
    |"AQ"B -> MsgType.TradeCaptureReportRequestAck
    |"AR"B -> MsgType.TradeCaptureReportAck
    |"AS"B -> MsgType.AllocationReport
    |"AT"B -> MsgType.AllocationReportAck
    |"AU"B -> MsgType.ConfirmationAck
    |"AV"B -> MsgType.SettlementInstructionRequest
    |"AW"B -> MsgType.AssignmentReport
    |"AX"B -> MsgType.CollateralRequest
    |"AY"B -> MsgType.CollateralAssignment
    |"AZ"B -> MsgType.CollateralResponse
    |"BA"B -> MsgType.CollateralReport
    |"BB"B -> MsgType.CollateralInquiry
    |"BC"B -> MsgType.NetworkStatusRequest
    |"BD"B -> MsgType.NetworkStatusResponse
    |"BE"B -> MsgType.UserRequest
    |"BF"B -> MsgType.UserResponse
    |"BG"B -> MsgType.CollateralInquiryAck
    |"BH"B -> MsgType.ConfirmationRequest
    | x -> failwith (sprintf "ReadMsgType unknown fix tag: %A"  x) 


let ReadNewSeqNo (bs:byte[]) (pos:int) (len:int): NewSeqNo =
    ReadFieldUInt bs pos len NewSeqNo.NewSeqNo


let ReadOrderID (bs:byte[]) (pos:int) (len:int): OrderID =
    ReadFieldStr bs pos len OrderID.OrderID


let ReadOrderQty (bs:byte[]) (pos:int) (len:int): OrderQty =
    ReadFieldDecimal bs pos len OrderQty.OrderQty


let ReadOrdStatus (bs:byte[]) (pos:int) (len:int): OrdStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> OrdStatus.New
    |"1"B -> OrdStatus.PartiallyFilled
    |"2"B -> OrdStatus.Filled
    |"3"B -> OrdStatus.DoneForDay
    |"4"B -> OrdStatus.Canceled
    |"5"B -> OrdStatus.Replaced
    |"6"B -> OrdStatus.PendingCancel
    |"7"B -> OrdStatus.Stopped
    |"8"B -> OrdStatus.Rejected
    |"9"B -> OrdStatus.Suspended
    |"A"B -> OrdStatus.PendingNew
    |"B"B -> OrdStatus.Calculated
    |"C"B -> OrdStatus.Expired
    |"D"B -> OrdStatus.AcceptedForBidding
    |"E"B -> OrdStatus.PendingReplace
    | x -> failwith (sprintf "ReadOrdStatus unknown fix tag: %A"  x) 


let ReadOrdType (bs:byte[]) (pos:int) (len:int): OrdType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> OrdType.Market
    |"2"B -> OrdType.Limit
    |"3"B -> OrdType.Stop
    |"4"B -> OrdType.StopLimit
    |"5"B -> OrdType.MarketOnClose
    |"6"B -> OrdType.WithOrWithout
    |"7"B -> OrdType.LimitOrBetter
    |"8"B -> OrdType.LimitWithOrWithout
    |"9"B -> OrdType.OnBasis
    |"A"B -> OrdType.OnClose
    |"B"B -> OrdType.LimitOnClose
    |"C"B -> OrdType.ForexMarket
    |"D"B -> OrdType.PreviouslyQuoted
    |"E"B -> OrdType.PreviouslyIndicated
    |"F"B -> OrdType.ForexLimit
    |"G"B -> OrdType.ForexSwap
    |"H"B -> OrdType.ForexPreviouslyQuoted
    |"I"B -> OrdType.Funari
    |"J"B -> OrdType.MarketIfTouched
    |"K"B -> OrdType.MarketWithLeftoverAsLimit
    |"L"B -> OrdType.PreviousFundValuationPoint
    |"M"B -> OrdType.NextFundValuationPoint
    |"P"B -> OrdType.Pegged
    | x -> failwith (sprintf "ReadOrdType unknown fix tag: %A"  x) 


let ReadOrigClOrdID (bs:byte[]) (pos:int) (len:int): OrigClOrdID =
    ReadFieldStr bs pos len OrigClOrdID.OrigClOrdID


let ReadOrigTime (bs:byte[]) (pos:int) (len:int): OrigTime =
    ReadFieldUTCTimestamp bs pos len OrigTime.OrigTime


let ReadPossDupFlag (bs:byte[]) (pos:int) (len:int): PossDupFlag =
    ReadFieldBool bs pos len PossDupFlag.PossDupFlag


let ReadPrice (bs:byte[]) (pos:int) (len:int): Price =
    ReadFieldDecimal bs pos len Price.Price


let ReadRefSeqNum (bs:byte[]) (pos:int) (len:int): RefSeqNum =
    ReadFieldUInt bs pos len RefSeqNum.RefSeqNum


let ReadSecurityID (bs:byte[]) (pos:int) (len:int): SecurityID =
    ReadFieldStr bs pos len SecurityID.SecurityID


let ReadSenderCompID (bs:byte[]) (pos:int) (len:int): SenderCompID =
    ReadFieldStr bs pos len SenderCompID.SenderCompID


let ReadSenderSubID (bs:byte[]) (pos:int) (len:int): SenderSubID =
    ReadFieldStr bs pos len SenderSubID.SenderSubID


let ReadSendingTime (bs:byte[]) (pos:int) (len:int): SendingTime =
    ReadFieldUTCTimestamp bs pos len SendingTime.SendingTime


let ReadQuantity (bs:byte[]) (pos:int) (len:int): Quantity =
    ReadFieldDecimal bs pos len Quantity.Quantity


let ReadSide (bs:byte[]) (pos:int) (len:int): Side =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> Side.Buy
    |"2"B -> Side.Sell
    |"3"B -> Side.BuyMinus
    |"4"B -> Side.SellPlus
    |"5"B -> Side.SellShort
    |"6"B -> Side.SellShortExempt
    |"7"B -> Side.Undisclosed
    |"8"B -> Side.Cross
    |"9"B -> Side.CrossShort
    |"A"B -> Side.CrossShortExempt
    |"B"B -> Side.AsDefined
    |"C"B -> Side.Opposite
    |"D"B -> Side.Subscribe
    |"E"B -> Side.Redeem
    |"F"B -> Side.Lend
    |"G"B -> Side.Borrow
    | x -> failwith (sprintf "ReadSide unknown fix tag: %A"  x) 


let ReadSymbol (bs:byte[]) (pos:int) (len:int): Symbol =
    ReadFieldStr bs pos len Symbol.Symbol


let ReadTargetCompID (bs:byte[]) (pos:int) (len:int): TargetCompID =
    ReadFieldStr bs pos len TargetCompID.TargetCompID


let ReadTargetSubID (bs:byte[]) (pos:int) (len:int): TargetSubID =
    ReadFieldStr bs pos len TargetSubID.TargetSubID


let ReadText (bs:byte[]) (pos:int) (len:int): Text =
    ReadFieldStr bs pos len Text.Text


let ReadTimeInForce (bs:byte[]) (pos:int) (len:int): TimeInForce =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TimeInForce.Day
    |"1"B -> TimeInForce.GoodTillCancel
    |"2"B -> TimeInForce.AtTheOpening
    |"3"B -> TimeInForce.ImmediateOrCancel
    |"4"B -> TimeInForce.FillOrKill
    |"5"B -> TimeInForce.GoodTillCrossing
    |"6"B -> TimeInForce.GoodTillDate
    |"7"B -> TimeInForce.AtTheClose
    | x -> failwith (sprintf "ReadTimeInForce unknown fix tag: %A"  x) 


let ReadTransactTime (bs:byte[]) (pos:int) (len:int): TransactTime =
    ReadFieldUTCTimestamp bs pos len TransactTime.TransactTime


let ReadUrgency (bs:byte[]) (pos:int) (len:int): Urgency =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> Urgency.Normal
    |"1"B -> Urgency.Flash
    |"2"B -> Urgency.Background
    | x -> failwith (sprintf "ReadUrgency unknown fix tag: %A"  x) 


let ReadValidUntilTime (bs:byte[]) (pos:int) (len:int): ValidUntilTime =
    ReadFieldUTCTimestamp bs pos len ValidUntilTime.ValidUntilTime


let ReadSettlType (bs:byte[]) (pos:int) (len:int): SettlType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SettlType.Regular
    |"1"B -> SettlType.Cash
    |"2"B -> SettlType.NextDay
    |"3"B -> SettlType.TPlus2
    |"4"B -> SettlType.TPlus3
    |"5"B -> SettlType.TPlus4
    |"6"B -> SettlType.Future
    |"7"B -> SettlType.WhenAndIfIssued
    |"8"B -> SettlType.SellersOption
    |"9"B -> SettlType.TPlus5
    | x -> failwith (sprintf "ReadSettlType unknown fix tag: %A"  x) 


let ReadSettlDate (bs:byte[]) (pos:int) (len:int): SettlDate =
    ReadFieldLocalMktDate bs pos len SettlDate.SettlDate


let ReadSymbolSfx (bs:byte[]) (pos:int) (len:int): SymbolSfx =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"WI"B -> SymbolSfx.WhenIssued
    |"CD"B -> SymbolSfx.AEucpWithLumpSumInterest
    | x -> failwith (sprintf "ReadSymbolSfx unknown fix tag: %A"  x) 


let ReadListID (bs:byte[]) (pos:int) (len:int): ListID =
    ReadFieldStr bs pos len ListID.ListID


let ReadListSeqNo (bs:byte[]) (pos:int) (len:int): ListSeqNo =
    ReadFieldInt bs pos len ListSeqNo.ListSeqNo


let ReadTotNoOrders (bs:byte[]) (pos:int) (len:int): TotNoOrders =
    ReadFieldInt bs pos len TotNoOrders.TotNoOrders


let ReadListExecInst (bs:byte[]) (pos:int) (len:int): ListExecInst =
    ReadFieldStr bs pos len ListExecInst.ListExecInst


let ReadAllocID (bs:byte[]) (pos:int) (len:int): AllocID =
    ReadFieldStr bs pos len AllocID.AllocID


let ReadAllocTransType (bs:byte[]) (pos:int) (len:int): AllocTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AllocTransType.New
    |"1"B -> AllocTransType.Replace
    |"2"B -> AllocTransType.Cancel
    | x -> failwith (sprintf "ReadAllocTransType unknown fix tag: %A"  x) 


let ReadRefAllocID (bs:byte[]) (pos:int) (len:int): RefAllocID =
    ReadFieldStr bs pos len RefAllocID.RefAllocID


let ReadNoOrders (bs:byte[]) (pos:int) (len:int): NoOrders =
    ReadFieldInt bs pos len NoOrders.NoOrders


let ReadAvgPxPrecision (bs:byte[]) (pos:int) (len:int): AvgPxPrecision =
    ReadFieldInt bs pos len AvgPxPrecision.AvgPxPrecision


let ReadTradeDate (bs:byte[]) (pos:int) (len:int): TradeDate =
    ReadFieldLocalMktDate bs pos len TradeDate.TradeDate


let ReadPositionEffect (bs:byte[]) (pos:int) (len:int): PositionEffect =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"O"B -> PositionEffect.Open
    |"C"B -> PositionEffect.Close
    |"R"B -> PositionEffect.Rolled
    |"F"B -> PositionEffect.Fifo
    | x -> failwith (sprintf "ReadPositionEffect unknown fix tag: %A"  x) 


let ReadNoAllocs (bs:byte[]) (pos:int) (len:int): NoAllocs =
    ReadFieldInt bs pos len NoAllocs.NoAllocs


let ReadAllocAccount (bs:byte[]) (pos:int) (len:int): AllocAccount =
    ReadFieldStr bs pos len AllocAccount.AllocAccount


let ReadAllocQty (bs:byte[]) (pos:int) (len:int): AllocQty =
    ReadFieldDecimal bs pos len AllocQty.AllocQty


let ReadProcessCode (bs:byte[]) (pos:int) (len:int): ProcessCode =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ProcessCode.Regular
    |"1"B -> ProcessCode.SoftDollar
    |"2"B -> ProcessCode.StepIn
    |"3"B -> ProcessCode.StepOut
    |"4"B -> ProcessCode.SoftDollarStepIn
    |"5"B -> ProcessCode.SoftDollarStepOut
    |"6"B -> ProcessCode.PlanSponsor
    | x -> failwith (sprintf "ReadProcessCode unknown fix tag: %A"  x) 


let ReadNoRpts (bs:byte[]) (pos:int) (len:int): NoRpts =
    ReadFieldInt bs pos len NoRpts.NoRpts


let ReadRptSeq (bs:byte[]) (pos:int) (len:int): RptSeq =
    ReadFieldInt bs pos len RptSeq.RptSeq


let ReadCxlQty (bs:byte[]) (pos:int) (len:int): CxlQty =
    ReadFieldDecimal bs pos len CxlQty.CxlQty


let ReadNoDlvyInst (bs:byte[]) (pos:int) (len:int): NoDlvyInst =
    ReadFieldInt bs pos len NoDlvyInst.NoDlvyInst


let ReadAllocStatus (bs:byte[]) (pos:int) (len:int): AllocStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AllocStatus.Accepted
    |"1"B -> AllocStatus.BlockLevelReject
    |"2"B -> AllocStatus.AccountLevelReject
    |"3"B -> AllocStatus.Received
    |"4"B -> AllocStatus.Incomplete
    |"5"B -> AllocStatus.RejectedByIntermediary
    | x -> failwith (sprintf "ReadAllocStatus unknown fix tag: %A"  x) 


let ReadAllocRejCode (bs:byte[]) (pos:int) (len:int): AllocRejCode =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AllocRejCode.UnknownAccount
    |"1"B -> AllocRejCode.IncorrectQuantity
    |"2"B -> AllocRejCode.IncorrectAveragePrice
    |"3"B -> AllocRejCode.UnknownExecutingBrokerMnemonic
    |"4"B -> AllocRejCode.CommissionDifference
    |"5"B -> AllocRejCode.UnknownOrderid
    |"6"B -> AllocRejCode.UnknownListid
    |"7"B -> AllocRejCode.Other
    |"8"B -> AllocRejCode.IncorrectAllocatedQuantity
    |"9"B -> AllocRejCode.CalculationDifference
    |"10"B -> AllocRejCode.UnknownOrStaleExecId
    |"11"B -> AllocRejCode.MismatchedDataValue
    |"12"B -> AllocRejCode.UnknownClordid
    |"13"B -> AllocRejCode.WarehouseRequestRejected
    | x -> failwith (sprintf "ReadAllocRejCode unknown fix tag: %A"  x) 


// compound read
let ReadSignature (bs:byte[]) (pos:int) (len:int): Signature =
    ReadLengthDataCompoundField bs pos len "89"B Signature.Signature


// compound read
let ReadSecureData (bs:byte[]) (pos:int) (len:int): SecureData =
    ReadLengthDataCompoundField bs pos len "91"B SecureData.SecureData


let ReadEmailType (bs:byte[]) (pos:int) (len:int): EmailType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> EmailType.New
    |"1"B -> EmailType.Reply
    |"2"B -> EmailType.AdminReply
    | x -> failwith (sprintf "ReadEmailType unknown fix tag: %A"  x) 


// compound read
let ReadRawData (bs:byte[]) (pos:int) (len:int): RawData =
    ReadLengthDataCompoundField bs pos len "96"B RawData.RawData


let ReadPossResend (bs:byte[]) (pos:int) (len:int): PossResend =
    ReadFieldBool bs pos len PossResend.PossResend


let ReadEncryptMethod (bs:byte[]) (pos:int) (len:int): EncryptMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> EncryptMethod.NoneOther
    |"1"B -> EncryptMethod.Pkcs
    |"2"B -> EncryptMethod.Des
    |"3"B -> EncryptMethod.PkcsDes
    |"4"B -> EncryptMethod.PgpDes
    |"5"B -> EncryptMethod.PgpDesMd5
    |"6"B -> EncryptMethod.PemDesMd5
    | x -> failwith (sprintf "ReadEncryptMethod unknown fix tag: %A"  x) 


let ReadStopPx (bs:byte[]) (pos:int) (len:int): StopPx =
    ReadFieldDecimal bs pos len StopPx.StopPx


let ReadExDestination (bs:byte[]) (pos:int) (len:int): ExDestination =
    ReadFieldStr bs pos len ExDestination.ExDestination


let ReadCxlRejReason (bs:byte[]) (pos:int) (len:int): CxlRejReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CxlRejReason.TooLateToCancel
    |"1"B -> CxlRejReason.UnknownOrder
    |"2"B -> CxlRejReason.BrokerExchangeOption
    |"3"B -> CxlRejReason.OrderAlreadyInPendingCancelOrPendingReplaceStatus
    |"4"B -> CxlRejReason.UnableToProcessOrderMassCancelRequest
    |"5"B -> CxlRejReason.OrigordmodtimeDidNotMatchLastTransacttimeOfOrder
    |"6"B -> CxlRejReason.DuplicateClordidReceived
    |"99"B -> CxlRejReason.Other
    | x -> failwith (sprintf "ReadCxlRejReason unknown fix tag: %A"  x) 


let ReadOrdRejReason (bs:byte[]) (pos:int) (len:int): OrdRejReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> OrdRejReason.BrokerExchangeOption
    |"1"B -> OrdRejReason.UnknownSymbol
    |"2"B -> OrdRejReason.ExchangeClosed
    |"3"B -> OrdRejReason.OrderExceedsLimit
    |"4"B -> OrdRejReason.TooLateToEnter
    |"5"B -> OrdRejReason.UnknownOrder
    |"6"B -> OrdRejReason.DuplicateOrder
    |"7"B -> OrdRejReason.DuplicateOfAVerballyCommunicatedOrder
    |"8"B -> OrdRejReason.StaleOrder
    |"9"B -> OrdRejReason.TradeAlongRequired
    |"10"B -> OrdRejReason.InvalidInvestorId
    |"11"B -> OrdRejReason.UnsupportedOrderCharacteristic
    |"12"B -> OrdRejReason.SurveillenceOption
    |"13"B -> OrdRejReason.IncorrectQuantity
    |"14"B -> OrdRejReason.IncorrectAllocatedQuantity
    |"15"B -> OrdRejReason.UnknownAccount
    |"99"B -> OrdRejReason.Other
    | x -> failwith (sprintf "ReadOrdRejReason unknown fix tag: %A"  x) 


let ReadIOIQualifier (bs:byte[]) (pos:int) (len:int): IOIQualifier =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> IOIQualifier.AllOrNone
    |"B"B -> IOIQualifier.MarketOnClose
    |"C"B -> IOIQualifier.AtTheClose
    |"D"B -> IOIQualifier.Vwap
    |"I"B -> IOIQualifier.InTouchWith
    |"L"B -> IOIQualifier.Limit
    |"M"B -> IOIQualifier.MoreBehind
    |"O"B -> IOIQualifier.AtTheOpen
    |"P"B -> IOIQualifier.TakingAPosition
    |"Q"B -> IOIQualifier.AtTheMarket
    |"R"B -> IOIQualifier.ReadyToTrade
    |"S"B -> IOIQualifier.PortfolioShown
    |"T"B -> IOIQualifier.ThroughTheDay
    |"V"B -> IOIQualifier.Versus
    |"W"B -> IOIQualifier.IndicationWorkingAway
    |"X"B -> IOIQualifier.CrossingOpportunity
    |"Y"B -> IOIQualifier.AtTheMidpoint
    |"Z"B -> IOIQualifier.PreOpen
    | x -> failwith (sprintf "ReadIOIQualifier unknown fix tag: %A"  x) 


let ReadWaveNo (bs:byte[]) (pos:int) (len:int): WaveNo =
    ReadFieldStr bs pos len WaveNo.WaveNo


let ReadIssuer (bs:byte[]) (pos:int) (len:int): Issuer =
    ReadFieldStr bs pos len Issuer.Issuer


let ReadSecurityDesc (bs:byte[]) (pos:int) (len:int): SecurityDesc =
    ReadFieldStr bs pos len SecurityDesc.SecurityDesc


let ReadHeartBtInt (bs:byte[]) (pos:int) (len:int): HeartBtInt =
    ReadFieldInt bs pos len HeartBtInt.HeartBtInt


let ReadMinQty (bs:byte[]) (pos:int) (len:int): MinQty =
    ReadFieldDecimal bs pos len MinQty.MinQty


let ReadMaxFloor (bs:byte[]) (pos:int) (len:int): MaxFloor =
    ReadFieldDecimal bs pos len MaxFloor.MaxFloor


let ReadTestReqID (bs:byte[]) (pos:int) (len:int): TestReqID =
    ReadFieldStr bs pos len TestReqID.TestReqID


let ReadReportToExch (bs:byte[]) (pos:int) (len:int): ReportToExch =
    ReadFieldBool bs pos len ReportToExch.ReportToExch


let ReadLocateReqd (bs:byte[]) (pos:int) (len:int): LocateReqd =
    ReadFieldBool bs pos len LocateReqd.LocateReqd


let ReadOnBehalfOfCompID (bs:byte[]) (pos:int) (len:int): OnBehalfOfCompID =
    ReadFieldStr bs pos len OnBehalfOfCompID.OnBehalfOfCompID


let ReadOnBehalfOfSubID (bs:byte[]) (pos:int) (len:int): OnBehalfOfSubID =
    ReadFieldStr bs pos len OnBehalfOfSubID.OnBehalfOfSubID


let ReadQuoteID (bs:byte[]) (pos:int) (len:int): QuoteID =
    ReadFieldStr bs pos len QuoteID.QuoteID


let ReadNetMoney (bs:byte[]) (pos:int) (len:int): NetMoney =
    ReadFieldDecimal bs pos len NetMoney.NetMoney


let ReadSettlCurrAmt (bs:byte[]) (pos:int) (len:int): SettlCurrAmt =
    ReadFieldDecimal bs pos len SettlCurrAmt.SettlCurrAmt


let ReadSettlCurrency (bs:byte[]) (pos:int) (len:int): SettlCurrency =
    ReadFieldStr bs pos len SettlCurrency.SettlCurrency


let ReadForexReq (bs:byte[]) (pos:int) (len:int): ForexReq =
    ReadFieldBool bs pos len ForexReq.ForexReq


let ReadOrigSendingTime (bs:byte[]) (pos:int) (len:int): OrigSendingTime =
    ReadFieldUTCTimestamp bs pos len OrigSendingTime.OrigSendingTime


let ReadGapFillFlag (bs:byte[]) (pos:int) (len:int): GapFillFlag =
    ReadFieldBool bs pos len GapFillFlag.GapFillFlag


let ReadNoExecs (bs:byte[]) (pos:int) (len:int): NoExecs =
    ReadFieldInt bs pos len NoExecs.NoExecs


let ReadExpireTime (bs:byte[]) (pos:int) (len:int): ExpireTime =
    ReadFieldUTCTimestamp bs pos len ExpireTime.ExpireTime


let ReadDKReason (bs:byte[]) (pos:int) (len:int): DKReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> DKReason.UnknownSymbol
    |"B"B -> DKReason.WrongSide
    |"C"B -> DKReason.QuantityExceedsOrder
    |"D"B -> DKReason.NoMatchingOrder
    |"E"B -> DKReason.PriceExceedsLimit
    |"F"B -> DKReason.CalculationDifference
    |"Z"B -> DKReason.Other
    | x -> failwith (sprintf "ReadDKReason unknown fix tag: %A"  x) 


let ReadDeliverToCompID (bs:byte[]) (pos:int) (len:int): DeliverToCompID =
    ReadFieldStr bs pos len DeliverToCompID.DeliverToCompID


let ReadDeliverToSubID (bs:byte[]) (pos:int) (len:int): DeliverToSubID =
    ReadFieldStr bs pos len DeliverToSubID.DeliverToSubID


let ReadIOINaturalFlag (bs:byte[]) (pos:int) (len:int): IOINaturalFlag =
    ReadFieldBool bs pos len IOINaturalFlag.IOINaturalFlag


let ReadQuoteReqID (bs:byte[]) (pos:int) (len:int): QuoteReqID =
    ReadFieldStr bs pos len QuoteReqID.QuoteReqID


let ReadBidPx (bs:byte[]) (pos:int) (len:int): BidPx =
    ReadFieldDecimal bs pos len BidPx.BidPx


let ReadOfferPx (bs:byte[]) (pos:int) (len:int): OfferPx =
    ReadFieldDecimal bs pos len OfferPx.OfferPx


let ReadBidSize (bs:byte[]) (pos:int) (len:int): BidSize =
    ReadFieldDecimal bs pos len BidSize.BidSize


let ReadOfferSize (bs:byte[]) (pos:int) (len:int): OfferSize =
    ReadFieldDecimal bs pos len OfferSize.OfferSize


let ReadNoMiscFees (bs:byte[]) (pos:int) (len:int): NoMiscFees =
    ReadFieldInt bs pos len NoMiscFees.NoMiscFees


let ReadMiscFeeAmt (bs:byte[]) (pos:int) (len:int): MiscFeeAmt =
    ReadFieldDecimal bs pos len MiscFeeAmt.MiscFeeAmt


let ReadMiscFeeCurr (bs:byte[]) (pos:int) (len:int): MiscFeeCurr =
    ReadFieldStr bs pos len MiscFeeCurr.MiscFeeCurr


let ReadMiscFeeType (bs:byte[]) (pos:int) (len:int): MiscFeeType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> MiscFeeType.Regulatory
    |"2"B -> MiscFeeType.Tax
    |"3"B -> MiscFeeType.LocalCommission
    |"4"B -> MiscFeeType.ExchangeFees
    |"5"B -> MiscFeeType.Stamp
    |"6"B -> MiscFeeType.Levy
    |"7"B -> MiscFeeType.Other
    |"8"B -> MiscFeeType.Markup
    |"9"B -> MiscFeeType.ConsumptionTax
    |"10"B -> MiscFeeType.PerTransaction
    |"11"B -> MiscFeeType.Conversion
    |"12"B -> MiscFeeType.Agent
    | x -> failwith (sprintf "ReadMiscFeeType unknown fix tag: %A"  x) 


let ReadPrevClosePx (bs:byte[]) (pos:int) (len:int): PrevClosePx =
    ReadFieldDecimal bs pos len PrevClosePx.PrevClosePx


let ReadResetSeqNumFlag (bs:byte[]) (pos:int) (len:int): ResetSeqNumFlag =
    ReadFieldBool bs pos len ResetSeqNumFlag.ResetSeqNumFlag


let ReadSenderLocationID (bs:byte[]) (pos:int) (len:int): SenderLocationID =
    ReadFieldStr bs pos len SenderLocationID.SenderLocationID


let ReadTargetLocationID (bs:byte[]) (pos:int) (len:int): TargetLocationID =
    ReadFieldStr bs pos len TargetLocationID.TargetLocationID


let ReadOnBehalfOfLocationID (bs:byte[]) (pos:int) (len:int): OnBehalfOfLocationID =
    ReadFieldStr bs pos len OnBehalfOfLocationID.OnBehalfOfLocationID


let ReadDeliverToLocationID (bs:byte[]) (pos:int) (len:int): DeliverToLocationID =
    ReadFieldStr bs pos len DeliverToLocationID.DeliverToLocationID


let ReadNoRelatedSym (bs:byte[]) (pos:int) (len:int): NoRelatedSym =
    ReadFieldInt bs pos len NoRelatedSym.NoRelatedSym


let ReadSubject (bs:byte[]) (pos:int) (len:int): Subject =
    ReadFieldStr bs pos len Subject.Subject


let ReadHeadline (bs:byte[]) (pos:int) (len:int): Headline =
    ReadFieldStr bs pos len Headline.Headline


let ReadURLLink (bs:byte[]) (pos:int) (len:int): URLLink =
    ReadFieldStr bs pos len URLLink.URLLink


let ReadExecType (bs:byte[]) (pos:int) (len:int): ExecType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ExecType.New
    |"1"B -> ExecType.PartialFill
    |"2"B -> ExecType.Fill
    |"3"B -> ExecType.DoneForDay
    |"4"B -> ExecType.Canceled
    |"5"B -> ExecType.Replace
    |"6"B -> ExecType.PendingCancel
    |"7"B -> ExecType.Stopped
    |"8"B -> ExecType.Rejected
    |"9"B -> ExecType.Suspended
    |"A"B -> ExecType.PendingNew
    |"B"B -> ExecType.Calculated
    |"C"B -> ExecType.Expired
    |"D"B -> ExecType.Restated
    |"E"B -> ExecType.PendingReplace
    |"F"B -> ExecType.Trade
    |"G"B -> ExecType.TradeCorrect
    |"H"B -> ExecType.TradeCancel
    |"I"B -> ExecType.OrderStatus
    | x -> failwith (sprintf "ReadExecType unknown fix tag: %A"  x) 


let ReadLeavesQty (bs:byte[]) (pos:int) (len:int): LeavesQty =
    ReadFieldDecimal bs pos len LeavesQty.LeavesQty


let ReadCashOrderQty (bs:byte[]) (pos:int) (len:int): CashOrderQty =
    ReadFieldDecimal bs pos len CashOrderQty.CashOrderQty


let ReadAllocAvgPx (bs:byte[]) (pos:int) (len:int): AllocAvgPx =
    ReadFieldDecimal bs pos len AllocAvgPx.AllocAvgPx


let ReadAllocNetMoney (bs:byte[]) (pos:int) (len:int): AllocNetMoney =
    ReadFieldDecimal bs pos len AllocNetMoney.AllocNetMoney


let ReadSettlCurrFxRate (bs:byte[]) (pos:int) (len:int): SettlCurrFxRate =
    ReadFieldDecimal bs pos len SettlCurrFxRate.SettlCurrFxRate


let ReadSettlCurrFxRateCalc (bs:byte[]) (pos:int) (len:int): SettlCurrFxRateCalc =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"M"B -> SettlCurrFxRateCalc.Multiply
    |"D"B -> SettlCurrFxRateCalc.Divide
    | x -> failwith (sprintf "ReadSettlCurrFxRateCalc unknown fix tag: %A"  x) 


let ReadNumDaysInterest (bs:byte[]) (pos:int) (len:int): NumDaysInterest =
    ReadFieldInt bs pos len NumDaysInterest.NumDaysInterest


let ReadAccruedInterestRate (bs:byte[]) (pos:int) (len:int): AccruedInterestRate =
    ReadFieldDecimal bs pos len AccruedInterestRate.AccruedInterestRate


let ReadAccruedInterestAmt (bs:byte[]) (pos:int) (len:int): AccruedInterestAmt =
    ReadFieldDecimal bs pos len AccruedInterestAmt.AccruedInterestAmt


let ReadSettlInstMode (bs:byte[]) (pos:int) (len:int): SettlInstMode =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SettlInstMode.Default
    |"1"B -> SettlInstMode.StandingInstructionsProvided
    |"4"B -> SettlInstMode.SpecificOrderForASingleAccount
    |"5"B -> SettlInstMode.RequestReject
    | x -> failwith (sprintf "ReadSettlInstMode unknown fix tag: %A"  x) 


let ReadAllocText (bs:byte[]) (pos:int) (len:int): AllocText =
    ReadFieldStr bs pos len AllocText.AllocText


let ReadSettlInstID (bs:byte[]) (pos:int) (len:int): SettlInstID =
    ReadFieldStr bs pos len SettlInstID.SettlInstID


let ReadSettlInstTransType (bs:byte[]) (pos:int) (len:int): SettlInstTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"N"B -> SettlInstTransType.New
    |"C"B -> SettlInstTransType.Cancel
    |"R"B -> SettlInstTransType.Replace
    |"T"B -> SettlInstTransType.Restate
    | x -> failwith (sprintf "ReadSettlInstTransType unknown fix tag: %A"  x) 


let ReadEmailThreadID (bs:byte[]) (pos:int) (len:int): EmailThreadID =
    ReadFieldStr bs pos len EmailThreadID.EmailThreadID


let ReadSettlInstSource (bs:byte[]) (pos:int) (len:int): SettlInstSource =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SettlInstSource.BrokersInstructions
    |"2"B -> SettlInstSource.InstitutionsInstructions
    |"3"B -> SettlInstSource.Investor
    | x -> failwith (sprintf "ReadSettlInstSource unknown fix tag: %A"  x) 


let ReadSecurityType (bs:byte[]) (pos:int) (len:int): SecurityType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"EUSUPRA"B -> SecurityType.EuroSupranationalCoupons
    |"FAC"B -> SecurityType.FederalAgencyCoupon
    |"FADN"B -> SecurityType.FederalAgencyDiscountNote
    |"PEF"B -> SecurityType.PrivateExportFunding
    |"SUPRA"B -> SecurityType.UsdSupranationalCoupons
    |"FUT"B -> SecurityType.Future
    |"OPT"B -> SecurityType.Option
    |"CORP"B -> SecurityType.CorporateBond
    |"CPP"B -> SecurityType.CorporatePrivatePlacement
    |"CB"B -> SecurityType.ConvertibleBond
    |"DUAL"B -> SecurityType.DualCurrency
    |"EUCORP"B -> SecurityType.EuroCorporateBond
    |"XLINKD"B -> SecurityType.IndexedLinked
    |"STRUCT"B -> SecurityType.StructuredNotes
    |"YANK"B -> SecurityType.YankeeCorporateBond
    |"FOR"B -> SecurityType.ForeignExchangeContract
    |"CS"B -> SecurityType.CommonStock
    |"PS"B -> SecurityType.PreferredStock
    |"BRADY"B -> SecurityType.BradyBond
    |"EUSOV"B -> SecurityType.EuroSovereigns
    |"TBOND"B -> SecurityType.UsTreasuryBond
    |"TINT"B -> SecurityType.InterestStripFromAnyBondOrNote
    |"TIPS"B -> SecurityType.TreasuryInflationProtectedSecurities
    |"TCAL"B -> SecurityType.PrincipalStripOfACallableBondOrNote
    |"TPRN"B -> SecurityType.PrincipalStripFromANonCallableBondOrNote
    |"TNOTE"B -> SecurityType.UsTreasuryNote
    |"TBILL"B -> SecurityType.UsTreasuryBill
    |"REPO"B -> SecurityType.Repurchase
    |"FORWARD"B -> SecurityType.Forward
    |"BUYSELL"B -> SecurityType.BuySellback
    |"SECLOAN"B -> SecurityType.SecuritiesLoan
    |"SECPLEDGE"B -> SecurityType.SecuritiesPledge
    |"TERM"B -> SecurityType.TermLoan
    |"RVLV"B -> SecurityType.RevolverLoan
    |"RVLVTRM"B -> SecurityType.RevolverTermLoan
    |"BRIDGE"B -> SecurityType.BridgeLoan
    |"LOFC"B -> SecurityType.LetterOfCredit
    |"SWING"B -> SecurityType.SwingLineFacility
    |"DINP"B -> SecurityType.DebtorInPossession
    |"DEFLTED"B -> SecurityType.Defaulted
    |"WITHDRN"B -> SecurityType.Withdrawn
    |"REPLACD"B -> SecurityType.Replaced
    |"MATURED"B -> SecurityType.Matured
    |"AMENDED"B -> SecurityType.AmendedAndRestated
    |"RETIRED"B -> SecurityType.Retired
    |"BA"B -> SecurityType.BankersAcceptance
    |"BN"B -> SecurityType.BankNotes
    |"BOX"B -> SecurityType.BillOfExchanges
    |"CD"B -> SecurityType.CertificateOfDeposit
    |"CL"B -> SecurityType.CallLoans
    |"CP"B -> SecurityType.CommercialPaper
    |"DN"B -> SecurityType.DepositNotes
    |"EUCD"B -> SecurityType.EuroCertificateOfDeposit
    |"EUCP"B -> SecurityType.EuroCommercialPaper
    |"LQN"B -> SecurityType.LiquidityNote
    |"MTN"B -> SecurityType.MediumTermNotes
    |"ONITE"B -> SecurityType.Overnight
    |"PN"B -> SecurityType.PromissoryNote
    |"PZFJ"B -> SecurityType.PlazosFijos
    |"STN"B -> SecurityType.ShortTermLoanNote
    |"TD"B -> SecurityType.TimeDeposit
    |"XCN"B -> SecurityType.ExtendedCommNote
    |"YCD"B -> SecurityType.YankeeCertificateOfDeposit
    |"ABS"B -> SecurityType.AssetBackedSecurities
    |"CMBS"B -> SecurityType.CorpMortgageBackedSecurities
    |"CMO"B -> SecurityType.CollateralizedMortgageObligation
    |"IET"B -> SecurityType.IoetteMortgage
    |"MBS"B -> SecurityType.MortgageBackedSecurities
    |"MIO"B -> SecurityType.MortgageInterestOnly
    |"MPO"B -> SecurityType.MortgagePrincipalOnly
    |"MPP"B -> SecurityType.MortgagePrivatePlacement
    |"MPT"B -> SecurityType.MiscellaneousPassThrough
    |"PFAND"B -> SecurityType.Pfandbriefe
    |"TBA"B -> SecurityType.ToBeAnnounced
    |"AN"B -> SecurityType.OtherAnticipationNotes
    |"COFO"B -> SecurityType.CertificateOfObligation
    |"COFP"B -> SecurityType.CertificateOfParticipation
    |"GO"B -> SecurityType.GeneralObligationBonds
    |"MT"B -> SecurityType.MandatoryTender
    |"RAN"B -> SecurityType.RevenueAnticipationNote
    |"REV"B -> SecurityType.RevenueBonds
    |"SPCLA"B -> SecurityType.SpecialAssessment
    |"SPCLO"B -> SecurityType.SpecialObligation
    |"SPCLT"B -> SecurityType.SpecialTax
    |"TAN"B -> SecurityType.TaxAnticipationNote
    |"TAXA"B -> SecurityType.TaxAllocation
    |"TECP"B -> SecurityType.TaxExemptCommercialPaper
    |"TRAN"B -> SecurityType.TaxAndRevenueAnticipationNote
    |"VRDN"B -> SecurityType.VariableRateDemandNote
    |"WAR"B -> SecurityType.Warrant
    |"MF"B -> SecurityType.MutualFund
    |"MLEG"B -> SecurityType.MultiLegInstrument
    |"NONE"B -> SecurityType.NoSecurityType
    |"?"B -> SecurityType.Wildcard
    | x -> failwith (sprintf "ReadSecurityType unknown fix tag: %A"  x) 


let ReadEffectiveTime (bs:byte[]) (pos:int) (len:int): EffectiveTime =
    ReadFieldUTCTimestamp bs pos len EffectiveTime.EffectiveTime


let ReadStandInstDbType (bs:byte[]) (pos:int) (len:int): StandInstDbType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> StandInstDbType.Other
    |"1"B -> StandInstDbType.DtcSid
    |"2"B -> StandInstDbType.ThomsonAlert
    |"3"B -> StandInstDbType.AGlobalCustodian
    |"4"B -> StandInstDbType.Accountnet
    | x -> failwith (sprintf "ReadStandInstDbType unknown fix tag: %A"  x) 


let ReadStandInstDbName (bs:byte[]) (pos:int) (len:int): StandInstDbName =
    ReadFieldStr bs pos len StandInstDbName.StandInstDbName


let ReadStandInstDbID (bs:byte[]) (pos:int) (len:int): StandInstDbID =
    ReadFieldStr bs pos len StandInstDbID.StandInstDbID


let ReadSettlDeliveryType (bs:byte[]) (pos:int) (len:int): SettlDeliveryType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SettlDeliveryType.VersusPayment
    |"1"B -> SettlDeliveryType.Free
    |"2"B -> SettlDeliveryType.TriParty
    |"3"B -> SettlDeliveryType.HoldInCustody
    | x -> failwith (sprintf "ReadSettlDeliveryType unknown fix tag: %A"  x) 


let ReadBidSpotRate (bs:byte[]) (pos:int) (len:int): BidSpotRate =
    ReadFieldDecimal bs pos len BidSpotRate.BidSpotRate


let ReadBidForwardPoints (bs:byte[]) (pos:int) (len:int): BidForwardPoints =
    ReadFieldDecimal bs pos len BidForwardPoints.BidForwardPoints


let ReadOfferSpotRate (bs:byte[]) (pos:int) (len:int): OfferSpotRate =
    ReadFieldDecimal bs pos len OfferSpotRate.OfferSpotRate


let ReadOfferForwardPoints (bs:byte[]) (pos:int) (len:int): OfferForwardPoints =
    ReadFieldDecimal bs pos len OfferForwardPoints.OfferForwardPoints


let ReadOrderQty2 (bs:byte[]) (pos:int) (len:int): OrderQty2 =
    ReadFieldDecimal bs pos len OrderQty2.OrderQty2


let ReadSettlDate2 (bs:byte[]) (pos:int) (len:int): SettlDate2 =
    ReadFieldLocalMktDate bs pos len SettlDate2.SettlDate2


let ReadLastSpotRate (bs:byte[]) (pos:int) (len:int): LastSpotRate =
    ReadFieldDecimal bs pos len LastSpotRate.LastSpotRate


let ReadLastForwardPoints (bs:byte[]) (pos:int) (len:int): LastForwardPoints =
    ReadFieldDecimal bs pos len LastForwardPoints.LastForwardPoints


let ReadAllocLinkID (bs:byte[]) (pos:int) (len:int): AllocLinkID =
    ReadFieldStr bs pos len AllocLinkID.AllocLinkID


let ReadAllocLinkType (bs:byte[]) (pos:int) (len:int): AllocLinkType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AllocLinkType.FXNetting
    |"1"B -> AllocLinkType.FXSwap
    | x -> failwith (sprintf "ReadAllocLinkType unknown fix tag: %A"  x) 


let ReadSecondaryOrderID (bs:byte[]) (pos:int) (len:int): SecondaryOrderID =
    ReadFieldStr bs pos len SecondaryOrderID.SecondaryOrderID


let ReadNoIOIQualifiers (bs:byte[]) (pos:int) (len:int): NoIOIQualifiers =
    ReadFieldInt bs pos len NoIOIQualifiers.NoIOIQualifiers


let ReadMaturityMonthYear (bs:byte[]) (pos:int) (len:int): MaturityMonthYear =
    ReadFieldMonthYear bs pos len MaturityMonthYear.MaturityMonthYear


let ReadPutOrCall (bs:byte[]) (pos:int) (len:int): PutOrCall =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PutOrCall.Put
    |"1"B -> PutOrCall.Call
    | x -> failwith (sprintf "ReadPutOrCall unknown fix tag: %A"  x) 


let ReadStrikePrice (bs:byte[]) (pos:int) (len:int): StrikePrice =
    ReadFieldDecimal bs pos len StrikePrice.StrikePrice


let ReadCoveredOrUncovered (bs:byte[]) (pos:int) (len:int): CoveredOrUncovered =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CoveredOrUncovered.Covered
    |"1"B -> CoveredOrUncovered.Uncovered
    | x -> failwith (sprintf "ReadCoveredOrUncovered unknown fix tag: %A"  x) 


let ReadOptAttribute (bs:byte[]) (pos:int) (len:int): OptAttribute =
    ReadFieldChar bs pos len OptAttribute.OptAttribute


let ReadSecurityExchange (bs:byte[]) (pos:int) (len:int): SecurityExchange =
    ReadFieldStr bs pos len SecurityExchange.SecurityExchange


let ReadNotifyBrokerOfCredit (bs:byte[]) (pos:int) (len:int): NotifyBrokerOfCredit =
    ReadFieldBool bs pos len NotifyBrokerOfCredit.NotifyBrokerOfCredit


let ReadAllocHandlInst (bs:byte[]) (pos:int) (len:int): AllocHandlInst =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AllocHandlInst.Match
    |"2"B -> AllocHandlInst.Forward
    |"3"B -> AllocHandlInst.ForwardAndMatch
    | x -> failwith (sprintf "ReadAllocHandlInst unknown fix tag: %A"  x) 


let ReadMaxShow (bs:byte[]) (pos:int) (len:int): MaxShow =
    ReadFieldDecimal bs pos len MaxShow.MaxShow


let ReadPegOffsetValue (bs:byte[]) (pos:int) (len:int): PegOffsetValue =
    ReadFieldDecimal bs pos len PegOffsetValue.PegOffsetValue


// compound read
let ReadXmlData (bs:byte[]) (pos:int) (len:int): XmlData =
    ReadLengthDataCompoundField bs pos len "213"B XmlData.XmlData


let ReadSettlInstRefID (bs:byte[]) (pos:int) (len:int): SettlInstRefID =
    ReadFieldStr bs pos len SettlInstRefID.SettlInstRefID


let ReadNoRoutingIDs (bs:byte[]) (pos:int) (len:int): NoRoutingIDs =
    ReadFieldInt bs pos len NoRoutingIDs.NoRoutingIDs


let ReadRoutingType (bs:byte[]) (pos:int) (len:int): RoutingType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> RoutingType.TargetFirm
    |"2"B -> RoutingType.TargetList
    |"3"B -> RoutingType.BlockFirm
    |"4"B -> RoutingType.BlockList
    | x -> failwith (sprintf "ReadRoutingType unknown fix tag: %A"  x) 


let ReadRoutingID (bs:byte[]) (pos:int) (len:int): RoutingID =
    ReadFieldStr bs pos len RoutingID.RoutingID


let ReadSpread (bs:byte[]) (pos:int) (len:int): Spread =
    ReadFieldDecimal bs pos len Spread.Spread


let ReadBenchmarkCurveCurrency (bs:byte[]) (pos:int) (len:int): BenchmarkCurveCurrency =
    ReadFieldStr bs pos len BenchmarkCurveCurrency.BenchmarkCurveCurrency


let ReadBenchmarkCurveName (bs:byte[]) (pos:int) (len:int): BenchmarkCurveName =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"MuniAAA"B -> BenchmarkCurveName.Muniaaa
    |"FutureSWAP"B -> BenchmarkCurveName.Futureswap
    |"LIBID"B -> BenchmarkCurveName.Libid
    |"LIBOR"B -> BenchmarkCurveName.Libor
    |"OTHER"B -> BenchmarkCurveName.Other
    |"SWAP"B -> BenchmarkCurveName.Swap
    |"Treasury"B -> BenchmarkCurveName.Treasury
    |"Euribor"B -> BenchmarkCurveName.Euribor
    |"Pfandbriefe"B -> BenchmarkCurveName.Pfandbriefe
    |"EONIA"B -> BenchmarkCurveName.Eonia
    |"SONIA"B -> BenchmarkCurveName.Sonia
    |"EUREPO"B -> BenchmarkCurveName.Eurepo
    | x -> failwith (sprintf "ReadBenchmarkCurveName unknown fix tag: %A"  x) 


let ReadBenchmarkCurvePoint (bs:byte[]) (pos:int) (len:int): BenchmarkCurvePoint =
    ReadFieldStr bs pos len BenchmarkCurvePoint.BenchmarkCurvePoint


let ReadCouponRate (bs:byte[]) (pos:int) (len:int): CouponRate =
    ReadFieldDecimal bs pos len CouponRate.CouponRate


let ReadCouponPaymentDate (bs:byte[]) (pos:int) (len:int): CouponPaymentDate =
    ReadFieldLocalMktDate bs pos len CouponPaymentDate.CouponPaymentDate


let ReadIssueDate (bs:byte[]) (pos:int) (len:int): IssueDate =
    ReadFieldLocalMktDate bs pos len IssueDate.IssueDate


let ReadRepurchaseTerm (bs:byte[]) (pos:int) (len:int): RepurchaseTerm =
    ReadFieldInt bs pos len RepurchaseTerm.RepurchaseTerm


let ReadRepurchaseRate (bs:byte[]) (pos:int) (len:int): RepurchaseRate =
    ReadFieldDecimal bs pos len RepurchaseRate.RepurchaseRate


let ReadFactor (bs:byte[]) (pos:int) (len:int): Factor =
    ReadFieldDecimal bs pos len Factor.Factor


let ReadTradeOriginationDate (bs:byte[]) (pos:int) (len:int): TradeOriginationDate =
    ReadFieldLocalMktDate bs pos len TradeOriginationDate.TradeOriginationDate


let ReadExDate (bs:byte[]) (pos:int) (len:int): ExDate =
    ReadFieldLocalMktDate bs pos len ExDate.ExDate


let ReadContractMultiplier (bs:byte[]) (pos:int) (len:int): ContractMultiplier =
    ReadFieldDecimal bs pos len ContractMultiplier.ContractMultiplier


let ReadNoStipulations (bs:byte[]) (pos:int) (len:int): NoStipulations =
    ReadFieldInt bs pos len NoStipulations.NoStipulations


let ReadStipulationType (bs:byte[]) (pos:int) (len:int): StipulationType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"AMT"B -> StipulationType.Amt
    |"AUTOREINV"B -> StipulationType.AutoReinvestmentAtOrBetter
    |"BANKQUAL"B -> StipulationType.BankQualified
    |"BGNCON"B -> StipulationType.BargainConditions
    |"COUPON"B -> StipulationType.CouponRange
    |"CURRENCY"B -> StipulationType.IsoCurrencyCode
    |"CUSTOMDATE"B -> StipulationType.CustomStartEndDate
    |"GEOG"B -> StipulationType.GeographicsAndPercentRange
    |"HAIRCUT"B -> StipulationType.ValuationDiscount
    |"INSURED"B -> StipulationType.Insured
    |"ISSUE"B -> StipulationType.YearOrYearMonthOfIssue
    |"ISSUER"B -> StipulationType.IssuersTicker
    |"ISSUESIZE"B -> StipulationType.IssueSizeRange
    |"LOOKBACK"B -> StipulationType.LookbackDays
    |"LOT"B -> StipulationType.ExplicitLotIdentifier
    |"LOTVAR"B -> StipulationType.LotVariance
    |"MAT"B -> StipulationType.MaturityYearAndMonth
    |"MATURITY"B -> StipulationType.MaturityRange
    |"MAXSUBS"B -> StipulationType.MaximumSubstitutions
    |"MINQTY"B -> StipulationType.MinimumQuantity
    |"MININCR"B -> StipulationType.MinimumIncrement
    |"MINDNOM"B -> StipulationType.MinimumDenomination
    |"PAYFREQ"B -> StipulationType.PaymentFrequencyCalendar
    |"PIECES"B -> StipulationType.NumberOfPieces
    |"PMAX"B -> StipulationType.PoolsMaximum
    |"PPM"B -> StipulationType.PoolsPerMillion
    |"PPL"B -> StipulationType.PoolsPerLot
    |"PPT"B -> StipulationType.PoolsPerTrade
    |"PRICE"B -> StipulationType.PriceRange
    |"PRICEFREQ"B -> StipulationType.PricingFrequency
    |"PROD"B -> StipulationType.ProductionYear
    |"PROTECT"B -> StipulationType.CallProtection
    |"PURPOSE"B -> StipulationType.Purpose
    |"PXSOURCE"B -> StipulationType.BenchmarkPriceSource
    |"RATING"B -> StipulationType.RatingSourceAndRange
    |"RESTRICTED"B -> StipulationType.Restricted
    |"SECTOR"B -> StipulationType.MarketSector
    |"SECTYPE"B -> StipulationType.SecuritytypeIncludedOrExcluded
    |"STRUCT"B -> StipulationType.Structure
    |"SUBSFREQ"B -> StipulationType.SubstitutionsFrequency
    |"SUBSLEFT"B -> StipulationType.SubstitutionsLeft
    |"TEXT"B -> StipulationType.FreeformText
    |"TRDVAR"B -> StipulationType.TradeVariance
    |"WAC"B -> StipulationType.WeightedAverageCoupon
    |"WAL"B -> StipulationType.WeightedAverageLifeCoupon
    |"WALA"B -> StipulationType.WeightedAverageLoanAge
    |"WAM"B -> StipulationType.WeightedAverageMaturity
    |"WHOLE"B -> StipulationType.WholePool
    |"YIELD"B -> StipulationType.YieldRange
    |"SMM"B -> StipulationType.SingleMonthlyMortality
    |"CPR"B -> StipulationType.ConstantPrepaymentRate
    |"CPY"B -> StipulationType.ConstantPrepaymentYield
    |"CPP"B -> StipulationType.ConstantPrepaymentPenalty
    |"ABS"B -> StipulationType.AbsolutePrepaymentSpeed
    |"MPR"B -> StipulationType.MonthlyPrepaymentRate
    |"PSA"B -> StipulationType.PercentOfBmaPrepaymentCurve
    |"PPC"B -> StipulationType.PercentOfProspectusPrepaymentCurve
    |"MHP"B -> StipulationType.PercentOfManufacturedHousingPrepaymentCurve
    |"HEP"B -> StipulationType.FinalCprOfHomeEquityPrepaymentCurve
    | x -> failwith (sprintf "ReadStipulationType unknown fix tag: %A"  x) 


let ReadStipulationValue (bs:byte[]) (pos:int) (len:int): StipulationValue =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"CD"B -> StipulationValue.SpecialCumDividend
    |"XD"B -> StipulationValue.SpecialExDividend
    |"CC"B -> StipulationValue.SpecialCumCoupon
    |"XC"B -> StipulationValue.SpecialExCoupon
    |"CB"B -> StipulationValue.SpecialCumBonus
    |"XB"B -> StipulationValue.SpecialExBonus
    |"CR"B -> StipulationValue.SpecialCumRights
    |"XR"B -> StipulationValue.SpecialExRights
    |"CP"B -> StipulationValue.SpecialCumCapitalRepayments
    |"XP"B -> StipulationValue.SpecialExCapitalRepayments
    |"CS"B -> StipulationValue.CashSettlement
    |"SP"B -> StipulationValue.SpecialPrice
    |"TR"B -> StipulationValue.ReportForEuropeanEquityMarketSecurities
    |"GD"B -> StipulationValue.GuaranteedDelivery
    | x -> failwith (sprintf "ReadStipulationValue unknown fix tag: %A"  x) 


let ReadYieldType (bs:byte[]) (pos:int) (len:int): YieldType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"AFTERTAX"B -> YieldType.AfterTaxYield
    |"ANNUAL"B -> YieldType.AnnualYield
    |"ATISSUE"B -> YieldType.YieldAtIssue
    |"AVGMATURITY"B -> YieldType.YieldToAverageMaturity
    |"BOOK"B -> YieldType.BookYield
    |"CALL"B -> YieldType.YieldToNextCall
    |"CHANGE"B -> YieldType.YieldChangeSinceClose
    |"CLOSE"B -> YieldType.ClosingYield
    |"COMPOUND"B -> YieldType.CompoundYield
    |"CURRENT"B -> YieldType.CurrentYield
    |"GROSS"B -> YieldType.TrueGrossYield
    |"GOVTEQUIV"B -> YieldType.GovernmentEquivalentYield
    |"INFLATION"B -> YieldType.YieldWithInflationAssumption
    |"INVERSEFLOATER"B -> YieldType.InverseFloaterBondYield
    |"LASTCLOSE"B -> YieldType.MostRecentClosingYield
    |"LASTMONTH"B -> YieldType.ClosingYieldMostRecentMonth
    |"LASTQUARTER"B -> YieldType.ClosingYieldMostRecentQuarter
    |"LASTYEAR"B -> YieldType.ClosingYieldMostRecentYear
    |"LONGAVGLIFE"B -> YieldType.YieldToLongestAverageLife
    |"MARK"B -> YieldType.MarkToMarketYield
    |"MATURITY"B -> YieldType.YieldToMaturity
    |"NEXTREFUND"B -> YieldType.YieldToNextRefund
    |"OPENAVG"B -> YieldType.OpenAverageYield
    |"PUT"B -> YieldType.YieldToNextPut
    |"PREVCLOSE"B -> YieldType.PreviousCloseYield
    |"PROCEEDS"B -> YieldType.ProceedsYield
    |"SEMIANNUAL"B -> YieldType.SemiAnnualYield
    |"SHORTAVGLIFE"B -> YieldType.YieldToShortestAverageLife
    |"SIMPLE"B -> YieldType.SimpleYield
    |"TAXEQUIV"B -> YieldType.TaxEquivalentYield
    |"TENDER"B -> YieldType.YieldToTenderDate
    |"TRUE"B -> YieldType.TrueYield
    |"VALUE1_32"B -> YieldType.YieldValueOf132
    |"WORST"B -> YieldType.YieldToWorst
    | x -> failwith (sprintf "ReadYieldType unknown fix tag: %A"  x) 


let ReadYield (bs:byte[]) (pos:int) (len:int): Yield =
    ReadFieldDecimal bs pos len Yield.Yield


let ReadTotalTakedown (bs:byte[]) (pos:int) (len:int): TotalTakedown =
    ReadFieldDecimal bs pos len TotalTakedown.TotalTakedown


let ReadConcession (bs:byte[]) (pos:int) (len:int): Concession =
    ReadFieldDecimal bs pos len Concession.Concession


let ReadRepoCollateralSecurityType (bs:byte[]) (pos:int) (len:int): RepoCollateralSecurityType =
    ReadFieldInt bs pos len RepoCollateralSecurityType.RepoCollateralSecurityType


let ReadRedemptionDate (bs:byte[]) (pos:int) (len:int): RedemptionDate =
    ReadFieldLocalMktDate bs pos len RedemptionDate.RedemptionDate


let ReadUnderlyingCouponPaymentDate (bs:byte[]) (pos:int) (len:int): UnderlyingCouponPaymentDate =
    ReadFieldLocalMktDate bs pos len UnderlyingCouponPaymentDate.UnderlyingCouponPaymentDate


let ReadUnderlyingIssueDate (bs:byte[]) (pos:int) (len:int): UnderlyingIssueDate =
    ReadFieldLocalMktDate bs pos len UnderlyingIssueDate.UnderlyingIssueDate


let ReadUnderlyingRepoCollateralSecurityType (bs:byte[]) (pos:int) (len:int): UnderlyingRepoCollateralSecurityType =
    ReadFieldInt bs pos len UnderlyingRepoCollateralSecurityType.UnderlyingRepoCollateralSecurityType


let ReadUnderlyingRepurchaseTerm (bs:byte[]) (pos:int) (len:int): UnderlyingRepurchaseTerm =
    ReadFieldInt bs pos len UnderlyingRepurchaseTerm.UnderlyingRepurchaseTerm


let ReadUnderlyingRepurchaseRate (bs:byte[]) (pos:int) (len:int): UnderlyingRepurchaseRate =
    ReadFieldDecimal bs pos len UnderlyingRepurchaseRate.UnderlyingRepurchaseRate


let ReadUnderlyingFactor (bs:byte[]) (pos:int) (len:int): UnderlyingFactor =
    ReadFieldDecimal bs pos len UnderlyingFactor.UnderlyingFactor


let ReadUnderlyingRedemptionDate (bs:byte[]) (pos:int) (len:int): UnderlyingRedemptionDate =
    ReadFieldLocalMktDate bs pos len UnderlyingRedemptionDate.UnderlyingRedemptionDate


let ReadLegCouponPaymentDate (bs:byte[]) (pos:int) (len:int): LegCouponPaymentDate =
    ReadFieldLocalMktDate bs pos len LegCouponPaymentDate.LegCouponPaymentDate


let ReadLegIssueDate (bs:byte[]) (pos:int) (len:int): LegIssueDate =
    ReadFieldLocalMktDate bs pos len LegIssueDate.LegIssueDate


let ReadLegRepoCollateralSecurityType (bs:byte[]) (pos:int) (len:int): LegRepoCollateralSecurityType =
    ReadFieldInt bs pos len LegRepoCollateralSecurityType.LegRepoCollateralSecurityType


let ReadLegRepurchaseTerm (bs:byte[]) (pos:int) (len:int): LegRepurchaseTerm =
    ReadFieldInt bs pos len LegRepurchaseTerm.LegRepurchaseTerm


let ReadLegRepurchaseRate (bs:byte[]) (pos:int) (len:int): LegRepurchaseRate =
    ReadFieldDecimal bs pos len LegRepurchaseRate.LegRepurchaseRate


let ReadLegFactor (bs:byte[]) (pos:int) (len:int): LegFactor =
    ReadFieldDecimal bs pos len LegFactor.LegFactor


let ReadLegRedemptionDate (bs:byte[]) (pos:int) (len:int): LegRedemptionDate =
    ReadFieldLocalMktDate bs pos len LegRedemptionDate.LegRedemptionDate


let ReadCreditRating (bs:byte[]) (pos:int) (len:int): CreditRating =
    ReadFieldStr bs pos len CreditRating.CreditRating


let ReadUnderlyingCreditRating (bs:byte[]) (pos:int) (len:int): UnderlyingCreditRating =
    ReadFieldStr bs pos len UnderlyingCreditRating.UnderlyingCreditRating


let ReadLegCreditRating (bs:byte[]) (pos:int) (len:int): LegCreditRating =
    ReadFieldStr bs pos len LegCreditRating.LegCreditRating


let ReadTradedFlatSwitch (bs:byte[]) (pos:int) (len:int): TradedFlatSwitch =
    ReadFieldBool bs pos len TradedFlatSwitch.TradedFlatSwitch


let ReadBasisFeatureDate (bs:byte[]) (pos:int) (len:int): BasisFeatureDate =
    ReadFieldLocalMktDate bs pos len BasisFeatureDate.BasisFeatureDate


let ReadBasisFeaturePrice (bs:byte[]) (pos:int) (len:int): BasisFeaturePrice =
    ReadFieldDecimal bs pos len BasisFeaturePrice.BasisFeaturePrice


let ReadMDReqID (bs:byte[]) (pos:int) (len:int): MDReqID =
    ReadFieldStr bs pos len MDReqID.MDReqID


let ReadSubscriptionRequestType (bs:byte[]) (pos:int) (len:int): SubscriptionRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SubscriptionRequestType.Snapshot
    |"1"B -> SubscriptionRequestType.SnapshotPlusUpdates
    |"2"B -> SubscriptionRequestType.DisablePreviousSnapshotPlusUpdateRequest
    | x -> failwith (sprintf "ReadSubscriptionRequestType unknown fix tag: %A"  x) 


let ReadMarketDepth (bs:byte[]) (pos:int) (len:int): MarketDepth =
    ReadFieldInt bs pos len MarketDepth.MarketDepth


let ReadMDUpdateType (bs:byte[]) (pos:int) (len:int): MDUpdateType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MDUpdateType.FullRefresh
    |"1"B -> MDUpdateType.IncrementalRefresh
    | x -> failwith (sprintf "ReadMDUpdateType unknown fix tag: %A"  x) 


let ReadAggregatedBook (bs:byte[]) (pos:int) (len:int): AggregatedBook =
    ReadFieldBool bs pos len AggregatedBook.AggregatedBook


let ReadNoMDEntryTypes (bs:byte[]) (pos:int) (len:int): NoMDEntryTypes =
    ReadFieldInt bs pos len NoMDEntryTypes.NoMDEntryTypes


let ReadNoMDEntries (bs:byte[]) (pos:int) (len:int): NoMDEntries =
    ReadFieldInt bs pos len NoMDEntries.NoMDEntries


let ReadMDEntryType (bs:byte[]) (pos:int) (len:int): MDEntryType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MDEntryType.Bid
    |"1"B -> MDEntryType.Offer
    |"2"B -> MDEntryType.Trade
    |"3"B -> MDEntryType.IndexValue
    |"4"B -> MDEntryType.OpeningPrice
    |"5"B -> MDEntryType.ClosingPrice
    |"6"B -> MDEntryType.SettlementPrice
    |"7"B -> MDEntryType.TradingSessionHighPrice
    |"8"B -> MDEntryType.TradingSessionLowPrice
    |"9"B -> MDEntryType.TradingSessionVwapPrice
    |"A"B -> MDEntryType.Imbalance
    |"B"B -> MDEntryType.TradeVolume
    |"C"B -> MDEntryType.OpenInterest
    | x -> failwith (sprintf "ReadMDEntryType unknown fix tag: %A"  x) 


let ReadMDEntryPx (bs:byte[]) (pos:int) (len:int): MDEntryPx =
    ReadFieldDecimal bs pos len MDEntryPx.MDEntryPx


let ReadMDEntrySize (bs:byte[]) (pos:int) (len:int): MDEntrySize =
    ReadFieldDecimal bs pos len MDEntrySize.MDEntrySize


let ReadMDEntryDate (bs:byte[]) (pos:int) (len:int): MDEntryDate =
    ReadFieldUTCDate bs pos len MDEntryDate.MDEntryDate


let ReadMDEntryTime (bs:byte[]) (pos:int) (len:int): MDEntryTime =
    ReadFieldUTCTimeOnly bs pos len MDEntryTime.MDEntryTime


let ReadTickDirection (bs:byte[]) (pos:int) (len:int): TickDirection =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TickDirection.PlusTick
    |"1"B -> TickDirection.ZeroPlusTick
    |"2"B -> TickDirection.MinusTick
    |"3"B -> TickDirection.ZeroMinusTick
    | x -> failwith (sprintf "ReadTickDirection unknown fix tag: %A"  x) 


let ReadMDMkt (bs:byte[]) (pos:int) (len:int): MDMkt =
    ReadFieldStr bs pos len MDMkt.MDMkt


let ReadQuoteCondition (bs:byte[]) (pos:int) (len:int): QuoteCondition =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> QuoteCondition.OpenActive
    |"B"B -> QuoteCondition.ClosedInactive
    |"C"B -> QuoteCondition.ExchangeBest
    |"D"B -> QuoteCondition.ConsolidatedBest
    |"E"B -> QuoteCondition.Locked
    |"F"B -> QuoteCondition.Crossed
    |"G"B -> QuoteCondition.Depth
    |"H"B -> QuoteCondition.FastTrading
    |"I"B -> QuoteCondition.NonFirm
    | x -> failwith (sprintf "ReadQuoteCondition unknown fix tag: %A"  x) 


let ReadTradeCondition (bs:byte[]) (pos:int) (len:int): TradeCondition =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> TradeCondition.CashMarket
    |"B"B -> TradeCondition.AveragePriceTrade
    |"C"B -> TradeCondition.CashTrade
    |"D"B -> TradeCondition.NextDayMarket
    |"E"B -> TradeCondition.OpeningReopeningTradeDetail
    |"F"B -> TradeCondition.IntradayTradeDetail
    |"G"B -> TradeCondition.Rule127
    |"H"B -> TradeCondition.Rule155
    |"I"B -> TradeCondition.SoldLast
    |"J"B -> TradeCondition.NextDayTrade
    |"K"B -> TradeCondition.Opened
    |"L"B -> TradeCondition.Seller
    |"M"B -> TradeCondition.Sold
    |"N"B -> TradeCondition.StoppedStock
    |"P"B -> TradeCondition.ImbalanceMoreBuyers
    |"Q"B -> TradeCondition.ImbalanceMoreSellers
    |"R"B -> TradeCondition.OpeningPrice
    | x -> failwith (sprintf "ReadTradeCondition unknown fix tag: %A"  x) 


let ReadMDEntryID (bs:byte[]) (pos:int) (len:int): MDEntryID =
    ReadFieldStr bs pos len MDEntryID.MDEntryID


let ReadMDUpdateAction (bs:byte[]) (pos:int) (len:int): MDUpdateAction =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MDUpdateAction.New
    |"1"B -> MDUpdateAction.Change
    |"2"B -> MDUpdateAction.Delete
    | x -> failwith (sprintf "ReadMDUpdateAction unknown fix tag: %A"  x) 


let ReadMDEntryRefID (bs:byte[]) (pos:int) (len:int): MDEntryRefID =
    ReadFieldStr bs pos len MDEntryRefID.MDEntryRefID


let ReadMDReqRejReason (bs:byte[]) (pos:int) (len:int): MDReqRejReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MDReqRejReason.UnknownSymbol
    |"1"B -> MDReqRejReason.DuplicateMdreqid
    |"2"B -> MDReqRejReason.InsufficientBandwidth
    |"3"B -> MDReqRejReason.InsufficientPermissions
    |"4"B -> MDReqRejReason.UnsupportedSubscriptionrequesttype
    |"5"B -> MDReqRejReason.UnsupportedMarketdepth
    |"6"B -> MDReqRejReason.UnsupportedMdupdatetype
    |"7"B -> MDReqRejReason.UnsupportedAggregatedbook
    |"8"B -> MDReqRejReason.UnsupportedMdentrytype
    |"9"B -> MDReqRejReason.UnsupportedTradingsessionid
    |"A"B -> MDReqRejReason.UnsupportedScope
    |"B"B -> MDReqRejReason.UnsupportedOpenclosesettleflag
    |"C"B -> MDReqRejReason.UnsupportedMdimplicitdelete
    | x -> failwith (sprintf "ReadMDReqRejReason unknown fix tag: %A"  x) 


let ReadMDEntryOriginator (bs:byte[]) (pos:int) (len:int): MDEntryOriginator =
    ReadFieldStr bs pos len MDEntryOriginator.MDEntryOriginator


let ReadLocationID (bs:byte[]) (pos:int) (len:int): LocationID =
    ReadFieldStr bs pos len LocationID.LocationID


let ReadDeskID (bs:byte[]) (pos:int) (len:int): DeskID =
    ReadFieldStr bs pos len DeskID.DeskID


let ReadDeleteReason (bs:byte[]) (pos:int) (len:int): DeleteReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DeleteReason.CancelationTradeBust
    |"1"B -> DeleteReason.Error
    | x -> failwith (sprintf "ReadDeleteReason unknown fix tag: %A"  x) 


let ReadOpenCloseSettlFlag (bs:byte[]) (pos:int) (len:int): OpenCloseSettlFlag =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> OpenCloseSettlFlag.DailyOpenCloseSettlementEntry
    |"1"B -> OpenCloseSettlFlag.SessionOpenCloseSettlementEntry
    |"2"B -> OpenCloseSettlFlag.DeliverySettlementEntry
    |"3"B -> OpenCloseSettlFlag.ExpectedEntry
    |"4"B -> OpenCloseSettlFlag.EntryFromPreviousBusinessDay
    |"5"B -> OpenCloseSettlFlag.TheoreticalPriceValue
    | x -> failwith (sprintf "ReadOpenCloseSettlFlag unknown fix tag: %A"  x) 


let ReadSellerDays (bs:byte[]) (pos:int) (len:int): SellerDays =
    ReadFieldInt bs pos len SellerDays.SellerDays


let ReadMDEntryBuyer (bs:byte[]) (pos:int) (len:int): MDEntryBuyer =
    ReadFieldStr bs pos len MDEntryBuyer.MDEntryBuyer


let ReadMDEntrySeller (bs:byte[]) (pos:int) (len:int): MDEntrySeller =
    ReadFieldStr bs pos len MDEntrySeller.MDEntrySeller


let ReadMDEntryPositionNo (bs:byte[]) (pos:int) (len:int): MDEntryPositionNo =
    ReadFieldInt bs pos len MDEntryPositionNo.MDEntryPositionNo


let ReadFinancialStatus (bs:byte[]) (pos:int) (len:int): FinancialStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> FinancialStatus.Bankrupt
    |"2"B -> FinancialStatus.PendingDelisting
    | x -> failwith (sprintf "ReadFinancialStatus unknown fix tag: %A"  x) 


let ReadCorporateAction (bs:byte[]) (pos:int) (len:int): CorporateAction =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> CorporateAction.ExDividend
    |"B"B -> CorporateAction.ExDistribution
    |"C"B -> CorporateAction.ExRights
    |"D"B -> CorporateAction.New
    |"E"B -> CorporateAction.ExInterest
    | x -> failwith (sprintf "ReadCorporateAction unknown fix tag: %A"  x) 


let ReadDefBidSize (bs:byte[]) (pos:int) (len:int): DefBidSize =
    ReadFieldDecimal bs pos len DefBidSize.DefBidSize


let ReadDefOfferSize (bs:byte[]) (pos:int) (len:int): DefOfferSize =
    ReadFieldDecimal bs pos len DefOfferSize.DefOfferSize


let ReadNoQuoteEntries (bs:byte[]) (pos:int) (len:int): NoQuoteEntries =
    ReadFieldInt bs pos len NoQuoteEntries.NoQuoteEntries


let ReadNoQuoteSets (bs:byte[]) (pos:int) (len:int): NoQuoteSets =
    ReadFieldInt bs pos len NoQuoteSets.NoQuoteSets


let ReadQuoteStatus (bs:byte[]) (pos:int) (len:int): QuoteStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> QuoteStatus.Accepted
    |"1"B -> QuoteStatus.CanceledForSymbol
    |"2"B -> QuoteStatus.CanceledForSecurityType
    |"3"B -> QuoteStatus.CanceledForUnderlying
    |"4"B -> QuoteStatus.CanceledAll
    |"5"B -> QuoteStatus.Rejected
    |"6"B -> QuoteStatus.RemovedFromMarket
    |"7"B -> QuoteStatus.Expired
    |"8"B -> QuoteStatus.Query
    |"9"B -> QuoteStatus.QuoteNotFound
    |"10"B -> QuoteStatus.Pending
    |"11"B -> QuoteStatus.Pass
    |"12"B -> QuoteStatus.LockedMarketWarning
    |"13"B -> QuoteStatus.CrossMarketWarning
    |"14"B -> QuoteStatus.CanceledDueToLockMarket
    |"15"B -> QuoteStatus.CanceledDueToCrossMarket
    | x -> failwith (sprintf "ReadQuoteStatus unknown fix tag: %A"  x) 


let ReadQuoteCancelType (bs:byte[]) (pos:int) (len:int): QuoteCancelType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuoteCancelType.CancelForSymbol
    |"2"B -> QuoteCancelType.CancelForSecurityType
    |"3"B -> QuoteCancelType.CancelForUnderlyingSymbol
    |"4"B -> QuoteCancelType.CancelAllQuotes
    | x -> failwith (sprintf "ReadQuoteCancelType unknown fix tag: %A"  x) 


let ReadQuoteEntryID (bs:byte[]) (pos:int) (len:int): QuoteEntryID =
    ReadFieldStr bs pos len QuoteEntryID.QuoteEntryID


let ReadQuoteRejectReason (bs:byte[]) (pos:int) (len:int): QuoteRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuoteRejectReason.UnknownSymbol
    |"2"B -> QuoteRejectReason.ExchangeClosed
    |"3"B -> QuoteRejectReason.QuoteRequestExceedsLimit
    |"4"B -> QuoteRejectReason.TooLateToEnter
    |"5"B -> QuoteRejectReason.UnknownQuote
    |"6"B -> QuoteRejectReason.DuplicateQuote
    |"7"B -> QuoteRejectReason.InvalidBidAskSpread
    |"8"B -> QuoteRejectReason.InvalidPrice
    |"9"B -> QuoteRejectReason.NotAuthorizedToQuoteSecurity
    |"99"B -> QuoteRejectReason.Other
    | x -> failwith (sprintf "ReadQuoteRejectReason unknown fix tag: %A"  x) 


let ReadQuoteResponseLevel (bs:byte[]) (pos:int) (len:int): QuoteResponseLevel =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> QuoteResponseLevel.NoAcknowledgement
    |"1"B -> QuoteResponseLevel.AcknowledgeOnlyNegativeOrErroneousQuotes
    |"2"B -> QuoteResponseLevel.AcknowledgeEachQuoteMessages
    | x -> failwith (sprintf "ReadQuoteResponseLevel unknown fix tag: %A"  x) 


let ReadQuoteSetID (bs:byte[]) (pos:int) (len:int): QuoteSetID =
    ReadFieldStr bs pos len QuoteSetID.QuoteSetID


let ReadQuoteRequestType (bs:byte[]) (pos:int) (len:int): QuoteRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuoteRequestType.Manual
    |"2"B -> QuoteRequestType.Automatic
    | x -> failwith (sprintf "ReadQuoteRequestType unknown fix tag: %A"  x) 


let ReadTotNoQuoteEntries (bs:byte[]) (pos:int) (len:int): TotNoQuoteEntries =
    ReadFieldInt bs pos len TotNoQuoteEntries.TotNoQuoteEntries


let ReadUnderlyingSecurityIDSource (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityIDSource =
    ReadFieldStr bs pos len UnderlyingSecurityIDSource.UnderlyingSecurityIDSource


let ReadUnderlyingIssuer (bs:byte[]) (pos:int) (len:int): UnderlyingIssuer =
    ReadFieldStr bs pos len UnderlyingIssuer.UnderlyingIssuer


let ReadUnderlyingSecurityDesc (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityDesc =
    ReadFieldStr bs pos len UnderlyingSecurityDesc.UnderlyingSecurityDesc


let ReadUnderlyingSecurityExchange (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityExchange =
    ReadFieldStr bs pos len UnderlyingSecurityExchange.UnderlyingSecurityExchange


let ReadUnderlyingSecurityID (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityID =
    ReadFieldStr bs pos len UnderlyingSecurityID.UnderlyingSecurityID


let ReadUnderlyingSecurityType (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityType =
    ReadFieldStr bs pos len UnderlyingSecurityType.UnderlyingSecurityType


let ReadUnderlyingSymbol (bs:byte[]) (pos:int) (len:int): UnderlyingSymbol =
    ReadFieldStr bs pos len UnderlyingSymbol.UnderlyingSymbol


let ReadUnderlyingSymbolSfx (bs:byte[]) (pos:int) (len:int): UnderlyingSymbolSfx =
    ReadFieldStr bs pos len UnderlyingSymbolSfx.UnderlyingSymbolSfx


let ReadUnderlyingMaturityMonthYear (bs:byte[]) (pos:int) (len:int): UnderlyingMaturityMonthYear =
    ReadFieldMonthYear bs pos len UnderlyingMaturityMonthYear.UnderlyingMaturityMonthYear


let ReadUnderlyingPutOrCall (bs:byte[]) (pos:int) (len:int): UnderlyingPutOrCall =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> UnderlyingPutOrCall.Put
    |"1"B -> UnderlyingPutOrCall.Call
    | x -> failwith (sprintf "ReadUnderlyingPutOrCall unknown fix tag: %A"  x) 


let ReadUnderlyingStrikePrice (bs:byte[]) (pos:int) (len:int): UnderlyingStrikePrice =
    ReadFieldDecimal bs pos len UnderlyingStrikePrice.UnderlyingStrikePrice


let ReadUnderlyingOptAttribute (bs:byte[]) (pos:int) (len:int): UnderlyingOptAttribute =
    ReadFieldChar bs pos len UnderlyingOptAttribute.UnderlyingOptAttribute


let ReadUnderlyingCurrency (bs:byte[]) (pos:int) (len:int): UnderlyingCurrency =
    ReadFieldStr bs pos len UnderlyingCurrency.UnderlyingCurrency


let ReadSecurityReqID (bs:byte[]) (pos:int) (len:int): SecurityReqID =
    ReadFieldStr bs pos len SecurityReqID.SecurityReqID


let ReadSecurityRequestType (bs:byte[]) (pos:int) (len:int): SecurityRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SecurityRequestType.RequestSecurityIdentityAndSpecifications
    |"1"B -> SecurityRequestType.RequestSecurityIdentityForTheSpecificationsProvided
    |"2"B -> SecurityRequestType.RequestListSecurityTypes
    |"3"B -> SecurityRequestType.RequestListSecurities
    | x -> failwith (sprintf "ReadSecurityRequestType unknown fix tag: %A"  x) 


let ReadSecurityResponseID (bs:byte[]) (pos:int) (len:int): SecurityResponseID =
    ReadFieldStr bs pos len SecurityResponseID.SecurityResponseID


let ReadSecurityResponseType (bs:byte[]) (pos:int) (len:int): SecurityResponseType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SecurityResponseType.AcceptSecurityProposalAsIs
    |"2"B -> SecurityResponseType.AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage
    |"3"B -> SecurityResponseType.ListOfSecurityTypesReturnedPerRequest
    |"4"B -> SecurityResponseType.ListOfSecuritiesReturnedPerRequest
    |"5"B -> SecurityResponseType.RejectSecurityProposal
    |"6"B -> SecurityResponseType.CanNotMatchSelectionCriteria
    | x -> failwith (sprintf "ReadSecurityResponseType unknown fix tag: %A"  x) 


let ReadSecurityStatusReqID (bs:byte[]) (pos:int) (len:int): SecurityStatusReqID =
    ReadFieldStr bs pos len SecurityStatusReqID.SecurityStatusReqID


let ReadUnsolicitedIndicator (bs:byte[]) (pos:int) (len:int): UnsolicitedIndicator =
    ReadFieldBool bs pos len UnsolicitedIndicator.UnsolicitedIndicator


let ReadSecurityTradingStatus (bs:byte[]) (pos:int) (len:int): SecurityTradingStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SecurityTradingStatus.OpeningDelay
    |"2"B -> SecurityTradingStatus.TradingHalt
    |"3"B -> SecurityTradingStatus.Resume
    |"4"B -> SecurityTradingStatus.NoOpenNoResume
    |"5"B -> SecurityTradingStatus.PriceIndication
    |"6"B -> SecurityTradingStatus.TradingRangeIndication
    |"7"B -> SecurityTradingStatus.MarketImbalanceBuy
    |"8"B -> SecurityTradingStatus.MarketImbalanceSell
    |"9"B -> SecurityTradingStatus.MarketOnCloseImbalanceBuy
    |"10"B -> SecurityTradingStatus.MarketOnCloseImbalanceSell
    |"11"B -> SecurityTradingStatus.NotAssigned
    |"12"B -> SecurityTradingStatus.NoMarketImbalance
    |"13"B -> SecurityTradingStatus.NoMarketOnCloseImbalance
    |"14"B -> SecurityTradingStatus.ItsPreOpening
    |"15"B -> SecurityTradingStatus.NewPriceIndication
    |"16"B -> SecurityTradingStatus.TradeDisseminationTime
    |"17"B -> SecurityTradingStatus.ReadyToTradeStartOfSession
    |"18"B -> SecurityTradingStatus.NotAvailableForTradingEndOfSession
    |"19"B -> SecurityTradingStatus.NotTradedOnThisMarket
    |"20"B -> SecurityTradingStatus.UnknownOrInvalid
    |"21"B -> SecurityTradingStatus.PreOpen
    |"22"B -> SecurityTradingStatus.OpeningRotation
    |"23"B -> SecurityTradingStatus.FastMarket
    | x -> failwith (sprintf "ReadSecurityTradingStatus unknown fix tag: %A"  x) 


let ReadHaltReason (bs:byte[]) (pos:int) (len:int): HaltReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"I"B -> HaltReason.OrderImbalance
    |"X"B -> HaltReason.EquipmentChangeover
    |"P"B -> HaltReason.NewsPending
    |"D"B -> HaltReason.NewsDissemination
    |"E"B -> HaltReason.OrderInflux
    |"M"B -> HaltReason.AdditionalInformation
    | x -> failwith (sprintf "ReadHaltReason unknown fix tag: %A"  x) 


let ReadInViewOfCommon (bs:byte[]) (pos:int) (len:int): InViewOfCommon =
    ReadFieldBool bs pos len InViewOfCommon.InViewOfCommon


let ReadDueToRelated (bs:byte[]) (pos:int) (len:int): DueToRelated =
    ReadFieldBool bs pos len DueToRelated.DueToRelated


let ReadBuyVolume (bs:byte[]) (pos:int) (len:int): BuyVolume =
    ReadFieldDecimal bs pos len BuyVolume.BuyVolume


let ReadSellVolume (bs:byte[]) (pos:int) (len:int): SellVolume =
    ReadFieldDecimal bs pos len SellVolume.SellVolume


let ReadHighPx (bs:byte[]) (pos:int) (len:int): HighPx =
    ReadFieldDecimal bs pos len HighPx.HighPx


let ReadLowPx (bs:byte[]) (pos:int) (len:int): LowPx =
    ReadFieldDecimal bs pos len LowPx.LowPx


let ReadAdjustment (bs:byte[]) (pos:int) (len:int): Adjustment =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> Adjustment.Cancel
    |"2"B -> Adjustment.Error
    |"3"B -> Adjustment.Correction
    | x -> failwith (sprintf "ReadAdjustment unknown fix tag: %A"  x) 


let ReadTradSesReqID (bs:byte[]) (pos:int) (len:int): TradSesReqID =
    ReadFieldStr bs pos len TradSesReqID.TradSesReqID


let ReadTradingSessionID (bs:byte[]) (pos:int) (len:int): TradingSessionID =
    ReadFieldStr bs pos len TradingSessionID.TradingSessionID


let ReadContraTrader (bs:byte[]) (pos:int) (len:int): ContraTrader =
    ReadFieldStr bs pos len ContraTrader.ContraTrader


let ReadTradSesMethod (bs:byte[]) (pos:int) (len:int): TradSesMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> TradSesMethod.Electronic
    |"2"B -> TradSesMethod.OpenOutcry
    |"3"B -> TradSesMethod.TwoParty
    | x -> failwith (sprintf "ReadTradSesMethod unknown fix tag: %A"  x) 


let ReadTradSesMode (bs:byte[]) (pos:int) (len:int): TradSesMode =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> TradSesMode.Testing
    |"2"B -> TradSesMode.Simulated
    |"3"B -> TradSesMode.Production
    | x -> failwith (sprintf "ReadTradSesMode unknown fix tag: %A"  x) 


let ReadTradSesStatus (bs:byte[]) (pos:int) (len:int): TradSesStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradSesStatus.Unknown
    |"1"B -> TradSesStatus.Halted
    |"2"B -> TradSesStatus.Open
    |"3"B -> TradSesStatus.Closed
    |"4"B -> TradSesStatus.PreOpen
    |"5"B -> TradSesStatus.PreClose
    |"6"B -> TradSesStatus.RequestRejected
    | x -> failwith (sprintf "ReadTradSesStatus unknown fix tag: %A"  x) 


let ReadTradSesStartTime (bs:byte[]) (pos:int) (len:int): TradSesStartTime =
    ReadFieldUTCTimestamp bs pos len TradSesStartTime.TradSesStartTime


let ReadTradSesOpenTime (bs:byte[]) (pos:int) (len:int): TradSesOpenTime =
    ReadFieldUTCTimestamp bs pos len TradSesOpenTime.TradSesOpenTime


let ReadTradSesPreCloseTime (bs:byte[]) (pos:int) (len:int): TradSesPreCloseTime =
    ReadFieldUTCTimestamp bs pos len TradSesPreCloseTime.TradSesPreCloseTime


let ReadTradSesCloseTime (bs:byte[]) (pos:int) (len:int): TradSesCloseTime =
    ReadFieldUTCTimestamp bs pos len TradSesCloseTime.TradSesCloseTime


let ReadTradSesEndTime (bs:byte[]) (pos:int) (len:int): TradSesEndTime =
    ReadFieldUTCTimestamp bs pos len TradSesEndTime.TradSesEndTime


let ReadNumberOfOrders (bs:byte[]) (pos:int) (len:int): NumberOfOrders =
    ReadFieldInt bs pos len NumberOfOrders.NumberOfOrders


let ReadMessageEncoding (bs:byte[]) (pos:int) (len:int): MessageEncoding =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"ISO-2022-JP"B -> MessageEncoding.Iso2022Jp
    |"EUC-JP"B -> MessageEncoding.EucJp
    |"SHIFT_JIS"B -> MessageEncoding.ShiftJis
    |"UTF-8"B -> MessageEncoding.Utf8
    | x -> failwith (sprintf "ReadMessageEncoding unknown fix tag: %A"  x) 


// compound read
let ReadEncodedIssuer (bs:byte[]) (pos:int) (len:int): EncodedIssuer =
    ReadLengthDataCompoundField bs pos len "349"B EncodedIssuer.EncodedIssuer


// compound read
let ReadEncodedSecurityDesc (bs:byte[]) (pos:int) (len:int): EncodedSecurityDesc =
    ReadLengthDataCompoundField bs pos len "351"B EncodedSecurityDesc.EncodedSecurityDesc


// compound read
let ReadEncodedListExecInst (bs:byte[]) (pos:int) (len:int): EncodedListExecInst =
    ReadLengthDataCompoundField bs pos len "353"B EncodedListExecInst.EncodedListExecInst


// compound read
let ReadEncodedText (bs:byte[]) (pos:int) (len:int): EncodedText =
    ReadLengthDataCompoundField bs pos len "355"B EncodedText.EncodedText


// compound read
let ReadEncodedSubject (bs:byte[]) (pos:int) (len:int): EncodedSubject =
    ReadLengthDataCompoundField bs pos len "357"B EncodedSubject.EncodedSubject


// compound read
let ReadEncodedHeadline (bs:byte[]) (pos:int) (len:int): EncodedHeadline =
    ReadLengthDataCompoundField bs pos len "359"B EncodedHeadline.EncodedHeadline


// compound read
let ReadEncodedAllocText (bs:byte[]) (pos:int) (len:int): EncodedAllocText =
    ReadLengthDataCompoundField bs pos len "361"B EncodedAllocText.EncodedAllocText


// compound read
let ReadEncodedUnderlyingIssuer (bs:byte[]) (pos:int) (len:int): EncodedUnderlyingIssuer =
    ReadLengthDataCompoundField bs pos len "363"B EncodedUnderlyingIssuer.EncodedUnderlyingIssuer


// compound read
let ReadEncodedUnderlyingSecurityDesc (bs:byte[]) (pos:int) (len:int): EncodedUnderlyingSecurityDesc =
    ReadLengthDataCompoundField bs pos len "365"B EncodedUnderlyingSecurityDesc.EncodedUnderlyingSecurityDesc


let ReadAllocPrice (bs:byte[]) (pos:int) (len:int): AllocPrice =
    ReadFieldDecimal bs pos len AllocPrice.AllocPrice


let ReadQuoteSetValidUntilTime (bs:byte[]) (pos:int) (len:int): QuoteSetValidUntilTime =
    ReadFieldUTCTimestamp bs pos len QuoteSetValidUntilTime.QuoteSetValidUntilTime


let ReadQuoteEntryRejectReason (bs:byte[]) (pos:int) (len:int): QuoteEntryRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuoteEntryRejectReason.UnknownSymbol
    |"2"B -> QuoteEntryRejectReason.ExchangeClosed
    |"3"B -> QuoteEntryRejectReason.QuoteExceedsLimit
    |"4"B -> QuoteEntryRejectReason.TooLateToEnter
    |"5"B -> QuoteEntryRejectReason.UnknownQuote
    |"6"B -> QuoteEntryRejectReason.DuplicateQuote
    |"7"B -> QuoteEntryRejectReason.InvalidBidAskSpread
    |"8"B -> QuoteEntryRejectReason.InvalidPrice
    |"9"B -> QuoteEntryRejectReason.NotAuthorizedToQuoteSecurity
    | x -> failwith (sprintf "ReadQuoteEntryRejectReason unknown fix tag: %A"  x) 


let ReadLastMsgSeqNumProcessed (bs:byte[]) (pos:int) (len:int): LastMsgSeqNumProcessed =
    ReadFieldUInt bs pos len LastMsgSeqNumProcessed.LastMsgSeqNumProcessed


let ReadRefTagID (bs:byte[]) (pos:int) (len:int): RefTagID =
    ReadFieldInt bs pos len RefTagID.RefTagID


let ReadRefMsgType (bs:byte[]) (pos:int) (len:int): RefMsgType =
    ReadFieldStr bs pos len RefMsgType.RefMsgType


let ReadSessionRejectReason (bs:byte[]) (pos:int) (len:int): SessionRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SessionRejectReason.InvalidTagNumber
    |"1"B -> SessionRejectReason.RequiredTagMissing
    |"2"B -> SessionRejectReason.TagNotDefinedForThisMessageType
    |"3"B -> SessionRejectReason.UndefinedTag
    |"4"B -> SessionRejectReason.TagSpecifiedWithoutAValue
    |"5"B -> SessionRejectReason.ValueIsIncorrect
    |"6"B -> SessionRejectReason.IncorrectDataFormatForValue
    |"7"B -> SessionRejectReason.DecryptionProblem
    |"8"B -> SessionRejectReason.SignatureProblem
    |"9"B -> SessionRejectReason.CompidProblem
    |"10"B -> SessionRejectReason.SendingtimeAccuracyProblem
    |"11"B -> SessionRejectReason.InvalidMsgtype
    |"12"B -> SessionRejectReason.XmlValidationError
    |"13"B -> SessionRejectReason.TagAppearsMoreThanOnce
    |"14"B -> SessionRejectReason.TagSpecifiedOutOfRequiredOrder
    |"15"B -> SessionRejectReason.RepeatingGroupFieldsOutOfOrder
    |"16"B -> SessionRejectReason.IncorrectNumingroupCountForRepeatingGroup
    |"17"B -> SessionRejectReason.NonDataValueIncludesFieldDelimiter
    |"99"B -> SessionRejectReason.Other
    | x -> failwith (sprintf "ReadSessionRejectReason unknown fix tag: %A"  x) 


let ReadBidRequestTransType (bs:byte[]) (pos:int) (len:int): BidRequestTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"N"B -> BidRequestTransType.New
    |"C"B -> BidRequestTransType.Cancel
    | x -> failwith (sprintf "ReadBidRequestTransType unknown fix tag: %A"  x) 


let ReadContraBroker (bs:byte[]) (pos:int) (len:int): ContraBroker =
    ReadFieldStr bs pos len ContraBroker.ContraBroker


let ReadComplianceID (bs:byte[]) (pos:int) (len:int): ComplianceID =
    ReadFieldStr bs pos len ComplianceID.ComplianceID


let ReadSolicitedFlag (bs:byte[]) (pos:int) (len:int): SolicitedFlag =
    ReadFieldBool bs pos len SolicitedFlag.SolicitedFlag


let ReadExecRestatementReason (bs:byte[]) (pos:int) (len:int): ExecRestatementReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ExecRestatementReason.GtCorporateAction
    |"1"B -> ExecRestatementReason.GtRenewalRestatement
    |"2"B -> ExecRestatementReason.VerbalChange
    |"3"B -> ExecRestatementReason.RepricingOfOrder
    |"4"B -> ExecRestatementReason.BrokerOption
    |"5"B -> ExecRestatementReason.PartialDeclineOfOrderqty
    |"6"B -> ExecRestatementReason.CancelOnTradingHalt
    |"7"B -> ExecRestatementReason.CancelOnSystemFailure
    |"8"B -> ExecRestatementReason.MarketOption
    |"9"B -> ExecRestatementReason.CanceledNotBest
    | x -> failwith (sprintf "ReadExecRestatementReason unknown fix tag: %A"  x) 


let ReadBusinessRejectRefID (bs:byte[]) (pos:int) (len:int): BusinessRejectRefID =
    ReadFieldStr bs pos len BusinessRejectRefID.BusinessRejectRefID


let ReadBusinessRejectReason (bs:byte[]) (pos:int) (len:int): BusinessRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> BusinessRejectReason.Other
    |"1"B -> BusinessRejectReason.UnkownId
    |"2"B -> BusinessRejectReason.UnknownSecurity
    |"3"B -> BusinessRejectReason.UnsupportedMessageType
    |"4"B -> BusinessRejectReason.ApplicationNotAvailable
    |"5"B -> BusinessRejectReason.ConditionallyRequiredFieldMissing
    |"6"B -> BusinessRejectReason.NotAuthorized
    |"7"B -> BusinessRejectReason.DelivertoFirmNotAvailableAtThisTime
    | x -> failwith (sprintf "ReadBusinessRejectReason unknown fix tag: %A"  x) 


let ReadGrossTradeAmt (bs:byte[]) (pos:int) (len:int): GrossTradeAmt =
    ReadFieldDecimal bs pos len GrossTradeAmt.GrossTradeAmt


let ReadNoContraBrokers (bs:byte[]) (pos:int) (len:int): NoContraBrokers =
    ReadFieldInt bs pos len NoContraBrokers.NoContraBrokers


let ReadMaxMessageSize (bs:byte[]) (pos:int) (len:int): MaxMessageSize =
    ReadFieldUInt bs pos len MaxMessageSize.MaxMessageSize


let ReadNoMsgTypes (bs:byte[]) (pos:int) (len:int): NoMsgTypes =
    ReadFieldInt bs pos len NoMsgTypes.NoMsgTypes


let ReadMsgDirection (bs:byte[]) (pos:int) (len:int): MsgDirection =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"S"B -> MsgDirection.Send
    |"R"B -> MsgDirection.Receive
    | x -> failwith (sprintf "ReadMsgDirection unknown fix tag: %A"  x) 


let ReadNoTradingSessions (bs:byte[]) (pos:int) (len:int): NoTradingSessions =
    ReadFieldInt bs pos len NoTradingSessions.NoTradingSessions


let ReadTotalVolumeTraded (bs:byte[]) (pos:int) (len:int): TotalVolumeTraded =
    ReadFieldDecimal bs pos len TotalVolumeTraded.TotalVolumeTraded


let ReadDiscretionInst (bs:byte[]) (pos:int) (len:int): DiscretionInst =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DiscretionInst.RelatedToDisplayedPrice
    |"1"B -> DiscretionInst.RelatedToMarketPrice
    |"2"B -> DiscretionInst.RelatedToPrimaryPrice
    |"3"B -> DiscretionInst.RelatedToLocalPrimaryPrice
    |"4"B -> DiscretionInst.RelatedToMidpointPrice
    |"5"B -> DiscretionInst.RelatedToLastTradePrice
    |"6"B -> DiscretionInst.RelatedToVwap
    | x -> failwith (sprintf "ReadDiscretionInst unknown fix tag: %A"  x) 


let ReadDiscretionOffsetValue (bs:byte[]) (pos:int) (len:int): DiscretionOffsetValue =
    ReadFieldDecimal bs pos len DiscretionOffsetValue.DiscretionOffsetValue


let ReadBidID (bs:byte[]) (pos:int) (len:int): BidID =
    ReadFieldStr bs pos len BidID.BidID


let ReadClientBidID (bs:byte[]) (pos:int) (len:int): ClientBidID =
    ReadFieldStr bs pos len ClientBidID.ClientBidID


let ReadListName (bs:byte[]) (pos:int) (len:int): ListName =
    ReadFieldStr bs pos len ListName.ListName


let ReadTotNoRelatedSym (bs:byte[]) (pos:int) (len:int): TotNoRelatedSym =
    ReadFieldInt bs pos len TotNoRelatedSym.TotNoRelatedSym


let ReadBidType (bs:byte[]) (pos:int) (len:int): BidType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> BidType.NonDisclosed
    |"2"B -> BidType.DisclosedStyle
    |"3"B -> BidType.NoBiddingProcess
    | x -> failwith (sprintf "ReadBidType unknown fix tag: %A"  x) 


let ReadNumTickets (bs:byte[]) (pos:int) (len:int): NumTickets =
    ReadFieldInt bs pos len NumTickets.NumTickets


let ReadSideValue1 (bs:byte[]) (pos:int) (len:int): SideValue1 =
    ReadFieldDecimal bs pos len SideValue1.SideValue1


let ReadSideValue2 (bs:byte[]) (pos:int) (len:int): SideValue2 =
    ReadFieldDecimal bs pos len SideValue2.SideValue2


let ReadNoBidDescriptors (bs:byte[]) (pos:int) (len:int): NoBidDescriptors =
    ReadFieldInt bs pos len NoBidDescriptors.NoBidDescriptors


let ReadBidDescriptorType (bs:byte[]) (pos:int) (len:int): BidDescriptorType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> BidDescriptorType.Sector
    |"2"B -> BidDescriptorType.Ccountry
    |"3"B -> BidDescriptorType.Index
    | x -> failwith (sprintf "ReadBidDescriptorType unknown fix tag: %A"  x) 


let ReadBidDescriptor (bs:byte[]) (pos:int) (len:int): BidDescriptor =
    ReadFieldStr bs pos len BidDescriptor.BidDescriptor


let ReadSideValueInd (bs:byte[]) (pos:int) (len:int): SideValueInd =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SideValueInd.Sidevalue1
    |"2"B -> SideValueInd.Sidevalue2
    | x -> failwith (sprintf "ReadSideValueInd unknown fix tag: %A"  x) 


let ReadLiquidityPctLow (bs:byte[]) (pos:int) (len:int): LiquidityPctLow =
    ReadFieldDecimal bs pos len LiquidityPctLow.LiquidityPctLow


let ReadLiquidityPctHigh (bs:byte[]) (pos:int) (len:int): LiquidityPctHigh =
    ReadFieldDecimal bs pos len LiquidityPctHigh.LiquidityPctHigh


let ReadLiquidityValue (bs:byte[]) (pos:int) (len:int): LiquidityValue =
    ReadFieldDecimal bs pos len LiquidityValue.LiquidityValue


let ReadEFPTrackingError (bs:byte[]) (pos:int) (len:int): EFPTrackingError =
    ReadFieldDecimal bs pos len EFPTrackingError.EFPTrackingError


let ReadFairValue (bs:byte[]) (pos:int) (len:int): FairValue =
    ReadFieldDecimal bs pos len FairValue.FairValue


let ReadOutsideIndexPct (bs:byte[]) (pos:int) (len:int): OutsideIndexPct =
    ReadFieldDecimal bs pos len OutsideIndexPct.OutsideIndexPct


let ReadValueOfFutures (bs:byte[]) (pos:int) (len:int): ValueOfFutures =
    ReadFieldDecimal bs pos len ValueOfFutures.ValueOfFutures


let ReadLiquidityIndType (bs:byte[]) (pos:int) (len:int): LiquidityIndType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> LiquidityIndType.FivedayMovingAverage
    |"2"B -> LiquidityIndType.TwentydayMovingAverage
    |"3"B -> LiquidityIndType.NormalMarketSize
    |"4"B -> LiquidityIndType.Other
    | x -> failwith (sprintf "ReadLiquidityIndType unknown fix tag: %A"  x) 


let ReadWtAverageLiquidity (bs:byte[]) (pos:int) (len:int): WtAverageLiquidity =
    ReadFieldDecimal bs pos len WtAverageLiquidity.WtAverageLiquidity


let ReadExchangeForPhysical (bs:byte[]) (pos:int) (len:int): ExchangeForPhysical =
    ReadFieldBool bs pos len ExchangeForPhysical.ExchangeForPhysical


let ReadOutMainCntryUIndex (bs:byte[]) (pos:int) (len:int): OutMainCntryUIndex =
    ReadFieldDecimal bs pos len OutMainCntryUIndex.OutMainCntryUIndex


let ReadCrossPercent (bs:byte[]) (pos:int) (len:int): CrossPercent =
    ReadFieldDecimal bs pos len CrossPercent.CrossPercent


let ReadProgRptReqs (bs:byte[]) (pos:int) (len:int): ProgRptReqs =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ProgRptReqs.BuysideExplicitlyRequestsStatusUsingStatusrequest
    |"2"B -> ProgRptReqs.SellsidePeriodicallySendsStatusUsingListstatus
    |"3"B -> ProgRptReqs.RealTimeExecutionReports
    | x -> failwith (sprintf "ReadProgRptReqs unknown fix tag: %A"  x) 


let ReadProgPeriodInterval (bs:byte[]) (pos:int) (len:int): ProgPeriodInterval =
    ReadFieldInt bs pos len ProgPeriodInterval.ProgPeriodInterval


let ReadIncTaxInd (bs:byte[]) (pos:int) (len:int): IncTaxInd =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> IncTaxInd.Net
    |"2"B -> IncTaxInd.Gross
    | x -> failwith (sprintf "ReadIncTaxInd unknown fix tag: %A"  x) 


let ReadNumBidders (bs:byte[]) (pos:int) (len:int): NumBidders =
    ReadFieldInt bs pos len NumBidders.NumBidders


let ReadBidTradeType (bs:byte[]) (pos:int) (len:int): BidTradeType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"R"B -> BidTradeType.RiskTrade
    |"G"B -> BidTradeType.VwapGuarantee
    |"A"B -> BidTradeType.Agency
    |"J"B -> BidTradeType.GuaranteedClose
    | x -> failwith (sprintf "ReadBidTradeType unknown fix tag: %A"  x) 


let ReadBasisPxType (bs:byte[]) (pos:int) (len:int): BasisPxType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"2"B -> BasisPxType.ClosingPriceAtMorningSession
    |"3"B -> BasisPxType.ClosingPrice
    |"4"B -> BasisPxType.CurrentPrice
    |"5"B -> BasisPxType.Sq
    |"6"B -> BasisPxType.VwapThroughADay
    |"7"B -> BasisPxType.VwapThroughAMorningSession
    |"8"B -> BasisPxType.VwapThroughAnAfternoonSession
    |"9"B -> BasisPxType.VwapThroughADayExceptYori
    |"A"B -> BasisPxType.VwapThroughAMorningSessionExceptYori
    |"B"B -> BasisPxType.VwapThroughAnAfternoonSessionExceptYori
    |"C"B -> BasisPxType.Strike
    |"D"B -> BasisPxType.Open
    |"Z"B -> BasisPxType.Others
    | x -> failwith (sprintf "ReadBasisPxType unknown fix tag: %A"  x) 


let ReadNoBidComponents (bs:byte[]) (pos:int) (len:int): NoBidComponents =
    ReadFieldInt bs pos len NoBidComponents.NoBidComponents


let ReadCountry (bs:byte[]) (pos:int) (len:int): Country =
    ReadFieldStr bs pos len Country.Country


let ReadTotNoStrikes (bs:byte[]) (pos:int) (len:int): TotNoStrikes =
    ReadFieldInt bs pos len TotNoStrikes.TotNoStrikes


let ReadPriceType (bs:byte[]) (pos:int) (len:int): PriceType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PriceType.Percentage
    |"2"B -> PriceType.PerUnit
    |"3"B -> PriceType.FixedAmount
    |"4"B -> PriceType.Discount
    |"5"B -> PriceType.Premium
    |"6"B -> PriceType.Spread
    |"7"B -> PriceType.TedPrice
    |"8"B -> PriceType.TedYield
    |"9"B -> PriceType.Yield
    |"10"B -> PriceType.FixedCabinetTradePrice
    |"11"B -> PriceType.VariableCabinetTradePrice
    | x -> failwith (sprintf "ReadPriceType unknown fix tag: %A"  x) 


let ReadDayOrderQty (bs:byte[]) (pos:int) (len:int): DayOrderQty =
    ReadFieldDecimal bs pos len DayOrderQty.DayOrderQty


let ReadDayCumQty (bs:byte[]) (pos:int) (len:int): DayCumQty =
    ReadFieldDecimal bs pos len DayCumQty.DayCumQty


let ReadDayAvgPx (bs:byte[]) (pos:int) (len:int): DayAvgPx =
    ReadFieldDecimal bs pos len DayAvgPx.DayAvgPx


let ReadGTBookingInst (bs:byte[]) (pos:int) (len:int): GTBookingInst =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> GTBookingInst.BookOutAllTradesOnDayOfExecution
    |"1"B -> GTBookingInst.AccumulateExecutionsUntilOrderIsFilledOrExpires
    |"2"B -> GTBookingInst.AccumulateUntilVerballyNotifiedOtherwise
    | x -> failwith (sprintf "ReadGTBookingInst unknown fix tag: %A"  x) 


let ReadNoStrikes (bs:byte[]) (pos:int) (len:int): NoStrikes =
    ReadFieldInt bs pos len NoStrikes.NoStrikes


let ReadListStatusType (bs:byte[]) (pos:int) (len:int): ListStatusType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ListStatusType.Ack
    |"2"B -> ListStatusType.Response
    |"3"B -> ListStatusType.Timed
    |"4"B -> ListStatusType.Execstarted
    |"5"B -> ListStatusType.Alldone
    |"6"B -> ListStatusType.Alert
    | x -> failwith (sprintf "ReadListStatusType unknown fix tag: %A"  x) 


let ReadNetGrossInd (bs:byte[]) (pos:int) (len:int): NetGrossInd =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> NetGrossInd.Net
    |"2"B -> NetGrossInd.Gross
    | x -> failwith (sprintf "ReadNetGrossInd unknown fix tag: %A"  x) 


let ReadListOrderStatus (bs:byte[]) (pos:int) (len:int): ListOrderStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ListOrderStatus.Inbiddingprocess
    |"2"B -> ListOrderStatus.Receivedforexecution
    |"3"B -> ListOrderStatus.Executing
    |"4"B -> ListOrderStatus.Canceling
    |"5"B -> ListOrderStatus.Alert
    |"6"B -> ListOrderStatus.AllDone
    |"7"B -> ListOrderStatus.Reject
    | x -> failwith (sprintf "ReadListOrderStatus unknown fix tag: %A"  x) 


let ReadExpireDate (bs:byte[]) (pos:int) (len:int): ExpireDate =
    ReadFieldLocalMktDate bs pos len ExpireDate.ExpireDate


let ReadListExecInstType (bs:byte[]) (pos:int) (len:int): ListExecInstType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ListExecInstType.Immediate
    |"2"B -> ListExecInstType.WaitForExecuteInstruction
    |"3"B -> ListExecInstType.ExchangeSwitchCivOrderSellDriven
    |"4"B -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashTopUp
    |"5"B -> ListExecInstType.ExchangeSwitchCivOrderBuyDrivenCashWithdraw
    | x -> failwith (sprintf "ReadListExecInstType unknown fix tag: %A"  x) 


let ReadCxlRejResponseTo (bs:byte[]) (pos:int) (len:int): CxlRejResponseTo =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> CxlRejResponseTo.OrderCancelRequest
    |"2"B -> CxlRejResponseTo.OrderCancelReplaceRequest
    | x -> failwith (sprintf "ReadCxlRejResponseTo unknown fix tag: %A"  x) 


let ReadUnderlyingCouponRate (bs:byte[]) (pos:int) (len:int): UnderlyingCouponRate =
    ReadFieldDecimal bs pos len UnderlyingCouponRate.UnderlyingCouponRate


let ReadUnderlyingContractMultiplier (bs:byte[]) (pos:int) (len:int): UnderlyingContractMultiplier =
    ReadFieldDecimal bs pos len UnderlyingContractMultiplier.UnderlyingContractMultiplier


let ReadContraTradeQty (bs:byte[]) (pos:int) (len:int): ContraTradeQty =
    ReadFieldDecimal bs pos len ContraTradeQty.ContraTradeQty


let ReadContraTradeTime (bs:byte[]) (pos:int) (len:int): ContraTradeTime =
    ReadFieldUTCTimestamp bs pos len ContraTradeTime.ContraTradeTime


let ReadLiquidityNumSecurities (bs:byte[]) (pos:int) (len:int): LiquidityNumSecurities =
    ReadFieldInt bs pos len LiquidityNumSecurities.LiquidityNumSecurities


let ReadMultiLegReportingType (bs:byte[]) (pos:int) (len:int): MultiLegReportingType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> MultiLegReportingType.SingleSecurity
    |"2"B -> MultiLegReportingType.IndividualLegOfAMultiLegSecurity
    |"3"B -> MultiLegReportingType.MultiLegSecurity
    | x -> failwith (sprintf "ReadMultiLegReportingType unknown fix tag: %A"  x) 


let ReadStrikeTime (bs:byte[]) (pos:int) (len:int): StrikeTime =
    ReadFieldUTCTimestamp bs pos len StrikeTime.StrikeTime


let ReadListStatusText (bs:byte[]) (pos:int) (len:int): ListStatusText =
    ReadFieldStr bs pos len ListStatusText.ListStatusText


// compound read
let ReadEncodedListStatusText (bs:byte[]) (pos:int) (len:int): EncodedListStatusText =
    ReadLengthDataCompoundField bs pos len "446"B EncodedListStatusText.EncodedListStatusText


let ReadPartyIDSource (bs:byte[]) (pos:int) (len:int): PartyIDSource =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"B"B -> PartyIDSource.Bic
    |"C"B -> PartyIDSource.GenerallyAcceptedMarketParticipantIdentifier
    |"D"B -> PartyIDSource.ProprietaryCustomCode
    |"E"B -> PartyIDSource.IsoCountryCode
    |"F"B -> PartyIDSource.SettlementEntityLocation
    |"G"B -> PartyIDSource.Mic
    |"H"B -> PartyIDSource.CsdParticipantMemberCode
    |"1"B -> PartyIDSource.KoreanInvestorId
    |"2"B -> PartyIDSource.TaiwaneseQualifiedForeignInvestorIdQfiiFid
    |"3"B -> PartyIDSource.TaiwaneseTradingAccount
    |"4"B -> PartyIDSource.MalaysianCentralDepositoryNumber
    |"5"B -> PartyIDSource.ChineseBShare
    |"6"B -> PartyIDSource.UkNationalInsuranceOrPensionNumber
    |"7"B -> PartyIDSource.UsSocialSecurityNumber
    |"8"B -> PartyIDSource.UsEmployerIdentificationNumber
    |"9"B -> PartyIDSource.AustralianBusinessNumber
    |"A"B -> PartyIDSource.AustralianTaxFileNumber
    |"I"B -> PartyIDSource.DirectedBroker
    | x -> failwith (sprintf "ReadPartyIDSource unknown fix tag: %A"  x) 


let ReadPartyID (bs:byte[]) (pos:int) (len:int): PartyID =
    ReadFieldStr bs pos len PartyID.PartyID


let ReadNetChgPrevDay (bs:byte[]) (pos:int) (len:int): NetChgPrevDay =
    ReadFieldDecimal bs pos len NetChgPrevDay.NetChgPrevDay


let ReadPartyRole (bs:byte[]) (pos:int) (len:int): PartyRole =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PartyRole.ExecutingFirm
    |"2"B -> PartyRole.BrokerOfCredit
    |"3"B -> PartyRole.ClientId
    |"4"B -> PartyRole.ClearingFirm
    |"5"B -> PartyRole.InvestorId
    |"6"B -> PartyRole.IntroducingFirm
    |"7"B -> PartyRole.EnteringFirm
    |"8"B -> PartyRole.LocateLendingFirm
    |"9"B -> PartyRole.FundManagerClientId
    |"10"B -> PartyRole.SettlementLocation
    |"11"B -> PartyRole.OrderOriginationTrader
    |"12"B -> PartyRole.ExecutingTrader
    |"13"B -> PartyRole.OrderOriginationFirm
    |"14"B -> PartyRole.GiveupClearingFirm
    |"15"B -> PartyRole.CorrespondantClearingFirm
    |"16"B -> PartyRole.ExecutingSystem
    |"17"B -> PartyRole.ContraFirm
    |"18"B -> PartyRole.ContraClearingFirm
    |"19"B -> PartyRole.SponsoringFirm
    |"20"B -> PartyRole.UnderlyingContraFirm
    |"21"B -> PartyRole.ClearingOrganization
    |"22"B -> PartyRole.Exchange
    |"24"B -> PartyRole.CustomerAccount
    |"25"B -> PartyRole.CorrespondentClearingOrganization
    |"26"B -> PartyRole.CorrespondentBroker
    |"27"B -> PartyRole.BuyerSeller
    |"28"B -> PartyRole.Custodian
    |"29"B -> PartyRole.Intermediary
    |"30"B -> PartyRole.Agent
    |"31"B -> PartyRole.SubCustodian
    |"32"B -> PartyRole.Beneficiary
    |"33"B -> PartyRole.InterestedParty
    |"34"B -> PartyRole.RegulatoryBody
    |"35"B -> PartyRole.LiquidityProvider
    |"36"B -> PartyRole.EnteringTrader
    |"37"B -> PartyRole.ContraTrader
    |"38"B -> PartyRole.PositionAccount
    | x -> failwith (sprintf "ReadPartyRole unknown fix tag: %A"  x) 


let ReadNoPartyIDs (bs:byte[]) (pos:int) (len:int): NoPartyIDs =
    ReadFieldInt bs pos len NoPartyIDs.NoPartyIDs


let ReadNoSecurityAltID (bs:byte[]) (pos:int) (len:int): NoSecurityAltID =
    ReadFieldInt bs pos len NoSecurityAltID.NoSecurityAltID


let ReadSecurityAltID (bs:byte[]) (pos:int) (len:int): SecurityAltID =
    ReadFieldStr bs pos len SecurityAltID.SecurityAltID


let ReadSecurityAltIDSource (bs:byte[]) (pos:int) (len:int): SecurityAltIDSource =
    ReadFieldStr bs pos len SecurityAltIDSource.SecurityAltIDSource


let ReadNoUnderlyingSecurityAltID (bs:byte[]) (pos:int) (len:int): NoUnderlyingSecurityAltID =
    ReadFieldInt bs pos len NoUnderlyingSecurityAltID.NoUnderlyingSecurityAltID


let ReadUnderlyingSecurityAltID (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityAltID =
    ReadFieldStr bs pos len UnderlyingSecurityAltID.UnderlyingSecurityAltID


let ReadUnderlyingSecurityAltIDSource (bs:byte[]) (pos:int) (len:int): UnderlyingSecurityAltIDSource =
    ReadFieldStr bs pos len UnderlyingSecurityAltIDSource.UnderlyingSecurityAltIDSource


let ReadProduct (bs:byte[]) (pos:int) (len:int): Product =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> Product.Agency
    |"2"B -> Product.Commodity
    |"3"B -> Product.Corporate
    |"4"B -> Product.Currency
    |"5"B -> Product.Equity
    |"6"B -> Product.Government
    |"7"B -> Product.Index
    |"8"B -> Product.Loan
    |"9"B -> Product.Moneymarket
    |"10"B -> Product.Mortgage
    |"11"B -> Product.Municipal
    |"12"B -> Product.Other
    |"13"B -> Product.Financing
    | x -> failwith (sprintf "ReadProduct unknown fix tag: %A"  x) 


let ReadCFICode (bs:byte[]) (pos:int) (len:int): CFICode =
    ReadFieldStr bs pos len CFICode.CFICode


let ReadUnderlyingProduct (bs:byte[]) (pos:int) (len:int): UnderlyingProduct =
    ReadFieldInt bs pos len UnderlyingProduct.UnderlyingProduct


let ReadUnderlyingCFICode (bs:byte[]) (pos:int) (len:int): UnderlyingCFICode =
    ReadFieldStr bs pos len UnderlyingCFICode.UnderlyingCFICode


let ReadTestMessageIndicator (bs:byte[]) (pos:int) (len:int): TestMessageIndicator =
    ReadFieldBool bs pos len TestMessageIndicator.TestMessageIndicator


let ReadQuantityType (bs:byte[]) (pos:int) (len:int): QuantityType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuantityType.Shares
    |"2"B -> QuantityType.Bonds
    |"3"B -> QuantityType.Currentface
    |"4"B -> QuantityType.Originalface
    |"5"B -> QuantityType.Currency
    |"6"B -> QuantityType.Contracts
    |"7"B -> QuantityType.Other
    |"8"B -> QuantityType.Par
    | x -> failwith (sprintf "ReadQuantityType unknown fix tag: %A"  x) 


let ReadBookingRefID (bs:byte[]) (pos:int) (len:int): BookingRefID =
    ReadFieldStr bs pos len BookingRefID.BookingRefID


let ReadIndividualAllocID (bs:byte[]) (pos:int) (len:int): IndividualAllocID =
    ReadFieldStr bs pos len IndividualAllocID.IndividualAllocID


let ReadRoundingDirection (bs:byte[]) (pos:int) (len:int): RoundingDirection =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> RoundingDirection.RoundToNearest
    |"1"B -> RoundingDirection.RoundDown
    |"2"B -> RoundingDirection.RoundUp
    | x -> failwith (sprintf "ReadRoundingDirection unknown fix tag: %A"  x) 


let ReadRoundingModulus (bs:byte[]) (pos:int) (len:int): RoundingModulus =
    ReadFieldDecimal bs pos len RoundingModulus.RoundingModulus


let ReadCountryOfIssue (bs:byte[]) (pos:int) (len:int): CountryOfIssue =
    ReadFieldStr bs pos len CountryOfIssue.CountryOfIssue


let ReadStateOrProvinceOfIssue (bs:byte[]) (pos:int) (len:int): StateOrProvinceOfIssue =
    ReadFieldStr bs pos len StateOrProvinceOfIssue.StateOrProvinceOfIssue


let ReadLocaleOfIssue (bs:byte[]) (pos:int) (len:int): LocaleOfIssue =
    ReadFieldStr bs pos len LocaleOfIssue.LocaleOfIssue


let ReadNoRegistDtls (bs:byte[]) (pos:int) (len:int): NoRegistDtls =
    ReadFieldInt bs pos len NoRegistDtls.NoRegistDtls


let ReadMailingDtls (bs:byte[]) (pos:int) (len:int): MailingDtls =
    ReadFieldStr bs pos len MailingDtls.MailingDtls


let ReadInvestorCountryOfResidence (bs:byte[]) (pos:int) (len:int): InvestorCountryOfResidence =
    ReadFieldStr bs pos len InvestorCountryOfResidence.InvestorCountryOfResidence


let ReadPaymentRef (bs:byte[]) (pos:int) (len:int): PaymentRef =
    ReadFieldStr bs pos len PaymentRef.PaymentRef


let ReadDistribPaymentMethod (bs:byte[]) (pos:int) (len:int): DistribPaymentMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> DistribPaymentMethod.Crest
    |"2"B -> DistribPaymentMethod.Nscc
    |"3"B -> DistribPaymentMethod.Euroclear
    |"4"B -> DistribPaymentMethod.Clearstream
    |"5"B -> DistribPaymentMethod.Cheque
    |"6"B -> DistribPaymentMethod.TelegraphicTransfer
    |"7"B -> DistribPaymentMethod.Fedwire
    |"8"B -> DistribPaymentMethod.DirectCredit
    |"9"B -> DistribPaymentMethod.AchCredit
    |"10"B -> DistribPaymentMethod.Bpay
    |"11"B -> DistribPaymentMethod.HighValueClearingSystem
    |"12"B -> DistribPaymentMethod.ReinvestInFund
    | x -> failwith (sprintf "ReadDistribPaymentMethod unknown fix tag: %A"  x) 


let ReadCashDistribCurr (bs:byte[]) (pos:int) (len:int): CashDistribCurr =
    ReadFieldStr bs pos len CashDistribCurr.CashDistribCurr


let ReadCommCurrency (bs:byte[]) (pos:int) (len:int): CommCurrency =
    ReadFieldStr bs pos len CommCurrency.CommCurrency


let ReadCancellationRights (bs:byte[]) (pos:int) (len:int): CancellationRights =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"Y"B -> CancellationRights.Yes
    |"N"B -> CancellationRights.NoExecutionOnly
    |"M"B -> CancellationRights.NoWaiverAgreement
    |"O"B -> CancellationRights.NoInstitutional
    | x -> failwith (sprintf "ReadCancellationRights unknown fix tag: %A"  x) 


let ReadMoneyLaunderingStatus (bs:byte[]) (pos:int) (len:int): MoneyLaunderingStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"Y"B -> MoneyLaunderingStatus.Passed
    |"N"B -> MoneyLaunderingStatus.NotChecked
    |"1"B -> MoneyLaunderingStatus.ExemptBelowTheLimit
    |"2"B -> MoneyLaunderingStatus.ExemptClientMoneyTypeExemption
    |"3"B -> MoneyLaunderingStatus.ExemptAuthorisedCreditOrFinancialInstitution
    | x -> failwith (sprintf "ReadMoneyLaunderingStatus unknown fix tag: %A"  x) 


let ReadMailingInst (bs:byte[]) (pos:int) (len:int): MailingInst =
    ReadFieldStr bs pos len MailingInst.MailingInst


let ReadTransBkdTime (bs:byte[]) (pos:int) (len:int): TransBkdTime =
    ReadFieldUTCTimestamp bs pos len TransBkdTime.TransBkdTime


let ReadExecPriceType (bs:byte[]) (pos:int) (len:int): ExecPriceType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"B"B -> ExecPriceType.BidPrice
    |"C"B -> ExecPriceType.CreationPrice
    |"D"B -> ExecPriceType.CreationPricePlusAdjustmentPercent
    |"E"B -> ExecPriceType.CreationPricePlusAdjustmentAmount
    |"O"B -> ExecPriceType.OfferPrice
    |"P"B -> ExecPriceType.OfferPriceMinusAdjustmentPercent
    |"Q"B -> ExecPriceType.OfferPriceMinusAdjustmentAmount
    |"S"B -> ExecPriceType.SinglePrice
    | x -> failwith (sprintf "ReadExecPriceType unknown fix tag: %A"  x) 


let ReadExecPriceAdjustment (bs:byte[]) (pos:int) (len:int): ExecPriceAdjustment =
    ReadFieldDecimal bs pos len ExecPriceAdjustment.ExecPriceAdjustment


let ReadDateOfBirth (bs:byte[]) (pos:int) (len:int): DateOfBirth =
    ReadFieldLocalMktDate bs pos len DateOfBirth.DateOfBirth


let ReadTradeReportTransType (bs:byte[]) (pos:int) (len:int): TradeReportTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeReportTransType.New
    |"1"B -> TradeReportTransType.Cancel
    |"2"B -> TradeReportTransType.Replace
    |"3"B -> TradeReportTransType.Release
    |"4"B -> TradeReportTransType.Reverse
    | x -> failwith (sprintf "ReadTradeReportTransType unknown fix tag: %A"  x) 


let ReadCardHolderName (bs:byte[]) (pos:int) (len:int): CardHolderName =
    ReadFieldStr bs pos len CardHolderName.CardHolderName


let ReadCardNumber (bs:byte[]) (pos:int) (len:int): CardNumber =
    ReadFieldStr bs pos len CardNumber.CardNumber


let ReadCardExpDate (bs:byte[]) (pos:int) (len:int): CardExpDate =
    ReadFieldLocalMktDate bs pos len CardExpDate.CardExpDate


let ReadCardIssNum (bs:byte[]) (pos:int) (len:int): CardIssNum =
    ReadFieldStr bs pos len CardIssNum.CardIssNum


let ReadPaymentMethod (bs:byte[]) (pos:int) (len:int): PaymentMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PaymentMethod.Crest
    |"2"B -> PaymentMethod.Nscc
    |"3"B -> PaymentMethod.Euroclear
    |"4"B -> PaymentMethod.Clearstream
    |"5"B -> PaymentMethod.Cheque
    |"6"B -> PaymentMethod.TelegraphicTransfer
    |"7"B -> PaymentMethod.Fedwire
    |"8"B -> PaymentMethod.DebitCard
    |"9"B -> PaymentMethod.DirectDebit
    |"10"B -> PaymentMethod.DirectCredit
    |"11"B -> PaymentMethod.CreditCard
    |"12"B -> PaymentMethod.AchDebit
    |"13"B -> PaymentMethod.AchCredit
    |"14"B -> PaymentMethod.Bpay
    |"15"B -> PaymentMethod.HighValueClearingSystem
    | x -> failwith (sprintf "ReadPaymentMethod unknown fix tag: %A"  x) 


let ReadRegistAcctType (bs:byte[]) (pos:int) (len:int): RegistAcctType =
    ReadFieldStr bs pos len RegistAcctType.RegistAcctType


let ReadDesignation (bs:byte[]) (pos:int) (len:int): Designation =
    ReadFieldStr bs pos len Designation.Designation


let ReadTaxAdvantageType (bs:byte[]) (pos:int) (len:int): TaxAdvantageType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TaxAdvantageType.NNone
    |"1"B -> TaxAdvantageType.MaxiIsa
    |"2"B -> TaxAdvantageType.Tessa
    |"3"B -> TaxAdvantageType.MiniCashIsa
    |"4"B -> TaxAdvantageType.MiniStocksAndSharesIsa
    |"5"B -> TaxAdvantageType.MiniInsuranceIsa
    |"6"B -> TaxAdvantageType.CurrentYearPayment
    |"7"B -> TaxAdvantageType.PriorYearPayment
    |"8"B -> TaxAdvantageType.AssetTransfer
    |"9"B -> TaxAdvantageType.EmployeePriorYear
    |"999"B -> TaxAdvantageType.Other
    | x -> failwith (sprintf "ReadTaxAdvantageType unknown fix tag: %A"  x) 


let ReadRegistRejReasonText (bs:byte[]) (pos:int) (len:int): RegistRejReasonText =
    ReadFieldStr bs pos len RegistRejReasonText.RegistRejReasonText


let ReadFundRenewWaiv (bs:byte[]) (pos:int) (len:int): FundRenewWaiv =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"Y"B -> FundRenewWaiv.Yes
    |"N"B -> FundRenewWaiv.No
    | x -> failwith (sprintf "ReadFundRenewWaiv unknown fix tag: %A"  x) 


let ReadCashDistribAgentName (bs:byte[]) (pos:int) (len:int): CashDistribAgentName =
    ReadFieldStr bs pos len CashDistribAgentName.CashDistribAgentName


let ReadCashDistribAgentCode (bs:byte[]) (pos:int) (len:int): CashDistribAgentCode =
    ReadFieldStr bs pos len CashDistribAgentCode.CashDistribAgentCode


let ReadCashDistribAgentAcctNumber (bs:byte[]) (pos:int) (len:int): CashDistribAgentAcctNumber =
    ReadFieldStr bs pos len CashDistribAgentAcctNumber.CashDistribAgentAcctNumber


let ReadCashDistribPayRef (bs:byte[]) (pos:int) (len:int): CashDistribPayRef =
    ReadFieldStr bs pos len CashDistribPayRef.CashDistribPayRef


let ReadCashDistribAgentAcctName (bs:byte[]) (pos:int) (len:int): CashDistribAgentAcctName =
    ReadFieldStr bs pos len CashDistribAgentAcctName.CashDistribAgentAcctName


let ReadCardStartDate (bs:byte[]) (pos:int) (len:int): CardStartDate =
    ReadFieldLocalMktDate bs pos len CardStartDate.CardStartDate


let ReadPaymentDate (bs:byte[]) (pos:int) (len:int): PaymentDate =
    ReadFieldLocalMktDate bs pos len PaymentDate.PaymentDate


let ReadPaymentRemitterID (bs:byte[]) (pos:int) (len:int): PaymentRemitterID =
    ReadFieldStr bs pos len PaymentRemitterID.PaymentRemitterID


let ReadRegistStatus (bs:byte[]) (pos:int) (len:int): RegistStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> RegistStatus.Accepted
    |"R"B -> RegistStatus.Rejected
    |"H"B -> RegistStatus.Held
    |"N"B -> RegistStatus.Reminder
    | x -> failwith (sprintf "ReadRegistStatus unknown fix tag: %A"  x) 


let ReadRegistRejReasonCode (bs:byte[]) (pos:int) (len:int): RegistRejReasonCode =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> RegistRejReasonCode.InvalidUnacceptableAccountType
    |"2"B -> RegistRejReasonCode.InvalidUnacceptableTaxExemptType
    |"3"B -> RegistRejReasonCode.InvalidUnacceptableOwnershipType
    |"4"B -> RegistRejReasonCode.InvalidUnacceptableNoRegDetls
    |"5"B -> RegistRejReasonCode.InvalidUnacceptableRegSeqNo
    |"6"B -> RegistRejReasonCode.InvalidUnacceptableRegDtls
    |"7"B -> RegistRejReasonCode.InvalidUnacceptableMailingDtls
    |"8"B -> RegistRejReasonCode.InvalidUnacceptableMailingInst
    |"9"B -> RegistRejReasonCode.InvalidUnacceptableInvestorId
    |"10"B -> RegistRejReasonCode.InvalidUnacceptableInvestorIdSource
    |"11"B -> RegistRejReasonCode.InvalidUnacceptableDateOfBirth
    |"12"B -> RegistRejReasonCode.InvalidUnacceptableInvestorCountryOfResidence
    |"13"B -> RegistRejReasonCode.InvalidUnacceptableNodistribinstns
    |"14"B -> RegistRejReasonCode.InvalidUnacceptableDistribPercentage
    |"15"B -> RegistRejReasonCode.InvalidUnacceptableDistribPaymentMethod
    |"16"B -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctName
    |"17"B -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentCode
    |"18"B -> RegistRejReasonCode.InvalidUnacceptableCashDistribAgentAcctNum
    |"99"B -> RegistRejReasonCode.Other
    | x -> failwith (sprintf "ReadRegistRejReasonCode unknown fix tag: %A"  x) 


let ReadRegistRefID (bs:byte[]) (pos:int) (len:int): RegistRefID =
    ReadFieldStr bs pos len RegistRefID.RegistRefID


let ReadRegistDtls (bs:byte[]) (pos:int) (len:int): RegistDtls =
    ReadFieldStr bs pos len RegistDtls.RegistDtls


let ReadNoDistribInsts (bs:byte[]) (pos:int) (len:int): NoDistribInsts =
    ReadFieldInt bs pos len NoDistribInsts.NoDistribInsts


let ReadRegistEmail (bs:byte[]) (pos:int) (len:int): RegistEmail =
    ReadFieldStr bs pos len RegistEmail.RegistEmail


let ReadDistribPercentage (bs:byte[]) (pos:int) (len:int): DistribPercentage =
    ReadFieldDecimal bs pos len DistribPercentage.DistribPercentage


let ReadRegistID (bs:byte[]) (pos:int) (len:int): RegistID =
    ReadFieldStr bs pos len RegistID.RegistID


let ReadRegistTransType (bs:byte[]) (pos:int) (len:int): RegistTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> RegistTransType.New
    |"1"B -> RegistTransType.Replace
    |"2"B -> RegistTransType.Cancel
    | x -> failwith (sprintf "ReadRegistTransType unknown fix tag: %A"  x) 


let ReadExecValuationPoint (bs:byte[]) (pos:int) (len:int): ExecValuationPoint =
    ReadFieldUTCTimestamp bs pos len ExecValuationPoint.ExecValuationPoint


let ReadOrderPercent (bs:byte[]) (pos:int) (len:int): OrderPercent =
    ReadFieldDecimal bs pos len OrderPercent.OrderPercent


let ReadOwnershipType (bs:byte[]) (pos:int) (len:int): OwnershipType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"J"B -> OwnershipType.JointInvestors
    |"T"B -> OwnershipType.TenantsInCommon
    |"2"B -> OwnershipType.JointTrustees
    | x -> failwith (sprintf "ReadOwnershipType unknown fix tag: %A"  x) 


let ReadNoContAmts (bs:byte[]) (pos:int) (len:int): NoContAmts =
    ReadFieldInt bs pos len NoContAmts.NoContAmts


let ReadContAmtType (bs:byte[]) (pos:int) (len:int): ContAmtType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ContAmtType.CommissionAmount
    |"2"B -> ContAmtType.CommissionPercent
    |"3"B -> ContAmtType.InitialChargeAmount
    |"4"B -> ContAmtType.InitialChargePercent
    |"5"B -> ContAmtType.DiscountAmount
    |"6"B -> ContAmtType.DiscountPercent
    |"7"B -> ContAmtType.DilutionLevyAmount
    |"8"B -> ContAmtType.DilutionLevyPercent
    |"9"B -> ContAmtType.ExitChargeAmount
    | x -> failwith (sprintf "ReadContAmtType unknown fix tag: %A"  x) 


let ReadContAmtValue (bs:byte[]) (pos:int) (len:int): ContAmtValue =
    ReadFieldDecimal bs pos len ContAmtValue.ContAmtValue


let ReadContAmtCurr (bs:byte[]) (pos:int) (len:int): ContAmtCurr =
    ReadFieldStr bs pos len ContAmtCurr.ContAmtCurr


let ReadOwnerType (bs:byte[]) (pos:int) (len:int): OwnerType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> OwnerType.IndividualInvestor
    |"2"B -> OwnerType.PublicCompany
    |"3"B -> OwnerType.PrivateCompany
    |"4"B -> OwnerType.IndividualTrustee
    |"5"B -> OwnerType.CompanyTrustee
    |"6"B -> OwnerType.PensionPlan
    |"7"B -> OwnerType.CustodianUnderGiftsToMinorsAct
    |"8"B -> OwnerType.Trusts
    |"9"B -> OwnerType.Fiduciaries
    |"10"B -> OwnerType.NetworkingSubAccount
    |"11"B -> OwnerType.NonProfitOrganization
    |"12"B -> OwnerType.CorporateBody
    |"13"B -> OwnerType.Nominee
    | x -> failwith (sprintf "ReadOwnerType unknown fix tag: %A"  x) 


let ReadPartySubID (bs:byte[]) (pos:int) (len:int): PartySubID =
    ReadFieldStr bs pos len PartySubID.PartySubID


let ReadNestedPartyID (bs:byte[]) (pos:int) (len:int): NestedPartyID =
    ReadFieldStr bs pos len NestedPartyID.NestedPartyID


let ReadNestedPartyIDSource (bs:byte[]) (pos:int) (len:int): NestedPartyIDSource =
    ReadFieldChar bs pos len NestedPartyIDSource.NestedPartyIDSource


let ReadSecondaryClOrdID (bs:byte[]) (pos:int) (len:int): SecondaryClOrdID =
    ReadFieldStr bs pos len SecondaryClOrdID.SecondaryClOrdID


let ReadSecondaryExecID (bs:byte[]) (pos:int) (len:int): SecondaryExecID =
    ReadFieldStr bs pos len SecondaryExecID.SecondaryExecID


let ReadOrderCapacity (bs:byte[]) (pos:int) (len:int): OrderCapacity =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> OrderCapacity.Agency
    |"G"B -> OrderCapacity.Proprietary
    |"I"B -> OrderCapacity.Individual
    |"P"B -> OrderCapacity.Principal
    |"R"B -> OrderCapacity.RisklessPrincipal
    |"W"B -> OrderCapacity.AgentForOtherMember
    | x -> failwith (sprintf "ReadOrderCapacity unknown fix tag: %A"  x) 


let ReadOrderRestrictions (bs:byte[]) (pos:int) (len:int): OrderRestrictions =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> OrderRestrictions.ProgramTrade
    |"2"B -> OrderRestrictions.IndexArbitrage
    |"3"B -> OrderRestrictions.NonIndexArbitrage
    |"4"B -> OrderRestrictions.CompetingMarketMaker
    |"5"B -> OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheSecurity
    |"6"B -> OrderRestrictions.ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity
    |"7"B -> OrderRestrictions.ForeignEntity
    |"8"B -> OrderRestrictions.ExternalMarketParticipant
    |"9"B -> OrderRestrictions.ExternalInterConnectedMarketLinkage
    |"A"B -> OrderRestrictions.RisklessArbitrage
    | x -> failwith (sprintf "ReadOrderRestrictions unknown fix tag: %A"  x) 


let ReadMassCancelRequestType (bs:byte[]) (pos:int) (len:int): MassCancelRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> MassCancelRequestType.CancelOrdersForASecurity
    |"2"B -> MassCancelRequestType.CancelOrdersForAnUnderlyingSecurity
    |"3"B -> MassCancelRequestType.CancelOrdersForAProduct
    |"4"B -> MassCancelRequestType.CancelOrdersForACficode
    |"5"B -> MassCancelRequestType.CancelOrdersForASecuritytype
    |"6"B -> MassCancelRequestType.CancelOrdersForATradingSession
    |"7"B -> MassCancelRequestType.CancelAllOrders
    | x -> failwith (sprintf "ReadMassCancelRequestType unknown fix tag: %A"  x) 


let ReadMassCancelResponse (bs:byte[]) (pos:int) (len:int): MassCancelResponse =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MassCancelResponse.CancelRequestRejected
    |"1"B -> MassCancelResponse.CancelOrdersForASecurity
    |"2"B -> MassCancelResponse.CancelOrdersForAnUnderlyingSecurity
    |"3"B -> MassCancelResponse.CancelOrdersForAProduct
    |"4"B -> MassCancelResponse.CancelOrdersForACficode
    |"5"B -> MassCancelResponse.CancelOrdersForASecuritytype
    |"6"B -> MassCancelResponse.CancelOrdersForATradingSession
    |"7"B -> MassCancelResponse.CancelAllOrders
    | x -> failwith (sprintf "ReadMassCancelResponse unknown fix tag: %A"  x) 


let ReadMassCancelRejectReason (bs:byte[]) (pos:int) (len:int): MassCancelRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MassCancelRejectReason.MassCancelNotSupported
    |"1"B -> MassCancelRejectReason.InvalidOrUnknownSecurity
    |"2"B -> MassCancelRejectReason.InvalidOrUnknownUnderlying
    |"3"B -> MassCancelRejectReason.InvalidOrUnknownProduct
    |"4"B -> MassCancelRejectReason.InvalidOrUnknownCficode
    |"5"B -> MassCancelRejectReason.InvalidOrUnknownSecurityType
    |"6"B -> MassCancelRejectReason.InvalidOrUnknownTradingSession
    |"99"B -> MassCancelRejectReason.Other
    | x -> failwith (sprintf "ReadMassCancelRejectReason unknown fix tag: %A"  x) 


let ReadTotalAffectedOrders (bs:byte[]) (pos:int) (len:int): TotalAffectedOrders =
    ReadFieldInt bs pos len TotalAffectedOrders.TotalAffectedOrders


let ReadNoAffectedOrders (bs:byte[]) (pos:int) (len:int): NoAffectedOrders =
    ReadFieldInt bs pos len NoAffectedOrders.NoAffectedOrders


let ReadAffectedOrderID (bs:byte[]) (pos:int) (len:int): AffectedOrderID =
    ReadFieldStr bs pos len AffectedOrderID.AffectedOrderID


let ReadAffectedSecondaryOrderID (bs:byte[]) (pos:int) (len:int): AffectedSecondaryOrderID =
    ReadFieldStr bs pos len AffectedSecondaryOrderID.AffectedSecondaryOrderID


let ReadQuoteType (bs:byte[]) (pos:int) (len:int): QuoteType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> QuoteType.Indicative
    |"1"B -> QuoteType.Tradeable
    |"2"B -> QuoteType.RestrictedTradeable
    |"3"B -> QuoteType.Counter
    | x -> failwith (sprintf "ReadQuoteType unknown fix tag: %A"  x) 


let ReadNestedPartyRole (bs:byte[]) (pos:int) (len:int): NestedPartyRole =
    ReadFieldInt bs pos len NestedPartyRole.NestedPartyRole


let ReadNoNestedPartyIDs (bs:byte[]) (pos:int) (len:int): NoNestedPartyIDs =
    ReadFieldInt bs pos len NoNestedPartyIDs.NoNestedPartyIDs


let ReadTotalAccruedInterestAmt (bs:byte[]) (pos:int) (len:int): TotalAccruedInterestAmt =
    ReadFieldDecimal bs pos len TotalAccruedInterestAmt.TotalAccruedInterestAmt


let ReadMaturityDate (bs:byte[]) (pos:int) (len:int): MaturityDate =
    ReadFieldLocalMktDate bs pos len MaturityDate.MaturityDate


let ReadUnderlyingMaturityDate (bs:byte[]) (pos:int) (len:int): UnderlyingMaturityDate =
    ReadFieldLocalMktDate bs pos len UnderlyingMaturityDate.UnderlyingMaturityDate


let ReadInstrRegistry (bs:byte[]) (pos:int) (len:int): InstrRegistry =
    ReadFieldStr bs pos len InstrRegistry.InstrRegistry


let ReadCashMargin (bs:byte[]) (pos:int) (len:int): CashMargin =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> CashMargin.Cash
    |"2"B -> CashMargin.MarginOpen
    |"3"B -> CashMargin.MarginClose
    | x -> failwith (sprintf "ReadCashMargin unknown fix tag: %A"  x) 


let ReadNestedPartySubID (bs:byte[]) (pos:int) (len:int): NestedPartySubID =
    ReadFieldStr bs pos len NestedPartySubID.NestedPartySubID


let ReadScope (bs:byte[]) (pos:int) (len:int): Scope =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> Scope.Local
    |"2"B -> Scope.National
    |"3"B -> Scope.Global
    | x -> failwith (sprintf "ReadScope unknown fix tag: %A"  x) 


let ReadMDImplicitDelete (bs:byte[]) (pos:int) (len:int): MDImplicitDelete =
    ReadFieldBool bs pos len MDImplicitDelete.MDImplicitDelete


let ReadCrossID (bs:byte[]) (pos:int) (len:int): CrossID =
    ReadFieldStr bs pos len CrossID.CrossID


let ReadCrossType (bs:byte[]) (pos:int) (len:int): CrossType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> CrossType.CrossTradeWhichIsExecutedCompletelyOrNot
    |"2"B -> CrossType.CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled
    |"3"B -> CrossType.CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive
    |"4"B -> CrossType.CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice
    | x -> failwith (sprintf "ReadCrossType unknown fix tag: %A"  x) 


let ReadCrossPrioritization (bs:byte[]) (pos:int) (len:int): CrossPrioritization =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CrossPrioritization.NNone
    |"1"B -> CrossPrioritization.BuySideIsPrioritized
    |"2"B -> CrossPrioritization.SellSideIsPrioritized
    | x -> failwith (sprintf "ReadCrossPrioritization unknown fix tag: %A"  x) 


let ReadOrigCrossID (bs:byte[]) (pos:int) (len:int): OrigCrossID =
    ReadFieldStr bs pos len OrigCrossID.OrigCrossID


let ReadNoSides (bs:byte[]) (pos:int) (len:int): NoSides =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> NoSides.OneSide
    |"2"B -> NoSides.BothSides
    | x -> failwith (sprintf "ReadNoSides unknown fix tag: %A"  x) 


let ReadUsername (bs:byte[]) (pos:int) (len:int): Username =
    ReadFieldStr bs pos len Username.Username


let ReadPassword (bs:byte[]) (pos:int) (len:int): Password =
    ReadFieldStr bs pos len Password.Password


let ReadNoLegs (bs:byte[]) (pos:int) (len:int): NoLegs =
    ReadFieldInt bs pos len NoLegs.NoLegs


let ReadLegCurrency (bs:byte[]) (pos:int) (len:int): LegCurrency =
    ReadFieldStr bs pos len LegCurrency.LegCurrency


let ReadTotNoSecurityTypes (bs:byte[]) (pos:int) (len:int): TotNoSecurityTypes =
    ReadFieldInt bs pos len TotNoSecurityTypes.TotNoSecurityTypes


let ReadNoSecurityTypes (bs:byte[]) (pos:int) (len:int): NoSecurityTypes =
    ReadFieldInt bs pos len NoSecurityTypes.NoSecurityTypes


let ReadSecurityListRequestType (bs:byte[]) (pos:int) (len:int): SecurityListRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SecurityListRequestType.Symbol
    |"1"B -> SecurityListRequestType.SecuritytypeAndOrCficode
    |"2"B -> SecurityListRequestType.Product
    |"3"B -> SecurityListRequestType.Tradingsessionid
    |"4"B -> SecurityListRequestType.AllSecurities
    | x -> failwith (sprintf "ReadSecurityListRequestType unknown fix tag: %A"  x) 


let ReadSecurityRequestResult (bs:byte[]) (pos:int) (len:int): SecurityRequestResult =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SecurityRequestResult.ValidRequest
    |"1"B -> SecurityRequestResult.InvalidOrUnsupportedRequest
    |"2"B -> SecurityRequestResult.NoInstrumentsFoundThatMatchSelectionCriteria
    |"3"B -> SecurityRequestResult.NotAuthorizedToRetrieveInstrumentData
    |"4"B -> SecurityRequestResult.InstrumentDataTemporarilyUnavailable
    |"5"B -> SecurityRequestResult.RequestForInstrumentDataNotSupported
    | x -> failwith (sprintf "ReadSecurityRequestResult unknown fix tag: %A"  x) 


let ReadRoundLot (bs:byte[]) (pos:int) (len:int): RoundLot =
    ReadFieldDecimal bs pos len RoundLot.RoundLot


let ReadMinTradeVol (bs:byte[]) (pos:int) (len:int): MinTradeVol =
    ReadFieldDecimal bs pos len MinTradeVol.MinTradeVol


let ReadMultiLegRptTypeReq (bs:byte[]) (pos:int) (len:int): MultiLegRptTypeReq =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MultiLegRptTypeReq.ReportByMulitlegSecurityOnly
    |"1"B -> MultiLegRptTypeReq.ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity
    |"2"B -> MultiLegRptTypeReq.ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly
    | x -> failwith (sprintf "ReadMultiLegRptTypeReq unknown fix tag: %A"  x) 


let ReadLegPositionEffect (bs:byte[]) (pos:int) (len:int): LegPositionEffect =
    ReadFieldChar bs pos len LegPositionEffect.LegPositionEffect


let ReadLegCoveredOrUncovered (bs:byte[]) (pos:int) (len:int): LegCoveredOrUncovered =
    ReadFieldInt bs pos len LegCoveredOrUncovered.LegCoveredOrUncovered


let ReadLegPrice (bs:byte[]) (pos:int) (len:int): LegPrice =
    ReadFieldDecimal bs pos len LegPrice.LegPrice


let ReadTradSesStatusRejReason (bs:byte[]) (pos:int) (len:int): TradSesStatusRejReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> TradSesStatusRejReason.UnknownOrInvalidTradingsessionid
    | x -> failwith (sprintf "ReadTradSesStatusRejReason unknown fix tag: %A"  x) 


let ReadTradeRequestID (bs:byte[]) (pos:int) (len:int): TradeRequestID =
    ReadFieldStr bs pos len TradeRequestID.TradeRequestID


let ReadTradeRequestType (bs:byte[]) (pos:int) (len:int): TradeRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeRequestType.AllTrades
    |"1"B -> TradeRequestType.MatchedTradesMatchingCriteriaProvidedOnRequest
    |"2"B -> TradeRequestType.UnmatchedTradesThatMatchCriteria
    |"3"B -> TradeRequestType.UnreportedTradesThatMatchCriteria
    |"4"B -> TradeRequestType.AdvisoriesThatMatchCriteria
    | x -> failwith (sprintf "ReadTradeRequestType unknown fix tag: %A"  x) 


let ReadPreviouslyReported (bs:byte[]) (pos:int) (len:int): PreviouslyReported =
    ReadFieldBool bs pos len PreviouslyReported.PreviouslyReported


let ReadTradeReportID (bs:byte[]) (pos:int) (len:int): TradeReportID =
    ReadFieldStr bs pos len TradeReportID.TradeReportID


let ReadTradeReportRefID (bs:byte[]) (pos:int) (len:int): TradeReportRefID =
    ReadFieldStr bs pos len TradeReportRefID.TradeReportRefID


let ReadMatchStatus (bs:byte[]) (pos:int) (len:int): MatchStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MatchStatus.ComparedMatchedOrAffirmed
    |"1"B -> MatchStatus.UncomparedUnmatchedOrUnaffirmed
    |"2"B -> MatchStatus.AdvisoryOrAlert
    | x -> failwith (sprintf "ReadMatchStatus unknown fix tag: %A"  x) 


let ReadMatchType (bs:byte[]) (pos:int) (len:int): MatchType =
    ReadFieldStr bs pos len MatchType.MatchType


let ReadOddLot (bs:byte[]) (pos:int) (len:int): OddLot =
    ReadFieldBool bs pos len OddLot.OddLot


let ReadNoClearingInstructions (bs:byte[]) (pos:int) (len:int): NoClearingInstructions =
    ReadFieldInt bs pos len NoClearingInstructions.NoClearingInstructions


let ReadClearingInstruction (bs:byte[]) (pos:int) (len:int): ClearingInstruction =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ClearingInstruction.ProcessNormally
    |"1"B -> ClearingInstruction.ExcludeFromAllNetting
    |"2"B -> ClearingInstruction.BilateralNettingOnly
    |"3"B -> ClearingInstruction.ExClearing
    |"4"B -> ClearingInstruction.SpecialTrade
    |"5"B -> ClearingInstruction.MultilateralNetting
    |"6"B -> ClearingInstruction.ClearAgainstCentralCounterparty
    |"7"B -> ClearingInstruction.ExcludeFromCentralCounterparty
    |"8"B -> ClearingInstruction.ManualMode
    |"9"B -> ClearingInstruction.AutomaticPostingMode
    |"10"B -> ClearingInstruction.AutomaticGiveUpMode
    |"11"B -> ClearingInstruction.QualifiedServiceRepresentative
    |"12"B -> ClearingInstruction.CustomerTrade
    |"13"B -> ClearingInstruction.SelfClearing
    | x -> failwith (sprintf "ReadClearingInstruction unknown fix tag: %A"  x) 


let ReadTradeInputSource (bs:byte[]) (pos:int) (len:int): TradeInputSource =
    ReadFieldStr bs pos len TradeInputSource.TradeInputSource


let ReadTradeInputDevice (bs:byte[]) (pos:int) (len:int): TradeInputDevice =
    ReadFieldStr bs pos len TradeInputDevice.TradeInputDevice


let ReadNoDates (bs:byte[]) (pos:int) (len:int): NoDates =
    ReadFieldInt bs pos len NoDates.NoDates


let ReadAccountType (bs:byte[]) (pos:int) (len:int): AccountType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AccountType.AccountIsCarriedOnCustomerSideOfBooks
    |"2"B -> AccountType.AccountIsCarriedOnNonCustomerSideOfBooks
    |"3"B -> AccountType.HouseTrader
    |"4"B -> AccountType.FloorTrader
    |"6"B -> AccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
    |"7"B -> AccountType.AccountIsHouseTraderAndIsCrossMargined
    |"8"B -> AccountType.JointBackofficeAccount
    | x -> failwith (sprintf "ReadAccountType unknown fix tag: %A"  x) 


let ReadCustOrderCapacity (bs:byte[]) (pos:int) (len:int): CustOrderCapacity =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> CustOrderCapacity.MemberTradingForTheirOwnAccount
    |"2"B -> CustOrderCapacity.ClearingFirmTradingForItsProprietaryAccount
    |"3"B -> CustOrderCapacity.MemberTradingForAnotherMember
    |"4"B -> CustOrderCapacity.AllOther
    | x -> failwith (sprintf "ReadCustOrderCapacity unknown fix tag: %A"  x) 


let ReadClOrdLinkID (bs:byte[]) (pos:int) (len:int): ClOrdLinkID =
    ReadFieldStr bs pos len ClOrdLinkID.ClOrdLinkID


let ReadMassStatusReqID (bs:byte[]) (pos:int) (len:int): MassStatusReqID =
    ReadFieldStr bs pos len MassStatusReqID.MassStatusReqID


let ReadMassStatusReqType (bs:byte[]) (pos:int) (len:int): MassStatusReqType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> MassStatusReqType.StatusForOrdersForASecurity
    |"2"B -> MassStatusReqType.StatusForOrdersForAnUnderlyingSecurity
    |"3"B -> MassStatusReqType.StatusForOrdersForAProduct
    |"4"B -> MassStatusReqType.StatusForOrdersForACficode
    |"5"B -> MassStatusReqType.StatusForOrdersForASecuritytype
    |"6"B -> MassStatusReqType.StatusForOrdersForATradingSession
    |"7"B -> MassStatusReqType.StatusForAllOrders
    |"8"B -> MassStatusReqType.StatusForOrdersForAPartyid
    | x -> failwith (sprintf "ReadMassStatusReqType unknown fix tag: %A"  x) 


let ReadOrigOrdModTime (bs:byte[]) (pos:int) (len:int): OrigOrdModTime =
    ReadFieldUTCTimestamp bs pos len OrigOrdModTime.OrigOrdModTime


let ReadLegSettlType (bs:byte[]) (pos:int) (len:int): LegSettlType =
    ReadFieldChar bs pos len LegSettlType.LegSettlType


let ReadLegSettlDate (bs:byte[]) (pos:int) (len:int): LegSettlDate =
    ReadFieldLocalMktDate bs pos len LegSettlDate.LegSettlDate


let ReadDayBookingInst (bs:byte[]) (pos:int) (len:int): DayBookingInst =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DayBookingInst.CanTriggerBookingWithoutReferenceToTheOrderInitiator
    |"1"B -> DayBookingInst.SpeakWithOrderInitiatorBeforeBooking
    |"2"B -> DayBookingInst.Accumulate
    | x -> failwith (sprintf "ReadDayBookingInst unknown fix tag: %A"  x) 


let ReadBookingUnit (bs:byte[]) (pos:int) (len:int): BookingUnit =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> BookingUnit.EachPartialExecutionIsABookableUnit
    |"1"B -> BookingUnit.AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
    |"2"B -> BookingUnit.AggregateExecutionsForThisSymbolSideAndSettlementDate
    | x -> failwith (sprintf "ReadBookingUnit unknown fix tag: %A"  x) 


let ReadPreallocMethod (bs:byte[]) (pos:int) (len:int): PreallocMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PreallocMethod.ProRata
    |"1"B -> PreallocMethod.DoNotProRata
    | x -> failwith (sprintf "ReadPreallocMethod unknown fix tag: %A"  x) 


let ReadUnderlyingCountryOfIssue (bs:byte[]) (pos:int) (len:int): UnderlyingCountryOfIssue =
    ReadFieldStr bs pos len UnderlyingCountryOfIssue.UnderlyingCountryOfIssue


let ReadUnderlyingStateOrProvinceOfIssue (bs:byte[]) (pos:int) (len:int): UnderlyingStateOrProvinceOfIssue =
    ReadFieldStr bs pos len UnderlyingStateOrProvinceOfIssue.UnderlyingStateOrProvinceOfIssue


let ReadUnderlyingLocaleOfIssue (bs:byte[]) (pos:int) (len:int): UnderlyingLocaleOfIssue =
    ReadFieldStr bs pos len UnderlyingLocaleOfIssue.UnderlyingLocaleOfIssue


let ReadUnderlyingInstrRegistry (bs:byte[]) (pos:int) (len:int): UnderlyingInstrRegistry =
    ReadFieldStr bs pos len UnderlyingInstrRegistry.UnderlyingInstrRegistry


let ReadLegCountryOfIssue (bs:byte[]) (pos:int) (len:int): LegCountryOfIssue =
    ReadFieldStr bs pos len LegCountryOfIssue.LegCountryOfIssue


let ReadLegStateOrProvinceOfIssue (bs:byte[]) (pos:int) (len:int): LegStateOrProvinceOfIssue =
    ReadFieldStr bs pos len LegStateOrProvinceOfIssue.LegStateOrProvinceOfIssue


let ReadLegLocaleOfIssue (bs:byte[]) (pos:int) (len:int): LegLocaleOfIssue =
    ReadFieldStr bs pos len LegLocaleOfIssue.LegLocaleOfIssue


let ReadLegInstrRegistry (bs:byte[]) (pos:int) (len:int): LegInstrRegistry =
    ReadFieldStr bs pos len LegInstrRegistry.LegInstrRegistry


let ReadLegSymbol (bs:byte[]) (pos:int) (len:int): LegSymbol =
    ReadFieldStr bs pos len LegSymbol.LegSymbol


let ReadLegSymbolSfx (bs:byte[]) (pos:int) (len:int): LegSymbolSfx =
    ReadFieldStr bs pos len LegSymbolSfx.LegSymbolSfx


let ReadLegSecurityID (bs:byte[]) (pos:int) (len:int): LegSecurityID =
    ReadFieldStr bs pos len LegSecurityID.LegSecurityID


let ReadLegSecurityIDSource (bs:byte[]) (pos:int) (len:int): LegSecurityIDSource =
    ReadFieldStr bs pos len LegSecurityIDSource.LegSecurityIDSource


let ReadNoLegSecurityAltID (bs:byte[]) (pos:int) (len:int): NoLegSecurityAltID =
    ReadFieldInt bs pos len NoLegSecurityAltID.NoLegSecurityAltID


let ReadLegSecurityAltID (bs:byte[]) (pos:int) (len:int): LegSecurityAltID =
    ReadFieldStr bs pos len LegSecurityAltID.LegSecurityAltID


let ReadLegSecurityAltIDSource (bs:byte[]) (pos:int) (len:int): LegSecurityAltIDSource =
    ReadFieldStr bs pos len LegSecurityAltIDSource.LegSecurityAltIDSource


let ReadLegProduct (bs:byte[]) (pos:int) (len:int): LegProduct =
    ReadFieldInt bs pos len LegProduct.LegProduct


let ReadLegCFICode (bs:byte[]) (pos:int) (len:int): LegCFICode =
    ReadFieldStr bs pos len LegCFICode.LegCFICode


let ReadLegSecurityType (bs:byte[]) (pos:int) (len:int): LegSecurityType =
    ReadFieldStr bs pos len LegSecurityType.LegSecurityType


let ReadLegMaturityMonthYear (bs:byte[]) (pos:int) (len:int): LegMaturityMonthYear =
    ReadFieldMonthYear bs pos len LegMaturityMonthYear.LegMaturityMonthYear


let ReadLegMaturityDate (bs:byte[]) (pos:int) (len:int): LegMaturityDate =
    ReadFieldLocalMktDate bs pos len LegMaturityDate.LegMaturityDate


let ReadLegStrikePrice (bs:byte[]) (pos:int) (len:int): LegStrikePrice =
    ReadFieldDecimal bs pos len LegStrikePrice.LegStrikePrice


let ReadLegOptAttribute (bs:byte[]) (pos:int) (len:int): LegOptAttribute =
    ReadFieldChar bs pos len LegOptAttribute.LegOptAttribute


let ReadLegContractMultiplier (bs:byte[]) (pos:int) (len:int): LegContractMultiplier =
    ReadFieldDecimal bs pos len LegContractMultiplier.LegContractMultiplier


let ReadLegCouponRate (bs:byte[]) (pos:int) (len:int): LegCouponRate =
    ReadFieldDecimal bs pos len LegCouponRate.LegCouponRate


let ReadLegSecurityExchange (bs:byte[]) (pos:int) (len:int): LegSecurityExchange =
    ReadFieldStr bs pos len LegSecurityExchange.LegSecurityExchange


let ReadLegIssuer (bs:byte[]) (pos:int) (len:int): LegIssuer =
    ReadFieldStr bs pos len LegIssuer.LegIssuer


// compound read
let ReadEncodedLegIssuer (bs:byte[]) (pos:int) (len:int): EncodedLegIssuer =
    ReadLengthDataCompoundField bs pos len "619"B EncodedLegIssuer.EncodedLegIssuer


let ReadLegSecurityDesc (bs:byte[]) (pos:int) (len:int): LegSecurityDesc =
    ReadFieldStr bs pos len LegSecurityDesc.LegSecurityDesc


// compound read
let ReadEncodedLegSecurityDesc (bs:byte[]) (pos:int) (len:int): EncodedLegSecurityDesc =
    ReadLengthDataCompoundField bs pos len "622"B EncodedLegSecurityDesc.EncodedLegSecurityDesc


let ReadLegRatioQty (bs:byte[]) (pos:int) (len:int): LegRatioQty =
    ReadFieldDecimal bs pos len LegRatioQty.LegRatioQty


let ReadLegSide (bs:byte[]) (pos:int) (len:int): LegSide =
    ReadFieldChar bs pos len LegSide.LegSide


let ReadTradingSessionSubID (bs:byte[]) (pos:int) (len:int): TradingSessionSubID =
    ReadFieldStr bs pos len TradingSessionSubID.TradingSessionSubID


let ReadAllocType (bs:byte[]) (pos:int) (len:int): AllocType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AllocType.Calculated
    |"2"B -> AllocType.Preliminary
    |"5"B -> AllocType.ReadyToBookSingleOrder
    |"7"B -> AllocType.WarehouseInstruction
    |"8"B -> AllocType.RequestToIntermediary
    | x -> failwith (sprintf "ReadAllocType unknown fix tag: %A"  x) 


let ReadNoHops (bs:byte[]) (pos:int) (len:int): NoHops =
    ReadFieldInt bs pos len NoHops.NoHops


let ReadHopCompID (bs:byte[]) (pos:int) (len:int): HopCompID =
    ReadFieldStr bs pos len HopCompID.HopCompID


let ReadHopSendingTime (bs:byte[]) (pos:int) (len:int): HopSendingTime =
    ReadFieldUTCTimestamp bs pos len HopSendingTime.HopSendingTime


let ReadHopRefID (bs:byte[]) (pos:int) (len:int): HopRefID =
    ReadFieldUInt bs pos len HopRefID.HopRefID


let ReadMidPx (bs:byte[]) (pos:int) (len:int): MidPx =
    ReadFieldDecimal bs pos len MidPx.MidPx


let ReadBidYield (bs:byte[]) (pos:int) (len:int): BidYield =
    ReadFieldDecimal bs pos len BidYield.BidYield


let ReadMidYield (bs:byte[]) (pos:int) (len:int): MidYield =
    ReadFieldDecimal bs pos len MidYield.MidYield


let ReadOfferYield (bs:byte[]) (pos:int) (len:int): OfferYield =
    ReadFieldDecimal bs pos len OfferYield.OfferYield


let ReadClearingFeeIndicator (bs:byte[]) (pos:int) (len:int): ClearingFeeIndicator =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"B"B -> ClearingFeeIndicator.CboeMember
    |"C"B -> ClearingFeeIndicator.NonMemberAndCustomer
    |"E"B -> ClearingFeeIndicator.EquityMemberAndClearingMember
    |"F"B -> ClearingFeeIndicator.FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers
    |"H"B -> ClearingFeeIndicator.Firms106hAnd106j
    |"I"B -> ClearingFeeIndicator.GimIdemAndComMembershipInterestHolders
    |"L"B -> ClearingFeeIndicator.LesseeAnd106fEmployees
    |"M"B -> ClearingFeeIndicator.AllOtherOwnershipTypes
    | x -> failwith (sprintf "ReadClearingFeeIndicator unknown fix tag: %A"  x) 


let ReadWorkingIndicator (bs:byte[]) (pos:int) (len:int): WorkingIndicator =
    ReadFieldBool bs pos len WorkingIndicator.WorkingIndicator


let ReadLegLastPx (bs:byte[]) (pos:int) (len:int): LegLastPx =
    ReadFieldDecimal bs pos len LegLastPx.LegLastPx


let ReadPriorityIndicator (bs:byte[]) (pos:int) (len:int): PriorityIndicator =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PriorityIndicator.PriorityUnchanged
    |"1"B -> PriorityIndicator.LostPriorityAsResultOfOrderChange
    | x -> failwith (sprintf "ReadPriorityIndicator unknown fix tag: %A"  x) 


let ReadPriceImprovement (bs:byte[]) (pos:int) (len:int): PriceImprovement =
    ReadFieldDecimal bs pos len PriceImprovement.PriceImprovement


let ReadPrice2 (bs:byte[]) (pos:int) (len:int): Price2 =
    ReadFieldDecimal bs pos len Price2.Price2


let ReadLastForwardPoints2 (bs:byte[]) (pos:int) (len:int): LastForwardPoints2 =
    ReadFieldDecimal bs pos len LastForwardPoints2.LastForwardPoints2


let ReadBidForwardPoints2 (bs:byte[]) (pos:int) (len:int): BidForwardPoints2 =
    ReadFieldDecimal bs pos len BidForwardPoints2.BidForwardPoints2


let ReadOfferForwardPoints2 (bs:byte[]) (pos:int) (len:int): OfferForwardPoints2 =
    ReadFieldDecimal bs pos len OfferForwardPoints2.OfferForwardPoints2


let ReadRFQReqID (bs:byte[]) (pos:int) (len:int): RFQReqID =
    ReadFieldStr bs pos len RFQReqID.RFQReqID


let ReadMktBidPx (bs:byte[]) (pos:int) (len:int): MktBidPx =
    ReadFieldDecimal bs pos len MktBidPx.MktBidPx


let ReadMktOfferPx (bs:byte[]) (pos:int) (len:int): MktOfferPx =
    ReadFieldDecimal bs pos len MktOfferPx.MktOfferPx


let ReadMinBidSize (bs:byte[]) (pos:int) (len:int): MinBidSize =
    ReadFieldDecimal bs pos len MinBidSize.MinBidSize


let ReadMinOfferSize (bs:byte[]) (pos:int) (len:int): MinOfferSize =
    ReadFieldDecimal bs pos len MinOfferSize.MinOfferSize


let ReadQuoteStatusReqID (bs:byte[]) (pos:int) (len:int): QuoteStatusReqID =
    ReadFieldStr bs pos len QuoteStatusReqID.QuoteStatusReqID


let ReadLegalConfirm (bs:byte[]) (pos:int) (len:int): LegalConfirm =
    ReadFieldBool bs pos len LegalConfirm.LegalConfirm


let ReadUnderlyingLastPx (bs:byte[]) (pos:int) (len:int): UnderlyingLastPx =
    ReadFieldDecimal bs pos len UnderlyingLastPx.UnderlyingLastPx


let ReadUnderlyingLastQty (bs:byte[]) (pos:int) (len:int): UnderlyingLastQty =
    ReadFieldDecimal bs pos len UnderlyingLastQty.UnderlyingLastQty


let ReadLegRefID (bs:byte[]) (pos:int) (len:int): LegRefID =
    ReadFieldStr bs pos len LegRefID.LegRefID


let ReadContraLegRefID (bs:byte[]) (pos:int) (len:int): ContraLegRefID =
    ReadFieldStr bs pos len ContraLegRefID.ContraLegRefID


let ReadSettlCurrBidFxRate (bs:byte[]) (pos:int) (len:int): SettlCurrBidFxRate =
    ReadFieldDecimal bs pos len SettlCurrBidFxRate.SettlCurrBidFxRate


let ReadSettlCurrOfferFxRate (bs:byte[]) (pos:int) (len:int): SettlCurrOfferFxRate =
    ReadFieldDecimal bs pos len SettlCurrOfferFxRate.SettlCurrOfferFxRate


let ReadQuoteRequestRejectReason (bs:byte[]) (pos:int) (len:int): QuoteRequestRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuoteRequestRejectReason.UnknownSymbol
    |"2"B -> QuoteRequestRejectReason.ExchangeClosed
    |"3"B -> QuoteRequestRejectReason.QuoteRequestExceedsLimit
    |"4"B -> QuoteRequestRejectReason.TooLateToEnter
    |"5"B -> QuoteRequestRejectReason.InvalidPrice
    |"6"B -> QuoteRequestRejectReason.NotAuthorizedToRequestQuote
    |"7"B -> QuoteRequestRejectReason.NoMatchForInquiry
    |"8"B -> QuoteRequestRejectReason.NoMarketForInstrument
    |"9"B -> QuoteRequestRejectReason.NoInventory
    |"10"B -> QuoteRequestRejectReason.Pass
    |"99"B -> QuoteRequestRejectReason.Other
    | x -> failwith (sprintf "ReadQuoteRequestRejectReason unknown fix tag: %A"  x) 


let ReadSideComplianceID (bs:byte[]) (pos:int) (len:int): SideComplianceID =
    ReadFieldStr bs pos len SideComplianceID.SideComplianceID


let ReadAcctIDSource (bs:byte[]) (pos:int) (len:int): AcctIDSource =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AcctIDSource.Bic
    |"2"B -> AcctIDSource.SidCode
    |"3"B -> AcctIDSource.Tfm
    |"4"B -> AcctIDSource.Omgeo
    |"5"B -> AcctIDSource.DtccCode
    |"99"B -> AcctIDSource.Other
    | x -> failwith (sprintf "ReadAcctIDSource unknown fix tag: %A"  x) 


let ReadAllocAcctIDSource (bs:byte[]) (pos:int) (len:int): AllocAcctIDSource =
    ReadFieldInt bs pos len AllocAcctIDSource.AllocAcctIDSource


let ReadBenchmarkPrice (bs:byte[]) (pos:int) (len:int): BenchmarkPrice =
    ReadFieldDecimal bs pos len BenchmarkPrice.BenchmarkPrice


let ReadBenchmarkPriceType (bs:byte[]) (pos:int) (len:int): BenchmarkPriceType =
    ReadFieldInt bs pos len BenchmarkPriceType.BenchmarkPriceType


let ReadConfirmID (bs:byte[]) (pos:int) (len:int): ConfirmID =
    ReadFieldStr bs pos len ConfirmID.ConfirmID


let ReadConfirmStatus (bs:byte[]) (pos:int) (len:int): ConfirmStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ConfirmStatus.Received
    |"2"B -> ConfirmStatus.MismatchedAccount
    |"3"B -> ConfirmStatus.MissingSettlementInstructions
    |"4"B -> ConfirmStatus.Confirmed
    |"5"B -> ConfirmStatus.RequestRejected
    | x -> failwith (sprintf "ReadConfirmStatus unknown fix tag: %A"  x) 


let ReadConfirmTransType (bs:byte[]) (pos:int) (len:int): ConfirmTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ConfirmTransType.New
    |"1"B -> ConfirmTransType.Replace
    |"2"B -> ConfirmTransType.Cancel
    | x -> failwith (sprintf "ReadConfirmTransType unknown fix tag: %A"  x) 


let ReadContractSettlMonth (bs:byte[]) (pos:int) (len:int): ContractSettlMonth =
    ReadFieldMonthYear bs pos len ContractSettlMonth.ContractSettlMonth


let ReadDeliveryForm (bs:byte[]) (pos:int) (len:int): DeliveryForm =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> DeliveryForm.Bookentry
    |"2"B -> DeliveryForm.Bearer
    | x -> failwith (sprintf "ReadDeliveryForm unknown fix tag: %A"  x) 


let ReadLastParPx (bs:byte[]) (pos:int) (len:int): LastParPx =
    ReadFieldDecimal bs pos len LastParPx.LastParPx


let ReadNoLegAllocs (bs:byte[]) (pos:int) (len:int): NoLegAllocs =
    ReadFieldInt bs pos len NoLegAllocs.NoLegAllocs


let ReadLegAllocAccount (bs:byte[]) (pos:int) (len:int): LegAllocAccount =
    ReadFieldStr bs pos len LegAllocAccount.LegAllocAccount


let ReadLegIndividualAllocID (bs:byte[]) (pos:int) (len:int): LegIndividualAllocID =
    ReadFieldStr bs pos len LegIndividualAllocID.LegIndividualAllocID


let ReadLegAllocQty (bs:byte[]) (pos:int) (len:int): LegAllocQty =
    ReadFieldDecimal bs pos len LegAllocQty.LegAllocQty


let ReadLegAllocAcctIDSource (bs:byte[]) (pos:int) (len:int): LegAllocAcctIDSource =
    ReadFieldStr bs pos len LegAllocAcctIDSource.LegAllocAcctIDSource


let ReadLegSettlCurrency (bs:byte[]) (pos:int) (len:int): LegSettlCurrency =
    ReadFieldStr bs pos len LegSettlCurrency.LegSettlCurrency


let ReadLegBenchmarkCurveCurrency (bs:byte[]) (pos:int) (len:int): LegBenchmarkCurveCurrency =
    ReadFieldStr bs pos len LegBenchmarkCurveCurrency.LegBenchmarkCurveCurrency


let ReadLegBenchmarkCurveName (bs:byte[]) (pos:int) (len:int): LegBenchmarkCurveName =
    ReadFieldStr bs pos len LegBenchmarkCurveName.LegBenchmarkCurveName


let ReadLegBenchmarkCurvePoint (bs:byte[]) (pos:int) (len:int): LegBenchmarkCurvePoint =
    ReadFieldStr bs pos len LegBenchmarkCurvePoint.LegBenchmarkCurvePoint


let ReadLegBenchmarkPrice (bs:byte[]) (pos:int) (len:int): LegBenchmarkPrice =
    ReadFieldDecimal bs pos len LegBenchmarkPrice.LegBenchmarkPrice


let ReadLegBenchmarkPriceType (bs:byte[]) (pos:int) (len:int): LegBenchmarkPriceType =
    ReadFieldInt bs pos len LegBenchmarkPriceType.LegBenchmarkPriceType


let ReadLegBidPx (bs:byte[]) (pos:int) (len:int): LegBidPx =
    ReadFieldDecimal bs pos len LegBidPx.LegBidPx


let ReadLegIOIQty (bs:byte[]) (pos:int) (len:int): LegIOIQty =
    ReadFieldStr bs pos len LegIOIQty.LegIOIQty


let ReadNoLegStipulations (bs:byte[]) (pos:int) (len:int): NoLegStipulations =
    ReadFieldInt bs pos len NoLegStipulations.NoLegStipulations


let ReadLegOfferPx (bs:byte[]) (pos:int) (len:int): LegOfferPx =
    ReadFieldDecimal bs pos len LegOfferPx.LegOfferPx


let ReadLegOrderQty (bs:byte[]) (pos:int) (len:int): LegOrderQty =
    ReadFieldDecimal bs pos len LegOrderQty.LegOrderQty


let ReadLegPriceType (bs:byte[]) (pos:int) (len:int): LegPriceType =
    ReadFieldInt bs pos len LegPriceType.LegPriceType


let ReadLegQty (bs:byte[]) (pos:int) (len:int): LegQty =
    ReadFieldDecimal bs pos len LegQty.LegQty


let ReadLegStipulationType (bs:byte[]) (pos:int) (len:int): LegStipulationType =
    ReadFieldStr bs pos len LegStipulationType.LegStipulationType


let ReadLegStipulationValue (bs:byte[]) (pos:int) (len:int): LegStipulationValue =
    ReadFieldStr bs pos len LegStipulationValue.LegStipulationValue


let ReadLegSwapType (bs:byte[]) (pos:int) (len:int): LegSwapType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> LegSwapType.ParForPar
    |"2"B -> LegSwapType.ModifiedDuration
    |"4"B -> LegSwapType.Risk
    |"5"B -> LegSwapType.Proceeds
    | x -> failwith (sprintf "ReadLegSwapType unknown fix tag: %A"  x) 


let ReadPool (bs:byte[]) (pos:int) (len:int): Pool =
    ReadFieldStr bs pos len Pool.Pool


let ReadQuotePriceType (bs:byte[]) (pos:int) (len:int): QuotePriceType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuotePriceType.Percent
    |"2"B -> QuotePriceType.PerShare
    |"3"B -> QuotePriceType.FixedAmount
    |"4"B -> QuotePriceType.Discount
    |"5"B -> QuotePriceType.Premium
    |"6"B -> QuotePriceType.BasisPointsRelativeToBenchmark
    |"7"B -> QuotePriceType.TedPrice
    |"8"B -> QuotePriceType.TedYield
    |"9"B -> QuotePriceType.YieldSpread
    |"10"B -> QuotePriceType.Yield
    | x -> failwith (sprintf "ReadQuotePriceType unknown fix tag: %A"  x) 


let ReadQuoteRespID (bs:byte[]) (pos:int) (len:int): QuoteRespID =
    ReadFieldStr bs pos len QuoteRespID.QuoteRespID


let ReadQuoteRespType (bs:byte[]) (pos:int) (len:int): QuoteRespType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> QuoteRespType.HitLift
    |"2"B -> QuoteRespType.Counter
    |"3"B -> QuoteRespType.Expired
    |"4"B -> QuoteRespType.Cover
    |"5"B -> QuoteRespType.DoneAway
    |"6"B -> QuoteRespType.Pass
    | x -> failwith (sprintf "ReadQuoteRespType unknown fix tag: %A"  x) 


let ReadQuoteQualifier (bs:byte[]) (pos:int) (len:int): QuoteQualifier =
    ReadFieldChar bs pos len QuoteQualifier.QuoteQualifier


let ReadYieldRedemptionDate (bs:byte[]) (pos:int) (len:int): YieldRedemptionDate =
    ReadFieldLocalMktDate bs pos len YieldRedemptionDate.YieldRedemptionDate


let ReadYieldRedemptionPrice (bs:byte[]) (pos:int) (len:int): YieldRedemptionPrice =
    ReadFieldDecimal bs pos len YieldRedemptionPrice.YieldRedemptionPrice


let ReadYieldRedemptionPriceType (bs:byte[]) (pos:int) (len:int): YieldRedemptionPriceType =
    ReadFieldInt bs pos len YieldRedemptionPriceType.YieldRedemptionPriceType


let ReadBenchmarkSecurityID (bs:byte[]) (pos:int) (len:int): BenchmarkSecurityID =
    ReadFieldStr bs pos len BenchmarkSecurityID.BenchmarkSecurityID


let ReadReversalIndicator (bs:byte[]) (pos:int) (len:int): ReversalIndicator =
    ReadFieldBool bs pos len ReversalIndicator.ReversalIndicator


let ReadYieldCalcDate (bs:byte[]) (pos:int) (len:int): YieldCalcDate =
    ReadFieldLocalMktDate bs pos len YieldCalcDate.YieldCalcDate


let ReadNoPositions (bs:byte[]) (pos:int) (len:int): NoPositions =
    ReadFieldInt bs pos len NoPositions.NoPositions


let ReadPosType (bs:byte[]) (pos:int) (len:int): PosType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"TQ"B -> PosType.TransactionQuantity
    |"IAS"B -> PosType.IntraSpreadQty
    |"IES"B -> PosType.InterSpreadQty
    |"FIN"B -> PosType.EndOfDayQty
    |"SOD"B -> PosType.StartOfDayQty
    |"EX"B -> PosType.OptionExerciseQty
    |"AS"B -> PosType.OptionAssignment
    |"TX"B -> PosType.TransactionFromExercise
    |"TA"B -> PosType.TransactionFromAssignment
    |"PIT"B -> PosType.PitTradeQty
    |"TRF"B -> PosType.TransferTradeQty
    |"ETR"B -> PosType.ElectronicTradeQty
    |"ALC"B -> PosType.AllocationTradeQty
    |"PA"B -> PosType.AdjustmentQty
    |"ASF"B -> PosType.AsOfTradeQty
    |"DLV"B -> PosType.DeliveryQty
    |"TOT"B -> PosType.TotalTransactionQty
    |"XM"B -> PosType.CrossMarginQty
    |"SPL"B -> PosType.IntegralSplit
    | x -> failwith (sprintf "ReadPosType unknown fix tag: %A"  x) 


let ReadLongQty (bs:byte[]) (pos:int) (len:int): LongQty =
    ReadFieldDecimal bs pos len LongQty.LongQty


let ReadShortQty (bs:byte[]) (pos:int) (len:int): ShortQty =
    ReadFieldDecimal bs pos len ShortQty.ShortQty


let ReadPosQtyStatus (bs:byte[]) (pos:int) (len:int): PosQtyStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PosQtyStatus.Submitted
    |"1"B -> PosQtyStatus.Accepted
    |"2"B -> PosQtyStatus.Rejected
    | x -> failwith (sprintf "ReadPosQtyStatus unknown fix tag: %A"  x) 


let ReadPosAmtType (bs:byte[]) (pos:int) (len:int): PosAmtType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"FMTM"B -> PosAmtType.FinalMarkToMarketAmount
    |"IMTM"B -> PosAmtType.IncrementalMarkToMarketAmount
    |"TVAR"B -> PosAmtType.TradeVariationAmount
    |"SMTM"B -> PosAmtType.StartOfDayMarkToMarketAmount
    |"PREM"B -> PosAmtType.PremiumAmount
    |"CRES"B -> PosAmtType.CashResidualAmount
    |"CASH"B -> PosAmtType.CashAmount
    |"VADJ"B -> PosAmtType.ValueAdjustedAmount
    | x -> failwith (sprintf "ReadPosAmtType unknown fix tag: %A"  x) 


let ReadPosAmt (bs:byte[]) (pos:int) (len:int): PosAmt =
    ReadFieldDecimal bs pos len PosAmt.PosAmt


let ReadPosTransType (bs:byte[]) (pos:int) (len:int): PosTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PosTransType.Exercise
    |"2"B -> PosTransType.DoNotExercise
    |"3"B -> PosTransType.PositionAdjustment
    |"4"B -> PosTransType.PositionChangeSubmissionMarginDisposition
    |"5"B -> PosTransType.Pledge
    | x -> failwith (sprintf "ReadPosTransType unknown fix tag: %A"  x) 


let ReadPosReqID (bs:byte[]) (pos:int) (len:int): PosReqID =
    ReadFieldStr bs pos len PosReqID.PosReqID


let ReadNoUnderlyings (bs:byte[]) (pos:int) (len:int): NoUnderlyings =
    ReadFieldInt bs pos len NoUnderlyings.NoUnderlyings


let ReadPosMaintAction (bs:byte[]) (pos:int) (len:int): PosMaintAction =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PosMaintAction.New
    |"2"B -> PosMaintAction.Replace
    |"3"B -> PosMaintAction.Cancel
    | x -> failwith (sprintf "ReadPosMaintAction unknown fix tag: %A"  x) 


let ReadOrigPosReqRefID (bs:byte[]) (pos:int) (len:int): OrigPosReqRefID =
    ReadFieldStr bs pos len OrigPosReqRefID.OrigPosReqRefID


let ReadPosMaintRptRefID (bs:byte[]) (pos:int) (len:int): PosMaintRptRefID =
    ReadFieldStr bs pos len PosMaintRptRefID.PosMaintRptRefID


let ReadClearingBusinessDate (bs:byte[]) (pos:int) (len:int): ClearingBusinessDate =
    ReadFieldLocalMktDate bs pos len ClearingBusinessDate.ClearingBusinessDate


let ReadSettlSessID (bs:byte[]) (pos:int) (len:int): SettlSessID =
    ReadFieldStr bs pos len SettlSessID.SettlSessID


let ReadSettlSessSubID (bs:byte[]) (pos:int) (len:int): SettlSessSubID =
    ReadFieldStr bs pos len SettlSessSubID.SettlSessSubID


let ReadAdjustmentType (bs:byte[]) (pos:int) (len:int): AdjustmentType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AdjustmentType.ProcessRequestAsMarginDisposition
    |"1"B -> AdjustmentType.DeltaPlus
    |"2"B -> AdjustmentType.DeltaMinus
    |"3"B -> AdjustmentType.Final
    | x -> failwith (sprintf "ReadAdjustmentType unknown fix tag: %A"  x) 


let ReadContraryInstructionIndicator (bs:byte[]) (pos:int) (len:int): ContraryInstructionIndicator =
    ReadFieldBool bs pos len ContraryInstructionIndicator.ContraryInstructionIndicator


let ReadPriorSpreadIndicator (bs:byte[]) (pos:int) (len:int): PriorSpreadIndicator =
    ReadFieldBool bs pos len PriorSpreadIndicator.PriorSpreadIndicator


let ReadPosMaintRptID (bs:byte[]) (pos:int) (len:int): PosMaintRptID =
    ReadFieldStr bs pos len PosMaintRptID.PosMaintRptID


let ReadPosMaintStatus (bs:byte[]) (pos:int) (len:int): PosMaintStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PosMaintStatus.Accepted
    |"1"B -> PosMaintStatus.AcceptedWithWarnings
    |"2"B -> PosMaintStatus.Rejected
    |"3"B -> PosMaintStatus.Completed
    |"4"B -> PosMaintStatus.CompletedWithWarnings
    | x -> failwith (sprintf "ReadPosMaintStatus unknown fix tag: %A"  x) 


let ReadPosMaintResult (bs:byte[]) (pos:int) (len:int): PosMaintResult =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PosMaintResult.SuccessfulCompletionNoWarningsOrErrors
    |"1"B -> PosMaintResult.Rejected
    |"99"B -> PosMaintResult.Other
    | x -> failwith (sprintf "ReadPosMaintResult unknown fix tag: %A"  x) 


let ReadPosReqType (bs:byte[]) (pos:int) (len:int): PosReqType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PosReqType.Positions
    |"1"B -> PosReqType.Trades
    |"2"B -> PosReqType.Exercises
    |"3"B -> PosReqType.Assignments
    | x -> failwith (sprintf "ReadPosReqType unknown fix tag: %A"  x) 


let ReadResponseTransportType (bs:byte[]) (pos:int) (len:int): ResponseTransportType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ResponseTransportType.Inband
    |"1"B -> ResponseTransportType.OutOfBand
    | x -> failwith (sprintf "ReadResponseTransportType unknown fix tag: %A"  x) 


let ReadResponseDestination (bs:byte[]) (pos:int) (len:int): ResponseDestination =
    ReadFieldStr bs pos len ResponseDestination.ResponseDestination


let ReadTotalNumPosReports (bs:byte[]) (pos:int) (len:int): TotalNumPosReports =
    ReadFieldInt bs pos len TotalNumPosReports.TotalNumPosReports


let ReadPosReqResult (bs:byte[]) (pos:int) (len:int): PosReqResult =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PosReqResult.ValidRequest
    |"1"B -> PosReqResult.InvalidOrUnsupportedRequest
    |"2"B -> PosReqResult.NoPositionsFoundThatMatchCriteria
    |"3"B -> PosReqResult.NotAuthorizedToRequestPositions
    |"4"B -> PosReqResult.RequestForPositionNotSupported
    |"99"B -> PosReqResult.Other
    | x -> failwith (sprintf "ReadPosReqResult unknown fix tag: %A"  x) 


let ReadPosReqStatus (bs:byte[]) (pos:int) (len:int): PosReqStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PosReqStatus.Completed
    |"1"B -> PosReqStatus.CompletedWithWarnings
    |"2"B -> PosReqStatus.Rejected
    | x -> failwith (sprintf "ReadPosReqStatus unknown fix tag: %A"  x) 


let ReadSettlPrice (bs:byte[]) (pos:int) (len:int): SettlPrice =
    ReadFieldDecimal bs pos len SettlPrice.SettlPrice


let ReadSettlPriceType (bs:byte[]) (pos:int) (len:int): SettlPriceType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SettlPriceType.Final
    |"2"B -> SettlPriceType.Theoretical
    | x -> failwith (sprintf "ReadSettlPriceType unknown fix tag: %A"  x) 


let ReadUnderlyingSettlPrice (bs:byte[]) (pos:int) (len:int): UnderlyingSettlPrice =
    ReadFieldDecimal bs pos len UnderlyingSettlPrice.UnderlyingSettlPrice


let ReadUnderlyingSettlPriceType (bs:byte[]) (pos:int) (len:int): UnderlyingSettlPriceType =
    ReadFieldInt bs pos len UnderlyingSettlPriceType.UnderlyingSettlPriceType


let ReadPriorSettlPrice (bs:byte[]) (pos:int) (len:int): PriorSettlPrice =
    ReadFieldDecimal bs pos len PriorSettlPrice.PriorSettlPrice


let ReadNoQuoteQualifiers (bs:byte[]) (pos:int) (len:int): NoQuoteQualifiers =
    ReadFieldInt bs pos len NoQuoteQualifiers.NoQuoteQualifiers


let ReadAllocSettlCurrency (bs:byte[]) (pos:int) (len:int): AllocSettlCurrency =
    ReadFieldStr bs pos len AllocSettlCurrency.AllocSettlCurrency


let ReadAllocSettlCurrAmt (bs:byte[]) (pos:int) (len:int): AllocSettlCurrAmt =
    ReadFieldDecimal bs pos len AllocSettlCurrAmt.AllocSettlCurrAmt


let ReadInterestAtMaturity (bs:byte[]) (pos:int) (len:int): InterestAtMaturity =
    ReadFieldDecimal bs pos len InterestAtMaturity.InterestAtMaturity


let ReadLegDatedDate (bs:byte[]) (pos:int) (len:int): LegDatedDate =
    ReadFieldLocalMktDate bs pos len LegDatedDate.LegDatedDate


let ReadLegPool (bs:byte[]) (pos:int) (len:int): LegPool =
    ReadFieldStr bs pos len LegPool.LegPool


let ReadAllocInterestAtMaturity (bs:byte[]) (pos:int) (len:int): AllocInterestAtMaturity =
    ReadFieldDecimal bs pos len AllocInterestAtMaturity.AllocInterestAtMaturity


let ReadAllocAccruedInterestAmt (bs:byte[]) (pos:int) (len:int): AllocAccruedInterestAmt =
    ReadFieldDecimal bs pos len AllocAccruedInterestAmt.AllocAccruedInterestAmt


let ReadDeliveryDate (bs:byte[]) (pos:int) (len:int): DeliveryDate =
    ReadFieldLocalMktDate bs pos len DeliveryDate.DeliveryDate


let ReadAssignmentMethod (bs:byte[]) (pos:int) (len:int): AssignmentMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"R"B -> AssignmentMethod.Random
    |"P"B -> AssignmentMethod.Prorata
    | x -> failwith (sprintf "ReadAssignmentMethod unknown fix tag: %A"  x) 


let ReadAssignmentUnit (bs:byte[]) (pos:int) (len:int): AssignmentUnit =
    ReadFieldDecimal bs pos len AssignmentUnit.AssignmentUnit


let ReadOpenInterest (bs:byte[]) (pos:int) (len:int): OpenInterest =
    ReadFieldDecimal bs pos len OpenInterest.OpenInterest


let ReadExerciseMethod (bs:byte[]) (pos:int) (len:int): ExerciseMethod =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"A"B -> ExerciseMethod.Automatic
    |"M"B -> ExerciseMethod.Manual
    | x -> failwith (sprintf "ReadExerciseMethod unknown fix tag: %A"  x) 


let ReadTotNumTradeReports (bs:byte[]) (pos:int) (len:int): TotNumTradeReports =
    ReadFieldInt bs pos len TotNumTradeReports.TotNumTradeReports


let ReadTradeRequestResult (bs:byte[]) (pos:int) (len:int): TradeRequestResult =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeRequestResult.Successful
    |"1"B -> TradeRequestResult.InvalidOrUnknownInstrument
    |"2"B -> TradeRequestResult.InvalidTypeOfTradeRequested
    |"3"B -> TradeRequestResult.InvalidParties
    |"4"B -> TradeRequestResult.InvalidTransportTypeRequested
    |"5"B -> TradeRequestResult.InvalidDestinationRequested
    |"8"B -> TradeRequestResult.TraderequesttypeNotSupported
    |"9"B -> TradeRequestResult.UnauthorizedForTradeCaptureReportRequest
    |"10"B -> TradeRequestResult.Yield
    | x -> failwith (sprintf "ReadTradeRequestResult unknown fix tag: %A"  x) 


let ReadTradeRequestStatus (bs:byte[]) (pos:int) (len:int): TradeRequestStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeRequestStatus.Accepted
    |"1"B -> TradeRequestStatus.Completed
    |"2"B -> TradeRequestStatus.Rejected
    | x -> failwith (sprintf "ReadTradeRequestStatus unknown fix tag: %A"  x) 


let ReadTradeReportRejectReason (bs:byte[]) (pos:int) (len:int): TradeReportRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeReportRejectReason.Successful
    |"1"B -> TradeReportRejectReason.InvalidPartyInformation
    |"2"B -> TradeReportRejectReason.UnknownInstrument
    |"3"B -> TradeReportRejectReason.UnauthorizedToReportTrades
    |"4"B -> TradeReportRejectReason.InvalidTradeType
    |"10"B -> TradeReportRejectReason.Yield
    | x -> failwith (sprintf "ReadTradeReportRejectReason unknown fix tag: %A"  x) 


let ReadSideMultiLegReportingType (bs:byte[]) (pos:int) (len:int): SideMultiLegReportingType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> SideMultiLegReportingType.SingleSecurity
    |"2"B -> SideMultiLegReportingType.IndividualLegOfAMultiLegSecurity
    |"3"B -> SideMultiLegReportingType.MultiLegSecurity
    | x -> failwith (sprintf "ReadSideMultiLegReportingType unknown fix tag: %A"  x) 


let ReadNoPosAmt (bs:byte[]) (pos:int) (len:int): NoPosAmt =
    ReadFieldInt bs pos len NoPosAmt.NoPosAmt


let ReadAutoAcceptIndicator (bs:byte[]) (pos:int) (len:int): AutoAcceptIndicator =
    ReadFieldBool bs pos len AutoAcceptIndicator.AutoAcceptIndicator


let ReadAllocReportID (bs:byte[]) (pos:int) (len:int): AllocReportID =
    ReadFieldStr bs pos len AllocReportID.AllocReportID


let ReadNoNested2PartyIDs (bs:byte[]) (pos:int) (len:int): NoNested2PartyIDs =
    ReadFieldInt bs pos len NoNested2PartyIDs.NoNested2PartyIDs


let ReadNested2PartyID (bs:byte[]) (pos:int) (len:int): Nested2PartyID =
    ReadFieldStr bs pos len Nested2PartyID.Nested2PartyID


let ReadNested2PartyIDSource (bs:byte[]) (pos:int) (len:int): Nested2PartyIDSource =
    ReadFieldChar bs pos len Nested2PartyIDSource.Nested2PartyIDSource


let ReadNested2PartyRole (bs:byte[]) (pos:int) (len:int): Nested2PartyRole =
    ReadFieldInt bs pos len Nested2PartyRole.Nested2PartyRole


let ReadNested2PartySubID (bs:byte[]) (pos:int) (len:int): Nested2PartySubID =
    ReadFieldStr bs pos len Nested2PartySubID.Nested2PartySubID


let ReadBenchmarkSecurityIDSource (bs:byte[]) (pos:int) (len:int): BenchmarkSecurityIDSource =
    ReadFieldStr bs pos len BenchmarkSecurityIDSource.BenchmarkSecurityIDSource


let ReadSecuritySubType (bs:byte[]) (pos:int) (len:int): SecuritySubType =
    ReadFieldStr bs pos len SecuritySubType.SecuritySubType


let ReadUnderlyingSecuritySubType (bs:byte[]) (pos:int) (len:int): UnderlyingSecuritySubType =
    ReadFieldStr bs pos len UnderlyingSecuritySubType.UnderlyingSecuritySubType


let ReadLegSecuritySubType (bs:byte[]) (pos:int) (len:int): LegSecuritySubType =
    ReadFieldStr bs pos len LegSecuritySubType.LegSecuritySubType


let ReadAllowableOneSidednessPct (bs:byte[]) (pos:int) (len:int): AllowableOneSidednessPct =
    ReadFieldDecimal bs pos len AllowableOneSidednessPct.AllowableOneSidednessPct


let ReadAllowableOneSidednessValue (bs:byte[]) (pos:int) (len:int): AllowableOneSidednessValue =
    ReadFieldDecimal bs pos len AllowableOneSidednessValue.AllowableOneSidednessValue


let ReadAllowableOneSidednessCurr (bs:byte[]) (pos:int) (len:int): AllowableOneSidednessCurr =
    ReadFieldStr bs pos len AllowableOneSidednessCurr.AllowableOneSidednessCurr


let ReadNoTrdRegTimestamps (bs:byte[]) (pos:int) (len:int): NoTrdRegTimestamps =
    ReadFieldInt bs pos len NoTrdRegTimestamps.NoTrdRegTimestamps


let ReadTrdRegTimestamp (bs:byte[]) (pos:int) (len:int): TrdRegTimestamp =
    ReadFieldUTCTimestamp bs pos len TrdRegTimestamp.TrdRegTimestamp


let ReadTrdRegTimestampType (bs:byte[]) (pos:int) (len:int): TrdRegTimestampType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> TrdRegTimestampType.ExecutionTime
    |"2"B -> TrdRegTimestampType.TimeIn
    |"3"B -> TrdRegTimestampType.TimeOut
    |"4"B -> TrdRegTimestampType.BrokerReceipt
    |"5"B -> TrdRegTimestampType.BrokerExecution
    | x -> failwith (sprintf "ReadTrdRegTimestampType unknown fix tag: %A"  x) 


let ReadTrdRegTimestampOrigin (bs:byte[]) (pos:int) (len:int): TrdRegTimestampOrigin =
    ReadFieldStr bs pos len TrdRegTimestampOrigin.TrdRegTimestampOrigin


let ReadConfirmRefID (bs:byte[]) (pos:int) (len:int): ConfirmRefID =
    ReadFieldStr bs pos len ConfirmRefID.ConfirmRefID


let ReadConfirmType (bs:byte[]) (pos:int) (len:int): ConfirmType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ConfirmType.Status
    |"2"B -> ConfirmType.Confirmation
    |"3"B -> ConfirmType.ConfirmationRequestRejected
    | x -> failwith (sprintf "ReadConfirmType unknown fix tag: %A"  x) 


let ReadConfirmRejReason (bs:byte[]) (pos:int) (len:int): ConfirmRejReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> ConfirmRejReason.MismatchedAccount
    |"2"B -> ConfirmRejReason.MissingSettlementInstructions
    |"99"B -> ConfirmRejReason.Other
    | x -> failwith (sprintf "ReadConfirmRejReason unknown fix tag: %A"  x) 


let ReadBookingType (bs:byte[]) (pos:int) (len:int): BookingType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> BookingType.RegularBooking
    |"1"B -> BookingType.Cfd
    |"2"B -> BookingType.TotalReturnSwap
    | x -> failwith (sprintf "ReadBookingType unknown fix tag: %A"  x) 


let ReadIndividualAllocRejCode (bs:byte[]) (pos:int) (len:int): IndividualAllocRejCode =
    ReadFieldInt bs pos len IndividualAllocRejCode.IndividualAllocRejCode


let ReadSettlInstMsgID (bs:byte[]) (pos:int) (len:int): SettlInstMsgID =
    ReadFieldStr bs pos len SettlInstMsgID.SettlInstMsgID


let ReadNoSettlInst (bs:byte[]) (pos:int) (len:int): NoSettlInst =
    ReadFieldInt bs pos len NoSettlInst.NoSettlInst


let ReadLastUpdateTime (bs:byte[]) (pos:int) (len:int): LastUpdateTime =
    ReadFieldUTCTimestamp bs pos len LastUpdateTime.LastUpdateTime


let ReadAllocSettlInstType (bs:byte[]) (pos:int) (len:int): AllocSettlInstType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AllocSettlInstType.UseDefaultInstructions
    |"1"B -> AllocSettlInstType.DeriveFromParametersProvided
    |"2"B -> AllocSettlInstType.FullDetailsProvided
    |"3"B -> AllocSettlInstType.SsiDbIdsProvided
    |"4"B -> AllocSettlInstType.PhoneForInstructions
    | x -> failwith (sprintf "ReadAllocSettlInstType unknown fix tag: %A"  x) 


let ReadNoSettlPartyIDs (bs:byte[]) (pos:int) (len:int): NoSettlPartyIDs =
    ReadFieldInt bs pos len NoSettlPartyIDs.NoSettlPartyIDs


let ReadSettlPartyID (bs:byte[]) (pos:int) (len:int): SettlPartyID =
    ReadFieldStr bs pos len SettlPartyID.SettlPartyID


let ReadSettlPartyIDSource (bs:byte[]) (pos:int) (len:int): SettlPartyIDSource =
    ReadFieldChar bs pos len SettlPartyIDSource.SettlPartyIDSource


let ReadSettlPartyRole (bs:byte[]) (pos:int) (len:int): SettlPartyRole =
    ReadFieldInt bs pos len SettlPartyRole.SettlPartyRole


let ReadSettlPartySubID (bs:byte[]) (pos:int) (len:int): SettlPartySubID =
    ReadFieldStr bs pos len SettlPartySubID.SettlPartySubID


let ReadSettlPartySubIDType (bs:byte[]) (pos:int) (len:int): SettlPartySubIDType =
    ReadFieldInt bs pos len SettlPartySubIDType.SettlPartySubIDType


let ReadDlvyInstType (bs:byte[]) (pos:int) (len:int): DlvyInstType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"S"B -> DlvyInstType.Securities
    |"C"B -> DlvyInstType.Cash
    | x -> failwith (sprintf "ReadDlvyInstType unknown fix tag: %A"  x) 


let ReadTerminationType (bs:byte[]) (pos:int) (len:int): TerminationType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> TerminationType.Overnight
    |"2"B -> TerminationType.Term
    |"3"B -> TerminationType.Flexible
    |"4"B -> TerminationType.Open
    | x -> failwith (sprintf "ReadTerminationType unknown fix tag: %A"  x) 


let ReadNextExpectedMsgSeqNum (bs:byte[]) (pos:int) (len:int): NextExpectedMsgSeqNum =
    ReadFieldUInt bs pos len NextExpectedMsgSeqNum.NextExpectedMsgSeqNum


let ReadOrdStatusReqID (bs:byte[]) (pos:int) (len:int): OrdStatusReqID =
    ReadFieldStr bs pos len OrdStatusReqID.OrdStatusReqID


let ReadSettlInstReqID (bs:byte[]) (pos:int) (len:int): SettlInstReqID =
    ReadFieldStr bs pos len SettlInstReqID.SettlInstReqID


let ReadSettlInstReqRejCode (bs:byte[]) (pos:int) (len:int): SettlInstReqRejCode =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> SettlInstReqRejCode.UnableToProcessRequest
    |"1"B -> SettlInstReqRejCode.UnknownAccount
    |"2"B -> SettlInstReqRejCode.NoMatchingSettlementInstructionsFound
    |"99"B -> SettlInstReqRejCode.Other
    | x -> failwith (sprintf "ReadSettlInstReqRejCode unknown fix tag: %A"  x) 


let ReadSecondaryAllocID (bs:byte[]) (pos:int) (len:int): SecondaryAllocID =
    ReadFieldStr bs pos len SecondaryAllocID.SecondaryAllocID


let ReadAllocReportType (bs:byte[]) (pos:int) (len:int): AllocReportType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"3"B -> AllocReportType.SellsideCalculatedUsingPreliminary
    |"4"B -> AllocReportType.SellsideCalculatedWithoutPreliminary
    |"5"B -> AllocReportType.WarehouseRecap
    |"8"B -> AllocReportType.RequestToIntermediary
    | x -> failwith (sprintf "ReadAllocReportType unknown fix tag: %A"  x) 


let ReadAllocReportRefID (bs:byte[]) (pos:int) (len:int): AllocReportRefID =
    ReadFieldStr bs pos len AllocReportRefID.AllocReportRefID


let ReadAllocCancReplaceReason (bs:byte[]) (pos:int) (len:int): AllocCancReplaceReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AllocCancReplaceReason.OriginalDetailsIncompleteIncorrect
    |"2"B -> AllocCancReplaceReason.ChangeInUnderlyingOrderDetails
    | x -> failwith (sprintf "ReadAllocCancReplaceReason unknown fix tag: %A"  x) 


let ReadCopyMsgIndicator (bs:byte[]) (pos:int) (len:int): CopyMsgIndicator =
    ReadFieldBool bs pos len CopyMsgIndicator.CopyMsgIndicator


let ReadAllocAccountType (bs:byte[]) (pos:int) (len:int): AllocAccountType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AllocAccountType.AccountIsCarriedOnCustomerSideOfBooks
    |"2"B -> AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooks
    |"3"B -> AllocAccountType.HouseTrader
    |"4"B -> AllocAccountType.FloorTrader
    |"6"B -> AllocAccountType.AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
    |"7"B -> AllocAccountType.AccountIsHouseTraderAndIsCrossMargined
    |"8"B -> AllocAccountType.JointBackofficeAccount
    | x -> failwith (sprintf "ReadAllocAccountType unknown fix tag: %A"  x) 


let ReadOrderAvgPx (bs:byte[]) (pos:int) (len:int): OrderAvgPx =
    ReadFieldDecimal bs pos len OrderAvgPx.OrderAvgPx


let ReadOrderBookingQty (bs:byte[]) (pos:int) (len:int): OrderBookingQty =
    ReadFieldDecimal bs pos len OrderBookingQty.OrderBookingQty


let ReadNoSettlPartySubIDs (bs:byte[]) (pos:int) (len:int): NoSettlPartySubIDs =
    ReadFieldInt bs pos len NoSettlPartySubIDs.NoSettlPartySubIDs


let ReadNoPartySubIDs (bs:byte[]) (pos:int) (len:int): NoPartySubIDs =
    ReadFieldInt bs pos len NoPartySubIDs.NoPartySubIDs


let ReadPartySubIDType (bs:byte[]) (pos:int) (len:int): PartySubIDType =
    ReadFieldInt bs pos len PartySubIDType.PartySubIDType


let ReadNoNestedPartySubIDs (bs:byte[]) (pos:int) (len:int): NoNestedPartySubIDs =
    ReadFieldInt bs pos len NoNestedPartySubIDs.NoNestedPartySubIDs


let ReadNestedPartySubIDType (bs:byte[]) (pos:int) (len:int): NestedPartySubIDType =
    ReadFieldInt bs pos len NestedPartySubIDType.NestedPartySubIDType


let ReadNoNested2PartySubIDs (bs:byte[]) (pos:int) (len:int): NoNested2PartySubIDs =
    ReadFieldInt bs pos len NoNested2PartySubIDs.NoNested2PartySubIDs


let ReadNested2PartySubIDType (bs:byte[]) (pos:int) (len:int): Nested2PartySubIDType =
    ReadFieldInt bs pos len Nested2PartySubIDType.Nested2PartySubIDType


let ReadAllocIntermedReqType (bs:byte[]) (pos:int) (len:int): AllocIntermedReqType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AllocIntermedReqType.PendingAccept
    |"2"B -> AllocIntermedReqType.PendingRelease
    |"3"B -> AllocIntermedReqType.PendingReversal
    |"4"B -> AllocIntermedReqType.Accept
    |"5"B -> AllocIntermedReqType.BlockLevelReject
    |"6"B -> AllocIntermedReqType.AccountLevelReject
    | x -> failwith (sprintf "ReadAllocIntermedReqType unknown fix tag: %A"  x) 


let ReadUnderlyingPx (bs:byte[]) (pos:int) (len:int): UnderlyingPx =
    ReadFieldDecimal bs pos len UnderlyingPx.UnderlyingPx


let ReadPriceDelta (bs:byte[]) (pos:int) (len:int): PriceDelta =
    ReadFieldDecimal bs pos len PriceDelta.PriceDelta


let ReadApplQueueMax (bs:byte[]) (pos:int) (len:int): ApplQueueMax =
    ReadFieldInt bs pos len ApplQueueMax.ApplQueueMax


let ReadApplQueueDepth (bs:byte[]) (pos:int) (len:int): ApplQueueDepth =
    ReadFieldInt bs pos len ApplQueueDepth.ApplQueueDepth


let ReadApplQueueResolution (bs:byte[]) (pos:int) (len:int): ApplQueueResolution =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ApplQueueResolution.NoActionTaken
    |"1"B -> ApplQueueResolution.QueueFlushed
    |"2"B -> ApplQueueResolution.OverlayLast
    |"3"B -> ApplQueueResolution.EndSession
    | x -> failwith (sprintf "ReadApplQueueResolution unknown fix tag: %A"  x) 


let ReadApplQueueAction (bs:byte[]) (pos:int) (len:int): ApplQueueAction =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ApplQueueAction.NoActionTaken
    |"1"B -> ApplQueueAction.QueueFlushed
    |"2"B -> ApplQueueAction.OverlayLast
    |"3"B -> ApplQueueAction.EndSession
    | x -> failwith (sprintf "ReadApplQueueAction unknown fix tag: %A"  x) 


let ReadNoAltMDSource (bs:byte[]) (pos:int) (len:int): NoAltMDSource =
    ReadFieldInt bs pos len NoAltMDSource.NoAltMDSource


let ReadAltMDSourceID (bs:byte[]) (pos:int) (len:int): AltMDSourceID =
    ReadFieldStr bs pos len AltMDSourceID.AltMDSourceID


let ReadSecondaryTradeReportID (bs:byte[]) (pos:int) (len:int): SecondaryTradeReportID =
    ReadFieldStr bs pos len SecondaryTradeReportID.SecondaryTradeReportID


let ReadAvgPxIndicator (bs:byte[]) (pos:int) (len:int): AvgPxIndicator =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AvgPxIndicator.NoAveragePricing
    |"1"B -> AvgPxIndicator.TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid
    |"2"B -> AvgPxIndicator.LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid
    | x -> failwith (sprintf "ReadAvgPxIndicator unknown fix tag: %A"  x) 


let ReadTradeLinkID (bs:byte[]) (pos:int) (len:int): TradeLinkID =
    ReadFieldStr bs pos len TradeLinkID.TradeLinkID


let ReadOrderInputDevice (bs:byte[]) (pos:int) (len:int): OrderInputDevice =
    ReadFieldStr bs pos len OrderInputDevice.OrderInputDevice


let ReadUnderlyingTradingSessionID (bs:byte[]) (pos:int) (len:int): UnderlyingTradingSessionID =
    ReadFieldStr bs pos len UnderlyingTradingSessionID.UnderlyingTradingSessionID


let ReadUnderlyingTradingSessionSubID (bs:byte[]) (pos:int) (len:int): UnderlyingTradingSessionSubID =
    ReadFieldStr bs pos len UnderlyingTradingSessionSubID.UnderlyingTradingSessionSubID


let ReadTradeLegRefID (bs:byte[]) (pos:int) (len:int): TradeLegRefID =
    ReadFieldStr bs pos len TradeLegRefID.TradeLegRefID


let ReadExchangeRule (bs:byte[]) (pos:int) (len:int): ExchangeRule =
    ReadFieldStr bs pos len ExchangeRule.ExchangeRule


let ReadTradeAllocIndicator (bs:byte[]) (pos:int) (len:int): TradeAllocIndicator =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeAllocIndicator.AllocationNotRequired
    |"1"B -> TradeAllocIndicator.AllocationRequired
    |"2"B -> TradeAllocIndicator.UseAllocationProvidedWithTheTrade
    | x -> failwith (sprintf "ReadTradeAllocIndicator unknown fix tag: %A"  x) 


let ReadExpirationCycle (bs:byte[]) (pos:int) (len:int): ExpirationCycle =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ExpirationCycle.ExpireOnTradingSessionClose
    |"1"B -> ExpirationCycle.ExpireOnTradingSessionOpen
    | x -> failwith (sprintf "ReadExpirationCycle unknown fix tag: %A"  x) 


let ReadTrdType (bs:byte[]) (pos:int) (len:int): TrdType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TrdType.RegularTrade
    |"1"B -> TrdType.BlockTrade
    |"2"B -> TrdType.Efp
    |"3"B -> TrdType.Transfer
    |"4"B -> TrdType.LateTrade
    |"5"B -> TrdType.TTrade
    |"6"B -> TrdType.WeightedAveragePriceTrade
    |"7"B -> TrdType.BunchedTrade
    |"8"B -> TrdType.LateBunchedTrade
    |"9"B -> TrdType.PriorReferencePriceTrade
    |"10"B -> TrdType.AfterHoursTrade
    | x -> failwith (sprintf "ReadTrdType unknown fix tag: %A"  x) 


let ReadTrdSubType (bs:byte[]) (pos:int) (len:int): TrdSubType =
    ReadFieldInt bs pos len TrdSubType.TrdSubType


let ReadTransferReason (bs:byte[]) (pos:int) (len:int): TransferReason =
    ReadFieldStr bs pos len TransferReason.TransferReason


let ReadAsgnReqID (bs:byte[]) (pos:int) (len:int): AsgnReqID =
    ReadFieldStr bs pos len AsgnReqID.AsgnReqID


let ReadTotNumAssignmentReports (bs:byte[]) (pos:int) (len:int): TotNumAssignmentReports =
    ReadFieldInt bs pos len TotNumAssignmentReports.TotNumAssignmentReports


let ReadAsgnRptID (bs:byte[]) (pos:int) (len:int): AsgnRptID =
    ReadFieldStr bs pos len AsgnRptID.AsgnRptID


let ReadThresholdAmount (bs:byte[]) (pos:int) (len:int): ThresholdAmount =
    ReadFieldDecimal bs pos len ThresholdAmount.ThresholdAmount


let ReadPegMoveType (bs:byte[]) (pos:int) (len:int): PegMoveType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PegMoveType.Floating
    |"1"B -> PegMoveType.Fixed
    | x -> failwith (sprintf "ReadPegMoveType unknown fix tag: %A"  x) 


let ReadPegOffsetType (bs:byte[]) (pos:int) (len:int): PegOffsetType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PegOffsetType.Price
    |"1"B -> PegOffsetType.BasisPoints
    |"2"B -> PegOffsetType.Ticks
    |"3"B -> PegOffsetType.PriceTierLevel
    | x -> failwith (sprintf "ReadPegOffsetType unknown fix tag: %A"  x) 


let ReadPegLimitType (bs:byte[]) (pos:int) (len:int): PegLimitType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> PegLimitType.OrBetter
    |"1"B -> PegLimitType.Strict
    |"2"B -> PegLimitType.OrWorse
    | x -> failwith (sprintf "ReadPegLimitType unknown fix tag: %A"  x) 


let ReadPegRoundDirection (bs:byte[]) (pos:int) (len:int): PegRoundDirection =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PegRoundDirection.MoreAggressive
    |"2"B -> PegRoundDirection.MorePassive
    | x -> failwith (sprintf "ReadPegRoundDirection unknown fix tag: %A"  x) 


let ReadPeggedPrice (bs:byte[]) (pos:int) (len:int): PeggedPrice =
    ReadFieldDecimal bs pos len PeggedPrice.PeggedPrice


let ReadPegScope (bs:byte[]) (pos:int) (len:int): PegScope =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> PegScope.Local
    |"2"B -> PegScope.National
    |"3"B -> PegScope.Global
    |"4"B -> PegScope.NationalExcludingLocal
    | x -> failwith (sprintf "ReadPegScope unknown fix tag: %A"  x) 


let ReadDiscretionMoveType (bs:byte[]) (pos:int) (len:int): DiscretionMoveType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DiscretionMoveType.Floating
    |"1"B -> DiscretionMoveType.Fixed
    | x -> failwith (sprintf "ReadDiscretionMoveType unknown fix tag: %A"  x) 


let ReadDiscretionOffsetType (bs:byte[]) (pos:int) (len:int): DiscretionOffsetType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DiscretionOffsetType.Price
    |"1"B -> DiscretionOffsetType.BasisPoints
    |"2"B -> DiscretionOffsetType.Ticks
    |"3"B -> DiscretionOffsetType.PriceTierLevel
    | x -> failwith (sprintf "ReadDiscretionOffsetType unknown fix tag: %A"  x) 


let ReadDiscretionLimitType (bs:byte[]) (pos:int) (len:int): DiscretionLimitType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DiscretionLimitType.OrBetter
    |"1"B -> DiscretionLimitType.Strict
    |"2"B -> DiscretionLimitType.OrWorse
    | x -> failwith (sprintf "ReadDiscretionLimitType unknown fix tag: %A"  x) 


let ReadDiscretionRoundDirection (bs:byte[]) (pos:int) (len:int): DiscretionRoundDirection =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> DiscretionRoundDirection.MoreAggressive
    |"2"B -> DiscretionRoundDirection.MorePassive
    | x -> failwith (sprintf "ReadDiscretionRoundDirection unknown fix tag: %A"  x) 


let ReadDiscretionPrice (bs:byte[]) (pos:int) (len:int): DiscretionPrice =
    ReadFieldDecimal bs pos len DiscretionPrice.DiscretionPrice


let ReadDiscretionScope (bs:byte[]) (pos:int) (len:int): DiscretionScope =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> DiscretionScope.Local
    |"2"B -> DiscretionScope.National
    |"3"B -> DiscretionScope.Global
    |"4"B -> DiscretionScope.NationalExcludingLocal
    | x -> failwith (sprintf "ReadDiscretionScope unknown fix tag: %A"  x) 


let ReadTargetStrategy (bs:byte[]) (pos:int) (len:int): TargetStrategy =
    ReadFieldInt bs pos len TargetStrategy.TargetStrategy


let ReadTargetStrategyParameters (bs:byte[]) (pos:int) (len:int): TargetStrategyParameters =
    ReadFieldStr bs pos len TargetStrategyParameters.TargetStrategyParameters


let ReadParticipationRate (bs:byte[]) (pos:int) (len:int): ParticipationRate =
    ReadFieldDecimal bs pos len ParticipationRate.ParticipationRate


let ReadTargetStrategyPerformance (bs:byte[]) (pos:int) (len:int): TargetStrategyPerformance =
    ReadFieldDecimal bs pos len TargetStrategyPerformance.TargetStrategyPerformance


let ReadLastLiquidityInd (bs:byte[]) (pos:int) (len:int): LastLiquidityInd =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> LastLiquidityInd.AddedLiquidity
    |"2"B -> LastLiquidityInd.RemovedLiquidity
    |"3"B -> LastLiquidityInd.LiquidityRoutedOut
    | x -> failwith (sprintf "ReadLastLiquidityInd unknown fix tag: %A"  x) 


let ReadPublishTrdIndicator (bs:byte[]) (pos:int) (len:int): PublishTrdIndicator =
    ReadFieldBool bs pos len PublishTrdIndicator.PublishTrdIndicator


let ReadShortSaleReason (bs:byte[]) (pos:int) (len:int): ShortSaleReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> ShortSaleReason.DealerSoldShort
    |"1"B -> ShortSaleReason.DealerSoldShortExempt
    |"2"B -> ShortSaleReason.SellingCustomerSoldShort
    |"3"B -> ShortSaleReason.SellingCustomerSoldShortExempt
    |"4"B -> ShortSaleReason.QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort
    |"5"B -> ShortSaleReason.QsrOrAguContraSideSoldShortExempt
    | x -> failwith (sprintf "ReadShortSaleReason unknown fix tag: %A"  x) 


let ReadQtyType (bs:byte[]) (pos:int) (len:int): QtyType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> QtyType.Units
    |"1"B -> QtyType.Contracts
    | x -> failwith (sprintf "ReadQtyType unknown fix tag: %A"  x) 


let ReadSecondaryTrdType (bs:byte[]) (pos:int) (len:int): SecondaryTrdType =
    ReadFieldInt bs pos len SecondaryTrdType.SecondaryTrdType


let ReadTradeReportType (bs:byte[]) (pos:int) (len:int): TradeReportType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TradeReportType.Submit
    |"1"B -> TradeReportType.Alleged
    |"2"B -> TradeReportType.Accept
    |"3"B -> TradeReportType.Decline
    |"4"B -> TradeReportType.Addendum
    |"5"B -> TradeReportType.NoWas
    |"6"B -> TradeReportType.TradeReportCancel
    |"7"B -> TradeReportType.LockedInTradeBreak
    | x -> failwith (sprintf "ReadTradeReportType unknown fix tag: %A"  x) 


let ReadAllocNoOrdersType (bs:byte[]) (pos:int) (len:int): AllocNoOrdersType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> AllocNoOrdersType.NotSpecified
    |"1"B -> AllocNoOrdersType.ExplicitListProvided
    | x -> failwith (sprintf "ReadAllocNoOrdersType unknown fix tag: %A"  x) 


let ReadSharedCommission (bs:byte[]) (pos:int) (len:int): SharedCommission =
    ReadFieldDecimal bs pos len SharedCommission.SharedCommission


let ReadConfirmReqID (bs:byte[]) (pos:int) (len:int): ConfirmReqID =
    ReadFieldStr bs pos len ConfirmReqID.ConfirmReqID


let ReadAvgParPx (bs:byte[]) (pos:int) (len:int): AvgParPx =
    ReadFieldDecimal bs pos len AvgParPx.AvgParPx


let ReadReportedPx (bs:byte[]) (pos:int) (len:int): ReportedPx =
    ReadFieldDecimal bs pos len ReportedPx.ReportedPx


let ReadNoCapacities (bs:byte[]) (pos:int) (len:int): NoCapacities =
    ReadFieldInt bs pos len NoCapacities.NoCapacities


let ReadOrderCapacityQty (bs:byte[]) (pos:int) (len:int): OrderCapacityQty =
    ReadFieldDecimal bs pos len OrderCapacityQty.OrderCapacityQty


let ReadNoEvents (bs:byte[]) (pos:int) (len:int): NoEvents =
    ReadFieldInt bs pos len NoEvents.NoEvents


let ReadEventType (bs:byte[]) (pos:int) (len:int): EventType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> EventType.Put
    |"2"B -> EventType.Call
    |"3"B -> EventType.Tender
    |"4"B -> EventType.SinkingFundCall
    |"99"B -> EventType.Other
    | x -> failwith (sprintf "ReadEventType unknown fix tag: %A"  x) 


let ReadEventDate (bs:byte[]) (pos:int) (len:int): EventDate =
    ReadFieldLocalMktDate bs pos len EventDate.EventDate


let ReadEventPx (bs:byte[]) (pos:int) (len:int): EventPx =
    ReadFieldDecimal bs pos len EventPx.EventPx


let ReadEventText (bs:byte[]) (pos:int) (len:int): EventText =
    ReadFieldStr bs pos len EventText.EventText


let ReadPctAtRisk (bs:byte[]) (pos:int) (len:int): PctAtRisk =
    ReadFieldDecimal bs pos len PctAtRisk.PctAtRisk


let ReadNoInstrAttrib (bs:byte[]) (pos:int) (len:int): NoInstrAttrib =
    ReadFieldInt bs pos len NoInstrAttrib.NoInstrAttrib


let ReadInstrAttribType (bs:byte[]) (pos:int) (len:int): InstrAttribType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> InstrAttribType.Flat
    |"2"B -> InstrAttribType.ZeroCoupon
    |"3"B -> InstrAttribType.InterestBearing
    |"4"B -> InstrAttribType.NoPeriodicPayments
    |"5"B -> InstrAttribType.VariableRate
    |"6"B -> InstrAttribType.LessFeeForPut
    |"7"B -> InstrAttribType.SteppedCoupon
    |"8"B -> InstrAttribType.CouponPeriod
    |"9"B -> InstrAttribType.WhenAndIfIssued
    |"10"B -> InstrAttribType.OriginalIssueDiscount
    |"11"B -> InstrAttribType.CallablePuttable
    |"12"B -> InstrAttribType.EscrowedToMaturity
    |"13"B -> InstrAttribType.EscrowedToRedemptionDate
    |"14"B -> InstrAttribType.PreRefunded
    |"15"B -> InstrAttribType.InDefault
    |"16"B -> InstrAttribType.Unrated
    |"17"B -> InstrAttribType.Taxable
    |"18"B -> InstrAttribType.Indexed
    |"19"B -> InstrAttribType.SubjectToAlternativeMinimumTax
    |"20"B -> InstrAttribType.OriginalIssueDiscountPrice
    |"21"B -> InstrAttribType.CallableBelowMaturityValue
    |"22"B -> InstrAttribType.CallableWithoutNoticeByMailToHolderUnlessRegistered
    |"99"B -> InstrAttribType.Text
    | x -> failwith (sprintf "ReadInstrAttribType unknown fix tag: %A"  x) 


let ReadInstrAttribValue (bs:byte[]) (pos:int) (len:int): InstrAttribValue =
    ReadFieldStr bs pos len InstrAttribValue.InstrAttribValue


let ReadDatedDate (bs:byte[]) (pos:int) (len:int): DatedDate =
    ReadFieldLocalMktDate bs pos len DatedDate.DatedDate


let ReadInterestAccrualDate (bs:byte[]) (pos:int) (len:int): InterestAccrualDate =
    ReadFieldLocalMktDate bs pos len InterestAccrualDate.InterestAccrualDate


let ReadCPProgram (bs:byte[]) (pos:int) (len:int): CPProgram =
    ReadFieldInt bs pos len CPProgram.CPProgram


let ReadCPRegType (bs:byte[]) (pos:int) (len:int): CPRegType =
    ReadFieldStr bs pos len CPRegType.CPRegType


let ReadUnderlyingCPProgram (bs:byte[]) (pos:int) (len:int): UnderlyingCPProgram =
    ReadFieldStr bs pos len UnderlyingCPProgram.UnderlyingCPProgram


let ReadUnderlyingCPRegType (bs:byte[]) (pos:int) (len:int): UnderlyingCPRegType =
    ReadFieldStr bs pos len UnderlyingCPRegType.UnderlyingCPRegType


let ReadUnderlyingQty (bs:byte[]) (pos:int) (len:int): UnderlyingQty =
    ReadFieldDecimal bs pos len UnderlyingQty.UnderlyingQty


let ReadTrdMatchID (bs:byte[]) (pos:int) (len:int): TrdMatchID =
    ReadFieldStr bs pos len TrdMatchID.TrdMatchID


let ReadSecondaryTradeReportRefID (bs:byte[]) (pos:int) (len:int): SecondaryTradeReportRefID =
    ReadFieldStr bs pos len SecondaryTradeReportRefID.SecondaryTradeReportRefID


let ReadUnderlyingDirtyPrice (bs:byte[]) (pos:int) (len:int): UnderlyingDirtyPrice =
    ReadFieldDecimal bs pos len UnderlyingDirtyPrice.UnderlyingDirtyPrice


let ReadUnderlyingEndPrice (bs:byte[]) (pos:int) (len:int): UnderlyingEndPrice =
    ReadFieldDecimal bs pos len UnderlyingEndPrice.UnderlyingEndPrice


let ReadUnderlyingStartValue (bs:byte[]) (pos:int) (len:int): UnderlyingStartValue =
    ReadFieldDecimal bs pos len UnderlyingStartValue.UnderlyingStartValue


let ReadUnderlyingCurrentValue (bs:byte[]) (pos:int) (len:int): UnderlyingCurrentValue =
    ReadFieldDecimal bs pos len UnderlyingCurrentValue.UnderlyingCurrentValue


let ReadUnderlyingEndValue (bs:byte[]) (pos:int) (len:int): UnderlyingEndValue =
    ReadFieldDecimal bs pos len UnderlyingEndValue.UnderlyingEndValue


let ReadNoUnderlyingStips (bs:byte[]) (pos:int) (len:int): NoUnderlyingStips =
    ReadFieldInt bs pos len NoUnderlyingStips.NoUnderlyingStips


let ReadUnderlyingStipType (bs:byte[]) (pos:int) (len:int): UnderlyingStipType =
    ReadFieldStr bs pos len UnderlyingStipType.UnderlyingStipType


let ReadUnderlyingStipValue (bs:byte[]) (pos:int) (len:int): UnderlyingStipValue =
    ReadFieldStr bs pos len UnderlyingStipValue.UnderlyingStipValue


let ReadMaturityNetMoney (bs:byte[]) (pos:int) (len:int): MaturityNetMoney =
    ReadFieldDecimal bs pos len MaturityNetMoney.MaturityNetMoney


let ReadMiscFeeBasis (bs:byte[]) (pos:int) (len:int): MiscFeeBasis =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> MiscFeeBasis.Absolute
    |"1"B -> MiscFeeBasis.PerUnit
    |"2"B -> MiscFeeBasis.Percentage
    | x -> failwith (sprintf "ReadMiscFeeBasis unknown fix tag: %A"  x) 


let ReadTotNoAllocs (bs:byte[]) (pos:int) (len:int): TotNoAllocs =
    ReadFieldInt bs pos len TotNoAllocs.TotNoAllocs


let ReadLastFragment (bs:byte[]) (pos:int) (len:int): LastFragment =
    ReadFieldBool bs pos len LastFragment.LastFragment


let ReadCollReqID (bs:byte[]) (pos:int) (len:int): CollReqID =
    ReadFieldStr bs pos len CollReqID.CollReqID


let ReadCollAsgnReason (bs:byte[]) (pos:int) (len:int): CollAsgnReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollAsgnReason.Initial
    |"1"B -> CollAsgnReason.Scheduled
    |"2"B -> CollAsgnReason.TimeWarning
    |"3"B -> CollAsgnReason.MarginDeficiency
    |"4"B -> CollAsgnReason.MarginExcess
    |"5"B -> CollAsgnReason.ForwardCollateralDemand
    |"6"B -> CollAsgnReason.EventOfDefault
    |"7"B -> CollAsgnReason.AdverseTaxEvent
    | x -> failwith (sprintf "ReadCollAsgnReason unknown fix tag: %A"  x) 


let ReadCollInquiryQualifier (bs:byte[]) (pos:int) (len:int): CollInquiryQualifier =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollInquiryQualifier.Tradedate
    |"1"B -> CollInquiryQualifier.GcInstrument
    |"2"B -> CollInquiryQualifier.Collateralinstrument
    |"3"B -> CollInquiryQualifier.SubstitutionEligible
    |"4"B -> CollInquiryQualifier.NotAssigned
    |"5"B -> CollInquiryQualifier.PartiallyAssigned
    |"6"B -> CollInquiryQualifier.FullyAssigned
    |"7"B -> CollInquiryQualifier.OutstandingTrades
    | x -> failwith (sprintf "ReadCollInquiryQualifier unknown fix tag: %A"  x) 


let ReadNoTrades (bs:byte[]) (pos:int) (len:int): NoTrades =
    ReadFieldInt bs pos len NoTrades.NoTrades


let ReadMarginRatio (bs:byte[]) (pos:int) (len:int): MarginRatio =
    ReadFieldDecimal bs pos len MarginRatio.MarginRatio


let ReadMarginExcess (bs:byte[]) (pos:int) (len:int): MarginExcess =
    ReadFieldDecimal bs pos len MarginExcess.MarginExcess


let ReadTotalNetValue (bs:byte[]) (pos:int) (len:int): TotalNetValue =
    ReadFieldDecimal bs pos len TotalNetValue.TotalNetValue


let ReadCashOutstanding (bs:byte[]) (pos:int) (len:int): CashOutstanding =
    ReadFieldDecimal bs pos len CashOutstanding.CashOutstanding


let ReadCollAsgnID (bs:byte[]) (pos:int) (len:int): CollAsgnID =
    ReadFieldStr bs pos len CollAsgnID.CollAsgnID


let ReadCollAsgnTransType (bs:byte[]) (pos:int) (len:int): CollAsgnTransType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollAsgnTransType.New
    |"1"B -> CollAsgnTransType.Replace
    |"2"B -> CollAsgnTransType.Cancel
    |"3"B -> CollAsgnTransType.Release
    |"4"B -> CollAsgnTransType.Reverse
    | x -> failwith (sprintf "ReadCollAsgnTransType unknown fix tag: %A"  x) 


let ReadCollRespID (bs:byte[]) (pos:int) (len:int): CollRespID =
    ReadFieldStr bs pos len CollRespID.CollRespID


let ReadCollAsgnRespType (bs:byte[]) (pos:int) (len:int): CollAsgnRespType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollAsgnRespType.Received
    |"1"B -> CollAsgnRespType.Accepted
    |"2"B -> CollAsgnRespType.Declined
    |"3"B -> CollAsgnRespType.Rejected
    | x -> failwith (sprintf "ReadCollAsgnRespType unknown fix tag: %A"  x) 


let ReadCollAsgnRejectReason (bs:byte[]) (pos:int) (len:int): CollAsgnRejectReason =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollAsgnRejectReason.UnknownDeal
    |"1"B -> CollAsgnRejectReason.UnknownOrInvalidInstrument
    |"2"B -> CollAsgnRejectReason.UnauthorizedTransaction
    |"3"B -> CollAsgnRejectReason.InsufficientCollateral
    |"4"B -> CollAsgnRejectReason.InvalidTypeOfCollateral
    |"5"B -> CollAsgnRejectReason.ExcessiveSubstitution
    |"99"B -> CollAsgnRejectReason.Other
    | x -> failwith (sprintf "ReadCollAsgnRejectReason unknown fix tag: %A"  x) 


let ReadCollAsgnRefID (bs:byte[]) (pos:int) (len:int): CollAsgnRefID =
    ReadFieldStr bs pos len CollAsgnRefID.CollAsgnRefID


let ReadCollRptID (bs:byte[]) (pos:int) (len:int): CollRptID =
    ReadFieldStr bs pos len CollRptID.CollRptID


let ReadCollInquiryID (bs:byte[]) (pos:int) (len:int): CollInquiryID =
    ReadFieldStr bs pos len CollInquiryID.CollInquiryID


let ReadCollStatus (bs:byte[]) (pos:int) (len:int): CollStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollStatus.Unassigned
    |"1"B -> CollStatus.PartiallyAssigned
    |"2"B -> CollStatus.AssignmentProposed
    |"3"B -> CollStatus.Assigned
    |"4"B -> CollStatus.Challenged
    | x -> failwith (sprintf "ReadCollStatus unknown fix tag: %A"  x) 


let ReadTotNumReports (bs:byte[]) (pos:int) (len:int): TotNumReports =
    ReadFieldInt bs pos len TotNumReports.TotNumReports


let ReadLastRptRequested (bs:byte[]) (pos:int) (len:int): LastRptRequested =
    ReadFieldBool bs pos len LastRptRequested.LastRptRequested


let ReadAgreementDesc (bs:byte[]) (pos:int) (len:int): AgreementDesc =
    ReadFieldStr bs pos len AgreementDesc.AgreementDesc


let ReadAgreementID (bs:byte[]) (pos:int) (len:int): AgreementID =
    ReadFieldStr bs pos len AgreementID.AgreementID


let ReadAgreementDate (bs:byte[]) (pos:int) (len:int): AgreementDate =
    ReadFieldLocalMktDate bs pos len AgreementDate.AgreementDate


let ReadStartDate (bs:byte[]) (pos:int) (len:int): StartDate =
    ReadFieldLocalMktDate bs pos len StartDate.StartDate


let ReadEndDate (bs:byte[]) (pos:int) (len:int): EndDate =
    ReadFieldLocalMktDate bs pos len EndDate.EndDate


let ReadAgreementCurrency (bs:byte[]) (pos:int) (len:int): AgreementCurrency =
    ReadFieldStr bs pos len AgreementCurrency.AgreementCurrency


let ReadDeliveryType (bs:byte[]) (pos:int) (len:int): DeliveryType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> DeliveryType.VersusPayment
    |"1"B -> DeliveryType.Free
    |"2"B -> DeliveryType.TriParty
    |"3"B -> DeliveryType.HoldInCustody
    | x -> failwith (sprintf "ReadDeliveryType unknown fix tag: %A"  x) 


let ReadEndAccruedInterestAmt (bs:byte[]) (pos:int) (len:int): EndAccruedInterestAmt =
    ReadFieldDecimal bs pos len EndAccruedInterestAmt.EndAccruedInterestAmt


let ReadStartCash (bs:byte[]) (pos:int) (len:int): StartCash =
    ReadFieldDecimal bs pos len StartCash.StartCash


let ReadEndCash (bs:byte[]) (pos:int) (len:int): EndCash =
    ReadFieldDecimal bs pos len EndCash.EndCash


let ReadUserRequestID (bs:byte[]) (pos:int) (len:int): UserRequestID =
    ReadFieldStr bs pos len UserRequestID.UserRequestID


let ReadUserRequestType (bs:byte[]) (pos:int) (len:int): UserRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> UserRequestType.Logonuser
    |"2"B -> UserRequestType.Logoffuser
    |"3"B -> UserRequestType.Changepasswordforuser
    |"4"B -> UserRequestType.RequestIndividualUserStatus
    | x -> failwith (sprintf "ReadUserRequestType unknown fix tag: %A"  x) 


let ReadNewPassword (bs:byte[]) (pos:int) (len:int): NewPassword =
    ReadFieldStr bs pos len NewPassword.NewPassword


let ReadUserStatus (bs:byte[]) (pos:int) (len:int): UserStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> UserStatus.LoggedIn
    |"2"B -> UserStatus.NotLoggedIn
    |"3"B -> UserStatus.UserNotRecognised
    |"4"B -> UserStatus.PasswordIncorrect
    |"5"B -> UserStatus.PasswordChanged
    |"6"B -> UserStatus.Other
    | x -> failwith (sprintf "ReadUserStatus unknown fix tag: %A"  x) 


let ReadUserStatusText (bs:byte[]) (pos:int) (len:int): UserStatusText =
    ReadFieldStr bs pos len UserStatusText.UserStatusText


let ReadStatusValue (bs:byte[]) (pos:int) (len:int): StatusValue =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> StatusValue.Connected
    |"2"B -> StatusValue.NotConnectedDownExpectedUp
    |"3"B -> StatusValue.NotConnectedDownExpectedDown
    |"4"B -> StatusValue.InProcess
    | x -> failwith (sprintf "ReadStatusValue unknown fix tag: %A"  x) 


let ReadStatusText (bs:byte[]) (pos:int) (len:int): StatusText =
    ReadFieldStr bs pos len StatusText.StatusText


let ReadRefCompID (bs:byte[]) (pos:int) (len:int): RefCompID =
    ReadFieldStr bs pos len RefCompID.RefCompID


let ReadRefSubID (bs:byte[]) (pos:int) (len:int): RefSubID =
    ReadFieldStr bs pos len RefSubID.RefSubID


let ReadNetworkResponseID (bs:byte[]) (pos:int) (len:int): NetworkResponseID =
    ReadFieldStr bs pos len NetworkResponseID.NetworkResponseID


let ReadNetworkRequestID (bs:byte[]) (pos:int) (len:int): NetworkRequestID =
    ReadFieldStr bs pos len NetworkRequestID.NetworkRequestID


let ReadLastNetworkResponseID (bs:byte[]) (pos:int) (len:int): LastNetworkResponseID =
    ReadFieldStr bs pos len LastNetworkResponseID.LastNetworkResponseID


let ReadNetworkRequestType (bs:byte[]) (pos:int) (len:int): NetworkRequestType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> NetworkRequestType.Snapshot
    |"2"B -> NetworkRequestType.Subscribe
    |"4"B -> NetworkRequestType.StopSubscribing
    |"8"B -> NetworkRequestType.LevelOfDetail
    | x -> failwith (sprintf "ReadNetworkRequestType unknown fix tag: %A"  x) 


let ReadNoCompIDs (bs:byte[]) (pos:int) (len:int): NoCompIDs =
    ReadFieldInt bs pos len NoCompIDs.NoCompIDs


let ReadNetworkStatusResponseType (bs:byte[]) (pos:int) (len:int): NetworkStatusResponseType =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> NetworkStatusResponseType.Full
    |"2"B -> NetworkStatusResponseType.IncrementalUpdate
    | x -> failwith (sprintf "ReadNetworkStatusResponseType unknown fix tag: %A"  x) 


let ReadNoCollInquiryQualifier (bs:byte[]) (pos:int) (len:int): NoCollInquiryQualifier =
    ReadFieldInt bs pos len NoCollInquiryQualifier.NoCollInquiryQualifier


let ReadTrdRptStatus (bs:byte[]) (pos:int) (len:int): TrdRptStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> TrdRptStatus.Accepted
    |"1"B -> TrdRptStatus.Rejected
    | x -> failwith (sprintf "ReadTrdRptStatus unknown fix tag: %A"  x) 


let ReadAffirmStatus (bs:byte[]) (pos:int) (len:int): AffirmStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"1"B -> AffirmStatus.Received
    |"2"B -> AffirmStatus.ConfirmRejected
    |"3"B -> AffirmStatus.Affirmed
    | x -> failwith (sprintf "ReadAffirmStatus unknown fix tag: %A"  x) 


let ReadUnderlyingStrikeCurrency (bs:byte[]) (pos:int) (len:int): UnderlyingStrikeCurrency =
    ReadFieldStr bs pos len UnderlyingStrikeCurrency.UnderlyingStrikeCurrency


let ReadLegStrikeCurrency (bs:byte[]) (pos:int) (len:int): LegStrikeCurrency =
    ReadFieldStr bs pos len LegStrikeCurrency.LegStrikeCurrency


let ReadTimeBracket (bs:byte[]) (pos:int) (len:int): TimeBracket =
    ReadFieldStr bs pos len TimeBracket.TimeBracket


let ReadCollAction (bs:byte[]) (pos:int) (len:int): CollAction =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollAction.Retain
    |"1"B -> CollAction.Add
    |"2"B -> CollAction.Remove
    | x -> failwith (sprintf "ReadCollAction unknown fix tag: %A"  x) 


let ReadCollInquiryStatus (bs:byte[]) (pos:int) (len:int): CollInquiryStatus =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollInquiryStatus.Accepted
    |"1"B -> CollInquiryStatus.AcceptedWithWarnings
    |"2"B -> CollInquiryStatus.Completed
    |"3"B -> CollInquiryStatus.CompletedWithWarnings
    |"4"B -> CollInquiryStatus.Rejected
    | x -> failwith (sprintf "ReadCollInquiryStatus unknown fix tag: %A"  x) 


let ReadCollInquiryResult (bs:byte[]) (pos:int) (len:int): CollInquiryResult =
    let tagBs = Array.zeroCreate<byte> len
    Array.Copy( bs, pos, tagBs, 0, len)
    match tagBs with
    |"0"B -> CollInquiryResult.Successful
    |"1"B -> CollInquiryResult.InvalidOrUnknownInstrument
    |"2"B -> CollInquiryResult.InvalidOrUnknownCollateralType
    |"3"B -> CollInquiryResult.InvalidParties
    |"4"B -> CollInquiryResult.InvalidTransportTypeRequested
    |"5"B -> CollInquiryResult.InvalidDestinationRequested
    |"6"B -> CollInquiryResult.NoCollateralFoundForTheTradeSpecified
    |"7"B -> CollInquiryResult.NoCollateralFoundForTheOrderSpecified
    |"8"B -> CollInquiryResult.CollateralInquiryTypeNotSupported
    |"9"B -> CollInquiryResult.UnauthorizedForCollateralInquiry
    |"99"B -> CollInquiryResult.Other
    | x -> failwith (sprintf "ReadCollInquiryResult unknown fix tag: %A"  x) 


let ReadStrikeCurrency (bs:byte[]) (pos:int) (len:int): StrikeCurrency =
    ReadFieldStr bs pos len StrikeCurrency.StrikeCurrency


let ReadNoNested3PartyIDs (bs:byte[]) (pos:int) (len:int): NoNested3PartyIDs =
    ReadFieldInt bs pos len NoNested3PartyIDs.NoNested3PartyIDs


let ReadNested3PartyID (bs:byte[]) (pos:int) (len:int): Nested3PartyID =
    ReadFieldStr bs pos len Nested3PartyID.Nested3PartyID


let ReadNested3PartyIDSource (bs:byte[]) (pos:int) (len:int): Nested3PartyIDSource =
    ReadFieldChar bs pos len Nested3PartyIDSource.Nested3PartyIDSource


let ReadNested3PartyRole (bs:byte[]) (pos:int) (len:int): Nested3PartyRole =
    ReadFieldInt bs pos len Nested3PartyRole.Nested3PartyRole


let ReadNoNested3PartySubIDs (bs:byte[]) (pos:int) (len:int): NoNested3PartySubIDs =
    ReadFieldInt bs pos len NoNested3PartySubIDs.NoNested3PartySubIDs


let ReadNested3PartySubID (bs:byte[]) (pos:int) (len:int): Nested3PartySubID =
    ReadFieldStr bs pos len Nested3PartySubID.Nested3PartySubID


let ReadNested3PartySubIDType (bs:byte[]) (pos:int) (len:int): Nested3PartySubIDType =
    ReadFieldInt bs pos len Nested3PartySubIDType.Nested3PartySubIDType


let ReadLegContractSettlMonth (bs:byte[]) (pos:int) (len:int): LegContractSettlMonth =
    ReadFieldMonthYear bs pos len LegContractSettlMonth.LegContractSettlMonth


let ReadLegInterestAccrualDate (bs:byte[]) (pos:int) (len:int): LegInterestAccrualDate =
    ReadFieldLocalMktDate bs pos len LegInterestAccrualDate.LegInterestAccrualDate


