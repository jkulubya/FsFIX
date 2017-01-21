module Fix44.FieldDU


open Fix44.Fields
open Fix44.FieldReaders
open Fix44.FieldWriters


type FIXField =
    | Account of Account
    | AdvId of AdvId
    | AdvRefID of AdvRefID
    | AdvSide of AdvSide
    | AdvTransType of AdvTransType
    | AvgPx of AvgPx
    | BeginSeqNo of BeginSeqNo
    | BeginString of BeginString
    | BodyLength of BodyLength
    | CheckSum of CheckSum
    | ClOrdID of ClOrdID
    | Commission of Commission
    | CommType of CommType
    | CumQty of CumQty
    | Currency of Currency
    | EndSeqNo of EndSeqNo
    | ExecID of ExecID
    | ExecInst of ExecInst
    | ExecRefID of ExecRefID
    | HandlInst of HandlInst
    | SecurityIDSource of SecurityIDSource
    | IOIid of IOIid
    | IOIQltyInd of IOIQltyInd
    | IOIRefID of IOIRefID
    | IOIQty of IOIQty
    | IOITransType of IOITransType
    | LastCapacity of LastCapacity
    | LastMkt of LastMkt
    | LastPx of LastPx
    | LastQty of LastQty
    | LinesOfText of LinesOfText
    | MsgSeqNum of MsgSeqNum
    | MsgType of MsgType
    | NewSeqNo of NewSeqNo
    | OrderID of OrderID
    | OrderQty of OrderQty
    | OrdStatus of OrdStatus
    | OrdType of OrdType
    | OrigClOrdID of OrigClOrdID
    | OrigTime of OrigTime
    | PossDupFlag of PossDupFlag
    | Price of Price
    | RefSeqNum of RefSeqNum
    | SecurityID of SecurityID
    | SenderCompID of SenderCompID
    | SenderSubID of SenderSubID
    | SendingTime of SendingTime
    | Quantity of Quantity
    | Side of Side
    | Symbol of Symbol
    | TargetCompID of TargetCompID
    | TargetSubID of TargetSubID
    | Text of Text
    | TimeInForce of TimeInForce
    | TransactTime of TransactTime
    | Urgency of Urgency
    | ValidUntilTime of ValidUntilTime
    | SettlType of SettlType
    | SettlDate of SettlDate
    | SymbolSfx of SymbolSfx
    | ListID of ListID
    | ListSeqNo of ListSeqNo
    | TotNoOrders of TotNoOrders
    | ListExecInst of ListExecInst
    | AllocID of AllocID
    | AllocTransType of AllocTransType
    | RefAllocID of RefAllocID
    | NoOrders of NoOrders
    | AvgPxPrecision of AvgPxPrecision
    | TradeDate of TradeDate
    | PositionEffect of PositionEffect
    | NoAllocs of NoAllocs
    | AllocAccount of AllocAccount
    | AllocQty of AllocQty
    | ProcessCode of ProcessCode
    | NoRpts of NoRpts
    | RptSeq of RptSeq
    | CxlQty of CxlQty
    | NoDlvyInst of NoDlvyInst
    | AllocStatus of AllocStatus
    | AllocRejCode of AllocRejCode
    | Signature of Signature
    | SecureData of SecureData
    | EmailType of EmailType
    | RawData of RawData
    | PossResend of PossResend
    | EncryptMethod of EncryptMethod
    | StopPx of StopPx
    | ExDestination of ExDestination
    | CxlRejReason of CxlRejReason
    | OrdRejReason of OrdRejReason
    | IOIQualifier of IOIQualifier
    | WaveNo of WaveNo
    | Issuer of Issuer
    | SecurityDesc of SecurityDesc
    | HeartBtInt of HeartBtInt
    | MinQty of MinQty
    | MaxFloor of MaxFloor
    | TestReqID of TestReqID
    | ReportToExch of ReportToExch
    | LocateReqd of LocateReqd
    | OnBehalfOfCompID of OnBehalfOfCompID
    | OnBehalfOfSubID of OnBehalfOfSubID
    | QuoteID of QuoteID
    | NetMoney of NetMoney
    | SettlCurrAmt of SettlCurrAmt
    | SettlCurrency of SettlCurrency
    | ForexReq of ForexReq
    | OrigSendingTime of OrigSendingTime
    | GapFillFlag of GapFillFlag
    | NoExecs of NoExecs
    | ExpireTime of ExpireTime
    | DKReason of DKReason
    | DeliverToCompID of DeliverToCompID
    | DeliverToSubID of DeliverToSubID
    | IOINaturalFlag of IOINaturalFlag
    | QuoteReqID of QuoteReqID
    | BidPx of BidPx
    | OfferPx of OfferPx
    | BidSize of BidSize
    | OfferSize of OfferSize
    | NoMiscFees of NoMiscFees
    | MiscFeeAmt of MiscFeeAmt
    | MiscFeeCurr of MiscFeeCurr
    | MiscFeeType of MiscFeeType
    | PrevClosePx of PrevClosePx
    | ResetSeqNumFlag of ResetSeqNumFlag
    | SenderLocationID of SenderLocationID
    | TargetLocationID of TargetLocationID
    | OnBehalfOfLocationID of OnBehalfOfLocationID
    | DeliverToLocationID of DeliverToLocationID
    | NoRelatedSym of NoRelatedSym
    | Subject of Subject
    | Headline of Headline
    | URLLink of URLLink
    | ExecType of ExecType
    | LeavesQty of LeavesQty
    | CashOrderQty of CashOrderQty
    | AllocAvgPx of AllocAvgPx
    | AllocNetMoney of AllocNetMoney
    | SettlCurrFxRate of SettlCurrFxRate
    | SettlCurrFxRateCalc of SettlCurrFxRateCalc
    | NumDaysInterest of NumDaysInterest
    | AccruedInterestRate of AccruedInterestRate
    | AccruedInterestAmt of AccruedInterestAmt
    | SettlInstMode of SettlInstMode
    | AllocText of AllocText
    | SettlInstID of SettlInstID
    | SettlInstTransType of SettlInstTransType
    | EmailThreadID of EmailThreadID
    | SettlInstSource of SettlInstSource
    | SecurityType of SecurityType
    | EffectiveTime of EffectiveTime
    | StandInstDbType of StandInstDbType
    | StandInstDbName of StandInstDbName
    | StandInstDbID of StandInstDbID
    | SettlDeliveryType of SettlDeliveryType
    | BidSpotRate of BidSpotRate
    | BidForwardPoints of BidForwardPoints
    | OfferSpotRate of OfferSpotRate
    | OfferForwardPoints of OfferForwardPoints
    | OrderQty2 of OrderQty2
    | SettlDate2 of SettlDate2
    | LastSpotRate of LastSpotRate
    | LastForwardPoints of LastForwardPoints
    | AllocLinkID of AllocLinkID
    | AllocLinkType of AllocLinkType
    | SecondaryOrderID of SecondaryOrderID
    | NoIOIQualifiers of NoIOIQualifiers
    | MaturityMonthYear of MaturityMonthYear
    | PutOrCall of PutOrCall
    | StrikePrice of StrikePrice
    | CoveredOrUncovered of CoveredOrUncovered
    | OptAttribute of OptAttribute
    | SecurityExchange of SecurityExchange
    | NotifyBrokerOfCredit of NotifyBrokerOfCredit
    | AllocHandlInst of AllocHandlInst
    | MaxShow of MaxShow
    | PegOffsetValue of PegOffsetValue
    | XmlData of XmlData
    | SettlInstRefID of SettlInstRefID
    | NoRoutingIDs of NoRoutingIDs
    | RoutingType of RoutingType
    | RoutingID of RoutingID
    | Spread of Spread
    | BenchmarkCurveCurrency of BenchmarkCurveCurrency
    | BenchmarkCurveName of BenchmarkCurveName
    | BenchmarkCurvePoint of BenchmarkCurvePoint
    | CouponRate of CouponRate
    | CouponPaymentDate of CouponPaymentDate
    | IssueDate of IssueDate
    | RepurchaseTerm of RepurchaseTerm
    | RepurchaseRate of RepurchaseRate
    | Factor of Factor
    | TradeOriginationDate of TradeOriginationDate
    | ExDate of ExDate
    | ContractMultiplier of ContractMultiplier
    | NoStipulations of NoStipulations
    | StipulationType of StipulationType
    | StipulationValue of StipulationValue
    | YieldType of YieldType
    | Yield of Yield
    | TotalTakedown of TotalTakedown
    | Concession of Concession
    | RepoCollateralSecurityType of RepoCollateralSecurityType
    | RedemptionDate of RedemptionDate
    | UnderlyingCouponPaymentDate of UnderlyingCouponPaymentDate
    | UnderlyingIssueDate of UnderlyingIssueDate
    | UnderlyingRepoCollateralSecurityType of UnderlyingRepoCollateralSecurityType
    | UnderlyingRepurchaseTerm of UnderlyingRepurchaseTerm
    | UnderlyingRepurchaseRate of UnderlyingRepurchaseRate
    | UnderlyingFactor of UnderlyingFactor
    | UnderlyingRedemptionDate of UnderlyingRedemptionDate
    | LegCouponPaymentDate of LegCouponPaymentDate
    | LegIssueDate of LegIssueDate
    | LegRepoCollateralSecurityType of LegRepoCollateralSecurityType
    | LegRepurchaseTerm of LegRepurchaseTerm
    | LegRepurchaseRate of LegRepurchaseRate
    | LegFactor of LegFactor
    | LegRedemptionDate of LegRedemptionDate
    | CreditRating of CreditRating
    | UnderlyingCreditRating of UnderlyingCreditRating
    | LegCreditRating of LegCreditRating
    | TradedFlatSwitch of TradedFlatSwitch
    | BasisFeatureDate of BasisFeatureDate
    | BasisFeaturePrice of BasisFeaturePrice
    | MDReqID of MDReqID
    | SubscriptionRequestType of SubscriptionRequestType
    | MarketDepth of MarketDepth
    | MDUpdateType of MDUpdateType
    | AggregatedBook of AggregatedBook
    | NoMDEntryTypes of NoMDEntryTypes
    | NoMDEntries of NoMDEntries
    | MDEntryType of MDEntryType
    | MDEntryPx of MDEntryPx
    | MDEntrySize of MDEntrySize
    | MDEntryDate of MDEntryDate
    | MDEntryTime of MDEntryTime
    | TickDirection of TickDirection
    | MDMkt of MDMkt
    | QuoteCondition of QuoteCondition
    | TradeCondition of TradeCondition
    | MDEntryID of MDEntryID
    | MDUpdateAction of MDUpdateAction
    | MDEntryRefID of MDEntryRefID
    | MDReqRejReason of MDReqRejReason
    | MDEntryOriginator of MDEntryOriginator
    | LocationID of LocationID
    | DeskID of DeskID
    | DeleteReason of DeleteReason
    | OpenCloseSettlFlag of OpenCloseSettlFlag
    | SellerDays of SellerDays
    | MDEntryBuyer of MDEntryBuyer
    | MDEntrySeller of MDEntrySeller
    | MDEntryPositionNo of MDEntryPositionNo
    | FinancialStatus of FinancialStatus
    | CorporateAction of CorporateAction
    | DefBidSize of DefBidSize
    | DefOfferSize of DefOfferSize
    | NoQuoteEntries of NoQuoteEntries
    | NoQuoteSets of NoQuoteSets
    | QuoteStatus of QuoteStatus
    | QuoteCancelType of QuoteCancelType
    | QuoteEntryID of QuoteEntryID
    | QuoteRejectReason of QuoteRejectReason
    | QuoteResponseLevel of QuoteResponseLevel
    | QuoteSetID of QuoteSetID
    | QuoteRequestType of QuoteRequestType
    | TotNoQuoteEntries of TotNoQuoteEntries
    | UnderlyingSecurityIDSource of UnderlyingSecurityIDSource
    | UnderlyingIssuer of UnderlyingIssuer
    | UnderlyingSecurityDesc of UnderlyingSecurityDesc
    | UnderlyingSecurityExchange of UnderlyingSecurityExchange
    | UnderlyingSecurityID of UnderlyingSecurityID
    | UnderlyingSecurityType of UnderlyingSecurityType
    | UnderlyingSymbol of UnderlyingSymbol
    | UnderlyingSymbolSfx of UnderlyingSymbolSfx
    | UnderlyingMaturityMonthYear of UnderlyingMaturityMonthYear
    | UnderlyingPutOrCall of UnderlyingPutOrCall
    | UnderlyingStrikePrice of UnderlyingStrikePrice
    | UnderlyingOptAttribute of UnderlyingOptAttribute
    | UnderlyingCurrency of UnderlyingCurrency
    | SecurityReqID of SecurityReqID
    | SecurityRequestType of SecurityRequestType
    | SecurityResponseID of SecurityResponseID
    | SecurityResponseType of SecurityResponseType
    | SecurityStatusReqID of SecurityStatusReqID
    | UnsolicitedIndicator of UnsolicitedIndicator
    | SecurityTradingStatus of SecurityTradingStatus
    | HaltReason of HaltReason
    | InViewOfCommon of InViewOfCommon
    | DueToRelated of DueToRelated
    | BuyVolume of BuyVolume
    | SellVolume of SellVolume
    | HighPx of HighPx
    | LowPx of LowPx
    | Adjustment of Adjustment
    | TradSesReqID of TradSesReqID
    | TradingSessionID of TradingSessionID
    | ContraTrader of ContraTrader
    | TradSesMethod of TradSesMethod
    | TradSesMode of TradSesMode
    | TradSesStatus of TradSesStatus
    | TradSesStartTime of TradSesStartTime
    | TradSesOpenTime of TradSesOpenTime
    | TradSesPreCloseTime of TradSesPreCloseTime
    | TradSesCloseTime of TradSesCloseTime
    | TradSesEndTime of TradSesEndTime
    | NumberOfOrders of NumberOfOrders
    | MessageEncoding of MessageEncoding
    | EncodedIssuer of EncodedIssuer
    | EncodedSecurityDesc of EncodedSecurityDesc
    | EncodedListExecInst of EncodedListExecInst
    | EncodedText of EncodedText
    | EncodedSubject of EncodedSubject
    | EncodedHeadline of EncodedHeadline
    | EncodedAllocText of EncodedAllocText
    | EncodedUnderlyingIssuer of EncodedUnderlyingIssuer
    | EncodedUnderlyingSecurityDesc of EncodedUnderlyingSecurityDesc
    | AllocPrice of AllocPrice
    | QuoteSetValidUntilTime of QuoteSetValidUntilTime
    | QuoteEntryRejectReason of QuoteEntryRejectReason
    | LastMsgSeqNumProcessed of LastMsgSeqNumProcessed
    | RefTagID of RefTagID
    | RefMsgType of RefMsgType
    | SessionRejectReason of SessionRejectReason
    | BidRequestTransType of BidRequestTransType
    | ContraBroker of ContraBroker
    | ComplianceID of ComplianceID
    | SolicitedFlag of SolicitedFlag
    | ExecRestatementReason of ExecRestatementReason
    | BusinessRejectRefID of BusinessRejectRefID
    | BusinessRejectReason of BusinessRejectReason
    | GrossTradeAmt of GrossTradeAmt
    | NoContraBrokers of NoContraBrokers
    | MaxMessageSize of MaxMessageSize
    | NoMsgTypes of NoMsgTypes
    | MsgDirection of MsgDirection
    | NoTradingSessions of NoTradingSessions
    | TotalVolumeTraded of TotalVolumeTraded
    | DiscretionInst of DiscretionInst
    | DiscretionOffsetValue of DiscretionOffsetValue
    | BidID of BidID
    | ClientBidID of ClientBidID
    | ListName of ListName
    | TotNoRelatedSym of TotNoRelatedSym
    | BidType of BidType
    | NumTickets of NumTickets
    | SideValue1 of SideValue1
    | SideValue2 of SideValue2
    | NoBidDescriptors of NoBidDescriptors
    | BidDescriptorType of BidDescriptorType
    | BidDescriptor of BidDescriptor
    | SideValueInd of SideValueInd
    | LiquidityPctLow of LiquidityPctLow
    | LiquidityPctHigh of LiquidityPctHigh
    | LiquidityValue of LiquidityValue
    | EFPTrackingError of EFPTrackingError
    | FairValue of FairValue
    | OutsideIndexPct of OutsideIndexPct
    | ValueOfFutures of ValueOfFutures
    | LiquidityIndType of LiquidityIndType
    | WtAverageLiquidity of WtAverageLiquidity
    | ExchangeForPhysical of ExchangeForPhysical
    | OutMainCntryUIndex of OutMainCntryUIndex
    | CrossPercent of CrossPercent
    | ProgRptReqs of ProgRptReqs
    | ProgPeriodInterval of ProgPeriodInterval
    | IncTaxInd of IncTaxInd
    | NumBidders of NumBidders
    | BidTradeType of BidTradeType
    | BasisPxType of BasisPxType
    | NoBidComponents of NoBidComponents
    | Country of Country
    | TotNoStrikes of TotNoStrikes
    | PriceType of PriceType
    | DayOrderQty of DayOrderQty
    | DayCumQty of DayCumQty
    | DayAvgPx of DayAvgPx
    | GTBookingInst of GTBookingInst
    | NoStrikes of NoStrikes
    | ListStatusType of ListStatusType
    | NetGrossInd of NetGrossInd
    | ListOrderStatus of ListOrderStatus
    | ExpireDate of ExpireDate
    | ListExecInstType of ListExecInstType
    | CxlRejResponseTo of CxlRejResponseTo
    | UnderlyingCouponRate of UnderlyingCouponRate
    | UnderlyingContractMultiplier of UnderlyingContractMultiplier
    | ContraTradeQty of ContraTradeQty
    | ContraTradeTime of ContraTradeTime
    | LiquidityNumSecurities of LiquidityNumSecurities
    | MultiLegReportingType of MultiLegReportingType
    | StrikeTime of StrikeTime
    | ListStatusText of ListStatusText
    | EncodedListStatusText of EncodedListStatusText
    | PartyIDSource of PartyIDSource
    | PartyID of PartyID
    | NetChgPrevDay of NetChgPrevDay
    | PartyRole of PartyRole
    | NoPartyIDs of NoPartyIDs
    | NoSecurityAltID of NoSecurityAltID
    | SecurityAltID of SecurityAltID
    | SecurityAltIDSource of SecurityAltIDSource
    | NoUnderlyingSecurityAltID of NoUnderlyingSecurityAltID
    | UnderlyingSecurityAltID of UnderlyingSecurityAltID
    | UnderlyingSecurityAltIDSource of UnderlyingSecurityAltIDSource
    | Product of Product
    | CFICode of CFICode
    | UnderlyingProduct of UnderlyingProduct
    | UnderlyingCFICode of UnderlyingCFICode
    | TestMessageIndicator of TestMessageIndicator
    | QuantityType of QuantityType
    | BookingRefID of BookingRefID
    | IndividualAllocID of IndividualAllocID
    | RoundingDirection of RoundingDirection
    | RoundingModulus of RoundingModulus
    | CountryOfIssue of CountryOfIssue
    | StateOrProvinceOfIssue of StateOrProvinceOfIssue
    | LocaleOfIssue of LocaleOfIssue
    | NoRegistDtls of NoRegistDtls
    | MailingDtls of MailingDtls
    | InvestorCountryOfResidence of InvestorCountryOfResidence
    | PaymentRef of PaymentRef
    | DistribPaymentMethod of DistribPaymentMethod
    | CashDistribCurr of CashDistribCurr
    | CommCurrency of CommCurrency
    | CancellationRights of CancellationRights
    | MoneyLaunderingStatus of MoneyLaunderingStatus
    | MailingInst of MailingInst
    | TransBkdTime of TransBkdTime
    | ExecPriceType of ExecPriceType
    | ExecPriceAdjustment of ExecPriceAdjustment
    | DateOfBirth of DateOfBirth
    | TradeReportTransType of TradeReportTransType
    | CardHolderName of CardHolderName
    | CardNumber of CardNumber
    | CardExpDate of CardExpDate
    | CardIssNum of CardIssNum
    | PaymentMethod of PaymentMethod
    | RegistAcctType of RegistAcctType
    | Designation of Designation
    | TaxAdvantageType of TaxAdvantageType
    | RegistRejReasonText of RegistRejReasonText
    | FundRenewWaiv of FundRenewWaiv
    | CashDistribAgentName of CashDistribAgentName
    | CashDistribAgentCode of CashDistribAgentCode
    | CashDistribAgentAcctNumber of CashDistribAgentAcctNumber
    | CashDistribPayRef of CashDistribPayRef
    | CashDistribAgentAcctName of CashDistribAgentAcctName
    | CardStartDate of CardStartDate
    | PaymentDate of PaymentDate
    | PaymentRemitterID of PaymentRemitterID
    | RegistStatus of RegistStatus
    | RegistRejReasonCode of RegistRejReasonCode
    | RegistRefID of RegistRefID
    | RegistDtls of RegistDtls
    | NoDistribInsts of NoDistribInsts
    | RegistEmail of RegistEmail
    | DistribPercentage of DistribPercentage
    | RegistID of RegistID
    | RegistTransType of RegistTransType
    | ExecValuationPoint of ExecValuationPoint
    | OrderPercent of OrderPercent
    | OwnershipType of OwnershipType
    | NoContAmts of NoContAmts
    | ContAmtType of ContAmtType
    | ContAmtValue of ContAmtValue
    | ContAmtCurr of ContAmtCurr
    | OwnerType of OwnerType
    | PartySubID of PartySubID
    | NestedPartyID of NestedPartyID
    | NestedPartyIDSource of NestedPartyIDSource
    | SecondaryClOrdID of SecondaryClOrdID
    | SecondaryExecID of SecondaryExecID
    | OrderCapacity of OrderCapacity
    | OrderRestrictions of OrderRestrictions
    | MassCancelRequestType of MassCancelRequestType
    | MassCancelResponse of MassCancelResponse
    | MassCancelRejectReason of MassCancelRejectReason
    | TotalAffectedOrders of TotalAffectedOrders
    | NoAffectedOrders of NoAffectedOrders
    | AffectedOrderID of AffectedOrderID
    | AffectedSecondaryOrderID of AffectedSecondaryOrderID
    | QuoteType of QuoteType
    | NestedPartyRole of NestedPartyRole
    | NoNestedPartyIDs of NoNestedPartyIDs
    | TotalAccruedInterestAmt of TotalAccruedInterestAmt
    | MaturityDate of MaturityDate
    | UnderlyingMaturityDate of UnderlyingMaturityDate
    | InstrRegistry of InstrRegistry
    | CashMargin of CashMargin
    | NestedPartySubID of NestedPartySubID
    | Scope of Scope
    | MDImplicitDelete of MDImplicitDelete
    | CrossID of CrossID
    | CrossType of CrossType
    | CrossPrioritization of CrossPrioritization
    | OrigCrossID of OrigCrossID
    | NoSides of NoSides
    | Username of Username
    | Password of Password
    | NoLegs of NoLegs
    | LegCurrency of LegCurrency
    | TotNoSecurityTypes of TotNoSecurityTypes
    | NoSecurityTypes of NoSecurityTypes
    | SecurityListRequestType of SecurityListRequestType
    | SecurityRequestResult of SecurityRequestResult
    | RoundLot of RoundLot
    | MinTradeVol of MinTradeVol
    | MultiLegRptTypeReq of MultiLegRptTypeReq
    | LegPositionEffect of LegPositionEffect
    | LegCoveredOrUncovered of LegCoveredOrUncovered
    | LegPrice of LegPrice
    | TradSesStatusRejReason of TradSesStatusRejReason
    | TradeRequestID of TradeRequestID
    | TradeRequestType of TradeRequestType
    | PreviouslyReported of PreviouslyReported
    | TradeReportID of TradeReportID
    | TradeReportRefID of TradeReportRefID
    | MatchStatus of MatchStatus
    | MatchType of MatchType
    | OddLot of OddLot
    | NoClearingInstructions of NoClearingInstructions
    | ClearingInstruction of ClearingInstruction
    | TradeInputSource of TradeInputSource
    | TradeInputDevice of TradeInputDevice
    | NoDates of NoDates
    | AccountType of AccountType
    | CustOrderCapacity of CustOrderCapacity
    | ClOrdLinkID of ClOrdLinkID
    | MassStatusReqID of MassStatusReqID
    | MassStatusReqType of MassStatusReqType
    | OrigOrdModTime of OrigOrdModTime
    | LegSettlType of LegSettlType
    | LegSettlDate of LegSettlDate
    | DayBookingInst of DayBookingInst
    | BookingUnit of BookingUnit
    | PreallocMethod of PreallocMethod
    | UnderlyingCountryOfIssue of UnderlyingCountryOfIssue
    | UnderlyingStateOrProvinceOfIssue of UnderlyingStateOrProvinceOfIssue
    | UnderlyingLocaleOfIssue of UnderlyingLocaleOfIssue
    | UnderlyingInstrRegistry of UnderlyingInstrRegistry
    | LegCountryOfIssue of LegCountryOfIssue
    | LegStateOrProvinceOfIssue of LegStateOrProvinceOfIssue
    | LegLocaleOfIssue of LegLocaleOfIssue
    | LegInstrRegistry of LegInstrRegistry
    | LegSymbol of LegSymbol
    | LegSymbolSfx of LegSymbolSfx
    | LegSecurityID of LegSecurityID
    | LegSecurityIDSource of LegSecurityIDSource
    | NoLegSecurityAltID of NoLegSecurityAltID
    | LegSecurityAltID of LegSecurityAltID
    | LegSecurityAltIDSource of LegSecurityAltIDSource
    | LegProduct of LegProduct
    | LegCFICode of LegCFICode
    | LegSecurityType of LegSecurityType
    | LegMaturityMonthYear of LegMaturityMonthYear
    | LegMaturityDate of LegMaturityDate
    | LegStrikePrice of LegStrikePrice
    | LegOptAttribute of LegOptAttribute
    | LegContractMultiplier of LegContractMultiplier
    | LegCouponRate of LegCouponRate
    | LegSecurityExchange of LegSecurityExchange
    | LegIssuer of LegIssuer
    | EncodedLegIssuer of EncodedLegIssuer
    | LegSecurityDesc of LegSecurityDesc
    | EncodedLegSecurityDesc of EncodedLegSecurityDesc
    | LegRatioQty of LegRatioQty
    | LegSide of LegSide
    | TradingSessionSubID of TradingSessionSubID
    | AllocType of AllocType
    | NoHops of NoHops
    | HopCompID of HopCompID
    | HopSendingTime of HopSendingTime
    | HopRefID of HopRefID
    | MidPx of MidPx
    | BidYield of BidYield
    | MidYield of MidYield
    | OfferYield of OfferYield
    | ClearingFeeIndicator of ClearingFeeIndicator
    | WorkingIndicator of WorkingIndicator
    | LegLastPx of LegLastPx
    | PriorityIndicator of PriorityIndicator
    | PriceImprovement of PriceImprovement
    | Price2 of Price2
    | LastForwardPoints2 of LastForwardPoints2
    | BidForwardPoints2 of BidForwardPoints2
    | OfferForwardPoints2 of OfferForwardPoints2
    | RFQReqID of RFQReqID
    | MktBidPx of MktBidPx
    | MktOfferPx of MktOfferPx
    | MinBidSize of MinBidSize
    | MinOfferSize of MinOfferSize
    | QuoteStatusReqID of QuoteStatusReqID
    | LegalConfirm of LegalConfirm
    | UnderlyingLastPx of UnderlyingLastPx
    | UnderlyingLastQty of UnderlyingLastQty
    | LegRefID of LegRefID
    | ContraLegRefID of ContraLegRefID
    | SettlCurrBidFxRate of SettlCurrBidFxRate
    | SettlCurrOfferFxRate of SettlCurrOfferFxRate
    | QuoteRequestRejectReason of QuoteRequestRejectReason
    | SideComplianceID of SideComplianceID
    | AcctIDSource of AcctIDSource
    | AllocAcctIDSource of AllocAcctIDSource
    | BenchmarkPrice of BenchmarkPrice
    | BenchmarkPriceType of BenchmarkPriceType
    | ConfirmID of ConfirmID
    | ConfirmStatus of ConfirmStatus
    | ConfirmTransType of ConfirmTransType
    | ContractSettlMonth of ContractSettlMonth
    | DeliveryForm of DeliveryForm
    | LastParPx of LastParPx
    | NoLegAllocs of NoLegAllocs
    | LegAllocAccount of LegAllocAccount
    | LegIndividualAllocID of LegIndividualAllocID
    | LegAllocQty of LegAllocQty
    | LegAllocAcctIDSource of LegAllocAcctIDSource
    | LegSettlCurrency of LegSettlCurrency
    | LegBenchmarkCurveCurrency of LegBenchmarkCurveCurrency
    | LegBenchmarkCurveName of LegBenchmarkCurveName
    | LegBenchmarkCurvePoint of LegBenchmarkCurvePoint
    | LegBenchmarkPrice of LegBenchmarkPrice
    | LegBenchmarkPriceType of LegBenchmarkPriceType
    | LegBidPx of LegBidPx
    | LegIOIQty of LegIOIQty
    | NoLegStipulations of NoLegStipulations
    | LegOfferPx of LegOfferPx
    | LegOrderQty of LegOrderQty
    | LegPriceType of LegPriceType
    | LegQty of LegQty
    | LegStipulationType of LegStipulationType
    | LegStipulationValue of LegStipulationValue
    | LegSwapType of LegSwapType
    | Pool of Pool
    | QuotePriceType of QuotePriceType
    | QuoteRespID of QuoteRespID
    | QuoteRespType of QuoteRespType
    | QuoteQualifier of QuoteQualifier
    | YieldRedemptionDate of YieldRedemptionDate
    | YieldRedemptionPrice of YieldRedemptionPrice
    | YieldRedemptionPriceType of YieldRedemptionPriceType
    | BenchmarkSecurityID of BenchmarkSecurityID
    | ReversalIndicator of ReversalIndicator
    | YieldCalcDate of YieldCalcDate
    | NoPositions of NoPositions
    | PosType of PosType
    | LongQty of LongQty
    | ShortQty of ShortQty
    | PosQtyStatus of PosQtyStatus
    | PosAmtType of PosAmtType
    | PosAmt of PosAmt
    | PosTransType of PosTransType
    | PosReqID of PosReqID
    | NoUnderlyings of NoUnderlyings
    | PosMaintAction of PosMaintAction
    | OrigPosReqRefID of OrigPosReqRefID
    | PosMaintRptRefID of PosMaintRptRefID
    | ClearingBusinessDate of ClearingBusinessDate
    | SettlSessID of SettlSessID
    | SettlSessSubID of SettlSessSubID
    | AdjustmentType of AdjustmentType
    | ContraryInstructionIndicator of ContraryInstructionIndicator
    | PriorSpreadIndicator of PriorSpreadIndicator
    | PosMaintRptID of PosMaintRptID
    | PosMaintStatus of PosMaintStatus
    | PosMaintResult of PosMaintResult
    | PosReqType of PosReqType
    | ResponseTransportType of ResponseTransportType
    | ResponseDestination of ResponseDestination
    | TotalNumPosReports of TotalNumPosReports
    | PosReqResult of PosReqResult
    | PosReqStatus of PosReqStatus
    | SettlPrice of SettlPrice
    | SettlPriceType of SettlPriceType
    | UnderlyingSettlPrice of UnderlyingSettlPrice
    | UnderlyingSettlPriceType of UnderlyingSettlPriceType
    | PriorSettlPrice of PriorSettlPrice
    | NoQuoteQualifiers of NoQuoteQualifiers
    | AllocSettlCurrency of AllocSettlCurrency
    | AllocSettlCurrAmt of AllocSettlCurrAmt
    | InterestAtMaturity of InterestAtMaturity
    | LegDatedDate of LegDatedDate
    | LegPool of LegPool
    | AllocInterestAtMaturity of AllocInterestAtMaturity
    | AllocAccruedInterestAmt of AllocAccruedInterestAmt
    | DeliveryDate of DeliveryDate
    | AssignmentMethod of AssignmentMethod
    | AssignmentUnit of AssignmentUnit
    | OpenInterest of OpenInterest
    | ExerciseMethod of ExerciseMethod
    | TotNumTradeReports of TotNumTradeReports
    | TradeRequestResult of TradeRequestResult
    | TradeRequestStatus of TradeRequestStatus
    | TradeReportRejectReason of TradeReportRejectReason
    | SideMultiLegReportingType of SideMultiLegReportingType
    | NoPosAmt of NoPosAmt
    | AutoAcceptIndicator of AutoAcceptIndicator
    | AllocReportID of AllocReportID
    | NoNested2PartyIDs of NoNested2PartyIDs
    | Nested2PartyID of Nested2PartyID
    | Nested2PartyIDSource of Nested2PartyIDSource
    | Nested2PartyRole of Nested2PartyRole
    | Nested2PartySubID of Nested2PartySubID
    | BenchmarkSecurityIDSource of BenchmarkSecurityIDSource
    | SecuritySubType of SecuritySubType
    | UnderlyingSecuritySubType of UnderlyingSecuritySubType
    | LegSecuritySubType of LegSecuritySubType
    | AllowableOneSidednessPct of AllowableOneSidednessPct
    | AllowableOneSidednessValue of AllowableOneSidednessValue
    | AllowableOneSidednessCurr of AllowableOneSidednessCurr
    | NoTrdRegTimestamps of NoTrdRegTimestamps
    | TrdRegTimestamp of TrdRegTimestamp
    | TrdRegTimestampType of TrdRegTimestampType
    | TrdRegTimestampOrigin of TrdRegTimestampOrigin
    | ConfirmRefID of ConfirmRefID
    | ConfirmType of ConfirmType
    | ConfirmRejReason of ConfirmRejReason
    | BookingType of BookingType
    | IndividualAllocRejCode of IndividualAllocRejCode
    | SettlInstMsgID of SettlInstMsgID
    | NoSettlInst of NoSettlInst
    | LastUpdateTime of LastUpdateTime
    | AllocSettlInstType of AllocSettlInstType
    | NoSettlPartyIDs of NoSettlPartyIDs
    | SettlPartyID of SettlPartyID
    | SettlPartyIDSource of SettlPartyIDSource
    | SettlPartyRole of SettlPartyRole
    | SettlPartySubID of SettlPartySubID
    | SettlPartySubIDType of SettlPartySubIDType
    | DlvyInstType of DlvyInstType
    | TerminationType of TerminationType
    | NextExpectedMsgSeqNum of NextExpectedMsgSeqNum
    | OrdStatusReqID of OrdStatusReqID
    | SettlInstReqID of SettlInstReqID
    | SettlInstReqRejCode of SettlInstReqRejCode
    | SecondaryAllocID of SecondaryAllocID
    | AllocReportType of AllocReportType
    | AllocReportRefID of AllocReportRefID
    | AllocCancReplaceReason of AllocCancReplaceReason
    | CopyMsgIndicator of CopyMsgIndicator
    | AllocAccountType of AllocAccountType
    | OrderAvgPx of OrderAvgPx
    | OrderBookingQty of OrderBookingQty
    | NoSettlPartySubIDs of NoSettlPartySubIDs
    | NoPartySubIDs of NoPartySubIDs
    | PartySubIDType of PartySubIDType
    | NoNestedPartySubIDs of NoNestedPartySubIDs
    | NestedPartySubIDType of NestedPartySubIDType
    | NoNested2PartySubIDs of NoNested2PartySubIDs
    | Nested2PartySubIDType of Nested2PartySubIDType
    | AllocIntermedReqType of AllocIntermedReqType
    | UnderlyingPx of UnderlyingPx
    | PriceDelta of PriceDelta
    | ApplQueueMax of ApplQueueMax
    | ApplQueueDepth of ApplQueueDepth
    | ApplQueueResolution of ApplQueueResolution
    | ApplQueueAction of ApplQueueAction
    | NoAltMDSource of NoAltMDSource
    | AltMDSourceID of AltMDSourceID
    | SecondaryTradeReportID of SecondaryTradeReportID
    | AvgPxIndicator of AvgPxIndicator
    | TradeLinkID of TradeLinkID
    | OrderInputDevice of OrderInputDevice
    | UnderlyingTradingSessionID of UnderlyingTradingSessionID
    | UnderlyingTradingSessionSubID of UnderlyingTradingSessionSubID
    | TradeLegRefID of TradeLegRefID
    | ExchangeRule of ExchangeRule
    | TradeAllocIndicator of TradeAllocIndicator
    | ExpirationCycle of ExpirationCycle
    | TrdType of TrdType
    | TrdSubType of TrdSubType
    | TransferReason of TransferReason
    | AsgnReqID of AsgnReqID
    | TotNumAssignmentReports of TotNumAssignmentReports
    | AsgnRptID of AsgnRptID
    | ThresholdAmount of ThresholdAmount
    | PegMoveType of PegMoveType
    | PegOffsetType of PegOffsetType
    | PegLimitType of PegLimitType
    | PegRoundDirection of PegRoundDirection
    | PeggedPrice of PeggedPrice
    | PegScope of PegScope
    | DiscretionMoveType of DiscretionMoveType
    | DiscretionOffsetType of DiscretionOffsetType
    | DiscretionLimitType of DiscretionLimitType
    | DiscretionRoundDirection of DiscretionRoundDirection
    | DiscretionPrice of DiscretionPrice
    | DiscretionScope of DiscretionScope
    | TargetStrategy of TargetStrategy
    | TargetStrategyParameters of TargetStrategyParameters
    | ParticipationRate of ParticipationRate
    | TargetStrategyPerformance of TargetStrategyPerformance
    | LastLiquidityInd of LastLiquidityInd
    | PublishTrdIndicator of PublishTrdIndicator
    | ShortSaleReason of ShortSaleReason
    | QtyType of QtyType
    | SecondaryTrdType of SecondaryTrdType
    | TradeReportType of TradeReportType
    | AllocNoOrdersType of AllocNoOrdersType
    | SharedCommission of SharedCommission
    | ConfirmReqID of ConfirmReqID
    | AvgParPx of AvgParPx
    | ReportedPx of ReportedPx
    | NoCapacities of NoCapacities
    | OrderCapacityQty of OrderCapacityQty
    | NoEvents of NoEvents
    | EventType of EventType
    | EventDate of EventDate
    | EventPx of EventPx
    | EventText of EventText
    | PctAtRisk of PctAtRisk
    | NoInstrAttrib of NoInstrAttrib
    | InstrAttribType of InstrAttribType
    | InstrAttribValue of InstrAttribValue
    | DatedDate of DatedDate
    | InterestAccrualDate of InterestAccrualDate
    | CPProgram of CPProgram
    | CPRegType of CPRegType
    | UnderlyingCPProgram of UnderlyingCPProgram
    | UnderlyingCPRegType of UnderlyingCPRegType
    | UnderlyingQty of UnderlyingQty
    | TrdMatchID of TrdMatchID
    | SecondaryTradeReportRefID of SecondaryTradeReportRefID
    | UnderlyingDirtyPrice of UnderlyingDirtyPrice
    | UnderlyingEndPrice of UnderlyingEndPrice
    | UnderlyingStartValue of UnderlyingStartValue
    | UnderlyingCurrentValue of UnderlyingCurrentValue
    | UnderlyingEndValue of UnderlyingEndValue
    | NoUnderlyingStips of NoUnderlyingStips
    | UnderlyingStipType of UnderlyingStipType
    | UnderlyingStipValue of UnderlyingStipValue
    | MaturityNetMoney of MaturityNetMoney
    | MiscFeeBasis of MiscFeeBasis
    | TotNoAllocs of TotNoAllocs
    | LastFragment of LastFragment
    | CollReqID of CollReqID
    | CollAsgnReason of CollAsgnReason
    | CollInquiryQualifier of CollInquiryQualifier
    | NoTrades of NoTrades
    | MarginRatio of MarginRatio
    | MarginExcess of MarginExcess
    | TotalNetValue of TotalNetValue
    | CashOutstanding of CashOutstanding
    | CollAsgnID of CollAsgnID
    | CollAsgnTransType of CollAsgnTransType
    | CollRespID of CollRespID
    | CollAsgnRespType of CollAsgnRespType
    | CollAsgnRejectReason of CollAsgnRejectReason
    | CollAsgnRefID of CollAsgnRefID
    | CollRptID of CollRptID
    | CollInquiryID of CollInquiryID
    | CollStatus of CollStatus
    | TotNumReports of TotNumReports
    | LastRptRequested of LastRptRequested
    | AgreementDesc of AgreementDesc
    | AgreementID of AgreementID
    | AgreementDate of AgreementDate
    | StartDate of StartDate
    | EndDate of EndDate
    | AgreementCurrency of AgreementCurrency
    | DeliveryType of DeliveryType
    | EndAccruedInterestAmt of EndAccruedInterestAmt
    | StartCash of StartCash
    | EndCash of EndCash
    | UserRequestID of UserRequestID
    | UserRequestType of UserRequestType
    | NewPassword of NewPassword
    | UserStatus of UserStatus
    | UserStatusText of UserStatusText
    | StatusValue of StatusValue
    | StatusText of StatusText
    | RefCompID of RefCompID
    | RefSubID of RefSubID
    | NetworkResponseID of NetworkResponseID
    | NetworkRequestID of NetworkRequestID
    | LastNetworkResponseID of LastNetworkResponseID
    | NetworkRequestType of NetworkRequestType
    | NoCompIDs of NoCompIDs
    | NetworkStatusResponseType of NetworkStatusResponseType
    | NoCollInquiryQualifier of NoCollInquiryQualifier
    | TrdRptStatus of TrdRptStatus
    | AffirmStatus of AffirmStatus
    | UnderlyingStrikeCurrency of UnderlyingStrikeCurrency
    | LegStrikeCurrency of LegStrikeCurrency
    | TimeBracket of TimeBracket
    | CollAction of CollAction
    | CollInquiryStatus of CollInquiryStatus
    | CollInquiryResult of CollInquiryResult
    | StrikeCurrency of StrikeCurrency
    | NoNested3PartyIDs of NoNested3PartyIDs
    | Nested3PartyID of Nested3PartyID
    | Nested3PartyIDSource of Nested3PartyIDSource
    | Nested3PartyRole of Nested3PartyRole
    | NoNested3PartySubIDs of NoNested3PartySubIDs
    | Nested3PartySubID of Nested3PartySubID
    | Nested3PartySubIDType of Nested3PartySubIDType
    | LegContractSettlMonth of LegContractSettlMonth
    | LegInterestAccrualDate of LegInterestAccrualDate


let WriteField dest nextFreeIdx fixField =
    match fixField with
    | Account fixField -> WriteAccount dest nextFreeIdx fixField
    | AdvId fixField -> WriteAdvId dest nextFreeIdx fixField
    | AdvRefID fixField -> WriteAdvRefID dest nextFreeIdx fixField
    | AdvSide fixField -> WriteAdvSide dest nextFreeIdx fixField
    | AdvTransType fixField -> WriteAdvTransType dest nextFreeIdx fixField
    | AvgPx fixField -> WriteAvgPx dest nextFreeIdx fixField
    | BeginSeqNo fixField -> WriteBeginSeqNo dest nextFreeIdx fixField
    | BeginString fixField -> WriteBeginString dest nextFreeIdx fixField
    | BodyLength fixField -> WriteBodyLength dest nextFreeIdx fixField
    | CheckSum fixField -> WriteCheckSum dest nextFreeIdx fixField
    | ClOrdID fixField -> WriteClOrdID dest nextFreeIdx fixField
    | Commission fixField -> WriteCommission dest nextFreeIdx fixField
    | CommType fixField -> WriteCommType dest nextFreeIdx fixField
    | CumQty fixField -> WriteCumQty dest nextFreeIdx fixField
    | Currency fixField -> WriteCurrency dest nextFreeIdx fixField
    | EndSeqNo fixField -> WriteEndSeqNo dest nextFreeIdx fixField
    | ExecID fixField -> WriteExecID dest nextFreeIdx fixField
    | ExecInst fixField -> WriteExecInst dest nextFreeIdx fixField
    | ExecRefID fixField -> WriteExecRefID dest nextFreeIdx fixField
    | HandlInst fixField -> WriteHandlInst dest nextFreeIdx fixField
    | SecurityIDSource fixField -> WriteSecurityIDSource dest nextFreeIdx fixField
    | IOIid fixField -> WriteIOIid dest nextFreeIdx fixField
    | IOIQltyInd fixField -> WriteIOIQltyInd dest nextFreeIdx fixField
    | IOIRefID fixField -> WriteIOIRefID dest nextFreeIdx fixField
    | IOIQty fixField -> WriteIOIQty dest nextFreeIdx fixField
    | IOITransType fixField -> WriteIOITransType dest nextFreeIdx fixField
    | LastCapacity fixField -> WriteLastCapacity dest nextFreeIdx fixField
    | LastMkt fixField -> WriteLastMkt dest nextFreeIdx fixField
    | LastPx fixField -> WriteLastPx dest nextFreeIdx fixField
    | LastQty fixField -> WriteLastQty dest nextFreeIdx fixField
    | LinesOfText fixField -> WriteLinesOfText dest nextFreeIdx fixField
    | MsgSeqNum fixField -> WriteMsgSeqNum dest nextFreeIdx fixField
    | MsgType fixField -> WriteMsgType dest nextFreeIdx fixField
    | NewSeqNo fixField -> WriteNewSeqNo dest nextFreeIdx fixField
    | OrderID fixField -> WriteOrderID dest nextFreeIdx fixField
    | OrderQty fixField -> WriteOrderQty dest nextFreeIdx fixField
    | OrdStatus fixField -> WriteOrdStatus dest nextFreeIdx fixField
    | OrdType fixField -> WriteOrdType dest nextFreeIdx fixField
    | OrigClOrdID fixField -> WriteOrigClOrdID dest nextFreeIdx fixField
    | OrigTime fixField -> WriteOrigTime dest nextFreeIdx fixField
    | PossDupFlag fixField -> WritePossDupFlag dest nextFreeIdx fixField
    | Price fixField -> WritePrice dest nextFreeIdx fixField
    | RefSeqNum fixField -> WriteRefSeqNum dest nextFreeIdx fixField
    | SecurityID fixField -> WriteSecurityID dest nextFreeIdx fixField
    | SenderCompID fixField -> WriteSenderCompID dest nextFreeIdx fixField
    | SenderSubID fixField -> WriteSenderSubID dest nextFreeIdx fixField
    | SendingTime fixField -> WriteSendingTime dest nextFreeIdx fixField
    | Quantity fixField -> WriteQuantity dest nextFreeIdx fixField
    | Side fixField -> WriteSide dest nextFreeIdx fixField
    | Symbol fixField -> WriteSymbol dest nextFreeIdx fixField
    | TargetCompID fixField -> WriteTargetCompID dest nextFreeIdx fixField
    | TargetSubID fixField -> WriteTargetSubID dest nextFreeIdx fixField
    | Text fixField -> WriteText dest nextFreeIdx fixField
    | TimeInForce fixField -> WriteTimeInForce dest nextFreeIdx fixField
    | TransactTime fixField -> WriteTransactTime dest nextFreeIdx fixField
    | Urgency fixField -> WriteUrgency dest nextFreeIdx fixField
    | ValidUntilTime fixField -> WriteValidUntilTime dest nextFreeIdx fixField
    | SettlType fixField -> WriteSettlType dest nextFreeIdx fixField
    | SettlDate fixField -> WriteSettlDate dest nextFreeIdx fixField
    | SymbolSfx fixField -> WriteSymbolSfx dest nextFreeIdx fixField
    | ListID fixField -> WriteListID dest nextFreeIdx fixField
    | ListSeqNo fixField -> WriteListSeqNo dest nextFreeIdx fixField
    | TotNoOrders fixField -> WriteTotNoOrders dest nextFreeIdx fixField
    | ListExecInst fixField -> WriteListExecInst dest nextFreeIdx fixField
    | AllocID fixField -> WriteAllocID dest nextFreeIdx fixField
    | AllocTransType fixField -> WriteAllocTransType dest nextFreeIdx fixField
    | RefAllocID fixField -> WriteRefAllocID dest nextFreeIdx fixField
    | NoOrders fixField -> WriteNoOrders dest nextFreeIdx fixField
    | AvgPxPrecision fixField -> WriteAvgPxPrecision dest nextFreeIdx fixField
    | TradeDate fixField -> WriteTradeDate dest nextFreeIdx fixField
    | PositionEffect fixField -> WritePositionEffect dest nextFreeIdx fixField
    | NoAllocs fixField -> WriteNoAllocs dest nextFreeIdx fixField
    | AllocAccount fixField -> WriteAllocAccount dest nextFreeIdx fixField
    | AllocQty fixField -> WriteAllocQty dest nextFreeIdx fixField
    | ProcessCode fixField -> WriteProcessCode dest nextFreeIdx fixField
    | NoRpts fixField -> WriteNoRpts dest nextFreeIdx fixField
    | RptSeq fixField -> WriteRptSeq dest nextFreeIdx fixField
    | CxlQty fixField -> WriteCxlQty dest nextFreeIdx fixField
    | NoDlvyInst fixField -> WriteNoDlvyInst dest nextFreeIdx fixField
    | AllocStatus fixField -> WriteAllocStatus dest nextFreeIdx fixField
    | AllocRejCode fixField -> WriteAllocRejCode dest nextFreeIdx fixField
    | Signature fixField -> WriteSignature dest nextFreeIdx fixField // compound field
    | SecureData fixField -> WriteSecureData dest nextFreeIdx fixField // compound field
    | EmailType fixField -> WriteEmailType dest nextFreeIdx fixField
    | RawData fixField -> WriteRawData dest nextFreeIdx fixField // compound field
    | PossResend fixField -> WritePossResend dest nextFreeIdx fixField
    | EncryptMethod fixField -> WriteEncryptMethod dest nextFreeIdx fixField
    | StopPx fixField -> WriteStopPx dest nextFreeIdx fixField
    | ExDestination fixField -> WriteExDestination dest nextFreeIdx fixField
    | CxlRejReason fixField -> WriteCxlRejReason dest nextFreeIdx fixField
    | OrdRejReason fixField -> WriteOrdRejReason dest nextFreeIdx fixField
    | IOIQualifier fixField -> WriteIOIQualifier dest nextFreeIdx fixField
    | WaveNo fixField -> WriteWaveNo dest nextFreeIdx fixField
    | Issuer fixField -> WriteIssuer dest nextFreeIdx fixField
    | SecurityDesc fixField -> WriteSecurityDesc dest nextFreeIdx fixField
    | HeartBtInt fixField -> WriteHeartBtInt dest nextFreeIdx fixField
    | MinQty fixField -> WriteMinQty dest nextFreeIdx fixField
    | MaxFloor fixField -> WriteMaxFloor dest nextFreeIdx fixField
    | TestReqID fixField -> WriteTestReqID dest nextFreeIdx fixField
    | ReportToExch fixField -> WriteReportToExch dest nextFreeIdx fixField
    | LocateReqd fixField -> WriteLocateReqd dest nextFreeIdx fixField
    | OnBehalfOfCompID fixField -> WriteOnBehalfOfCompID dest nextFreeIdx fixField
    | OnBehalfOfSubID fixField -> WriteOnBehalfOfSubID dest nextFreeIdx fixField
    | QuoteID fixField -> WriteQuoteID dest nextFreeIdx fixField
    | NetMoney fixField -> WriteNetMoney dest nextFreeIdx fixField
    | SettlCurrAmt fixField -> WriteSettlCurrAmt dest nextFreeIdx fixField
    | SettlCurrency fixField -> WriteSettlCurrency dest nextFreeIdx fixField
    | ForexReq fixField -> WriteForexReq dest nextFreeIdx fixField
    | OrigSendingTime fixField -> WriteOrigSendingTime dest nextFreeIdx fixField
    | GapFillFlag fixField -> WriteGapFillFlag dest nextFreeIdx fixField
    | NoExecs fixField -> WriteNoExecs dest nextFreeIdx fixField
    | ExpireTime fixField -> WriteExpireTime dest nextFreeIdx fixField
    | DKReason fixField -> WriteDKReason dest nextFreeIdx fixField
    | DeliverToCompID fixField -> WriteDeliverToCompID dest nextFreeIdx fixField
    | DeliverToSubID fixField -> WriteDeliverToSubID dest nextFreeIdx fixField
    | IOINaturalFlag fixField -> WriteIOINaturalFlag dest nextFreeIdx fixField
    | QuoteReqID fixField -> WriteQuoteReqID dest nextFreeIdx fixField
    | BidPx fixField -> WriteBidPx dest nextFreeIdx fixField
    | OfferPx fixField -> WriteOfferPx dest nextFreeIdx fixField
    | BidSize fixField -> WriteBidSize dest nextFreeIdx fixField
    | OfferSize fixField -> WriteOfferSize dest nextFreeIdx fixField
    | NoMiscFees fixField -> WriteNoMiscFees dest nextFreeIdx fixField
    | MiscFeeAmt fixField -> WriteMiscFeeAmt dest nextFreeIdx fixField
    | MiscFeeCurr fixField -> WriteMiscFeeCurr dest nextFreeIdx fixField
    | MiscFeeType fixField -> WriteMiscFeeType dest nextFreeIdx fixField
    | PrevClosePx fixField -> WritePrevClosePx dest nextFreeIdx fixField
    | ResetSeqNumFlag fixField -> WriteResetSeqNumFlag dest nextFreeIdx fixField
    | SenderLocationID fixField -> WriteSenderLocationID dest nextFreeIdx fixField
    | TargetLocationID fixField -> WriteTargetLocationID dest nextFreeIdx fixField
    | OnBehalfOfLocationID fixField -> WriteOnBehalfOfLocationID dest nextFreeIdx fixField
    | DeliverToLocationID fixField -> WriteDeliverToLocationID dest nextFreeIdx fixField
    | NoRelatedSym fixField -> WriteNoRelatedSym dest nextFreeIdx fixField
    | Subject fixField -> WriteSubject dest nextFreeIdx fixField
    | Headline fixField -> WriteHeadline dest nextFreeIdx fixField
    | URLLink fixField -> WriteURLLink dest nextFreeIdx fixField
    | ExecType fixField -> WriteExecType dest nextFreeIdx fixField
    | LeavesQty fixField -> WriteLeavesQty dest nextFreeIdx fixField
    | CashOrderQty fixField -> WriteCashOrderQty dest nextFreeIdx fixField
    | AllocAvgPx fixField -> WriteAllocAvgPx dest nextFreeIdx fixField
    | AllocNetMoney fixField -> WriteAllocNetMoney dest nextFreeIdx fixField
    | SettlCurrFxRate fixField -> WriteSettlCurrFxRate dest nextFreeIdx fixField
    | SettlCurrFxRateCalc fixField -> WriteSettlCurrFxRateCalc dest nextFreeIdx fixField
    | NumDaysInterest fixField -> WriteNumDaysInterest dest nextFreeIdx fixField
    | AccruedInterestRate fixField -> WriteAccruedInterestRate dest nextFreeIdx fixField
    | AccruedInterestAmt fixField -> WriteAccruedInterestAmt dest nextFreeIdx fixField
    | SettlInstMode fixField -> WriteSettlInstMode dest nextFreeIdx fixField
    | AllocText fixField -> WriteAllocText dest nextFreeIdx fixField
    | SettlInstID fixField -> WriteSettlInstID dest nextFreeIdx fixField
    | SettlInstTransType fixField -> WriteSettlInstTransType dest nextFreeIdx fixField
    | EmailThreadID fixField -> WriteEmailThreadID dest nextFreeIdx fixField
    | SettlInstSource fixField -> WriteSettlInstSource dest nextFreeIdx fixField
    | SecurityType fixField -> WriteSecurityType dest nextFreeIdx fixField
    | EffectiveTime fixField -> WriteEffectiveTime dest nextFreeIdx fixField
    | StandInstDbType fixField -> WriteStandInstDbType dest nextFreeIdx fixField
    | StandInstDbName fixField -> WriteStandInstDbName dest nextFreeIdx fixField
    | StandInstDbID fixField -> WriteStandInstDbID dest nextFreeIdx fixField
    | SettlDeliveryType fixField -> WriteSettlDeliveryType dest nextFreeIdx fixField
    | BidSpotRate fixField -> WriteBidSpotRate dest nextFreeIdx fixField
    | BidForwardPoints fixField -> WriteBidForwardPoints dest nextFreeIdx fixField
    | OfferSpotRate fixField -> WriteOfferSpotRate dest nextFreeIdx fixField
    | OfferForwardPoints fixField -> WriteOfferForwardPoints dest nextFreeIdx fixField
    | OrderQty2 fixField -> WriteOrderQty2 dest nextFreeIdx fixField
    | SettlDate2 fixField -> WriteSettlDate2 dest nextFreeIdx fixField
    | LastSpotRate fixField -> WriteLastSpotRate dest nextFreeIdx fixField
    | LastForwardPoints fixField -> WriteLastForwardPoints dest nextFreeIdx fixField
    | AllocLinkID fixField -> WriteAllocLinkID dest nextFreeIdx fixField
    | AllocLinkType fixField -> WriteAllocLinkType dest nextFreeIdx fixField
    | SecondaryOrderID fixField -> WriteSecondaryOrderID dest nextFreeIdx fixField
    | NoIOIQualifiers fixField -> WriteNoIOIQualifiers dest nextFreeIdx fixField
    | MaturityMonthYear fixField -> WriteMaturityMonthYear dest nextFreeIdx fixField
    | PutOrCall fixField -> WritePutOrCall dest nextFreeIdx fixField
    | StrikePrice fixField -> WriteStrikePrice dest nextFreeIdx fixField
    | CoveredOrUncovered fixField -> WriteCoveredOrUncovered dest nextFreeIdx fixField
    | OptAttribute fixField -> WriteOptAttribute dest nextFreeIdx fixField
    | SecurityExchange fixField -> WriteSecurityExchange dest nextFreeIdx fixField
    | NotifyBrokerOfCredit fixField -> WriteNotifyBrokerOfCredit dest nextFreeIdx fixField
    | AllocHandlInst fixField -> WriteAllocHandlInst dest nextFreeIdx fixField
    | MaxShow fixField -> WriteMaxShow dest nextFreeIdx fixField
    | PegOffsetValue fixField -> WritePegOffsetValue dest nextFreeIdx fixField
    | XmlData fixField -> WriteXmlData dest nextFreeIdx fixField // compound field
    | SettlInstRefID fixField -> WriteSettlInstRefID dest nextFreeIdx fixField
    | NoRoutingIDs fixField -> WriteNoRoutingIDs dest nextFreeIdx fixField
    | RoutingType fixField -> WriteRoutingType dest nextFreeIdx fixField
    | RoutingID fixField -> WriteRoutingID dest nextFreeIdx fixField
    | Spread fixField -> WriteSpread dest nextFreeIdx fixField
    | BenchmarkCurveCurrency fixField -> WriteBenchmarkCurveCurrency dest nextFreeIdx fixField
    | BenchmarkCurveName fixField -> WriteBenchmarkCurveName dest nextFreeIdx fixField
    | BenchmarkCurvePoint fixField -> WriteBenchmarkCurvePoint dest nextFreeIdx fixField
    | CouponRate fixField -> WriteCouponRate dest nextFreeIdx fixField
    | CouponPaymentDate fixField -> WriteCouponPaymentDate dest nextFreeIdx fixField
    | IssueDate fixField -> WriteIssueDate dest nextFreeIdx fixField
    | RepurchaseTerm fixField -> WriteRepurchaseTerm dest nextFreeIdx fixField
    | RepurchaseRate fixField -> WriteRepurchaseRate dest nextFreeIdx fixField
    | Factor fixField -> WriteFactor dest nextFreeIdx fixField
    | TradeOriginationDate fixField -> WriteTradeOriginationDate dest nextFreeIdx fixField
    | ExDate fixField -> WriteExDate dest nextFreeIdx fixField
    | ContractMultiplier fixField -> WriteContractMultiplier dest nextFreeIdx fixField
    | NoStipulations fixField -> WriteNoStipulations dest nextFreeIdx fixField
    | StipulationType fixField -> WriteStipulationType dest nextFreeIdx fixField
    | StipulationValue fixField -> WriteStipulationValue dest nextFreeIdx fixField
    | YieldType fixField -> WriteYieldType dest nextFreeIdx fixField
    | Yield fixField -> WriteYield dest nextFreeIdx fixField
    | TotalTakedown fixField -> WriteTotalTakedown dest nextFreeIdx fixField
    | Concession fixField -> WriteConcession dest nextFreeIdx fixField
    | RepoCollateralSecurityType fixField -> WriteRepoCollateralSecurityType dest nextFreeIdx fixField
    | RedemptionDate fixField -> WriteRedemptionDate dest nextFreeIdx fixField
    | UnderlyingCouponPaymentDate fixField -> WriteUnderlyingCouponPaymentDate dest nextFreeIdx fixField
    | UnderlyingIssueDate fixField -> WriteUnderlyingIssueDate dest nextFreeIdx fixField
    | UnderlyingRepoCollateralSecurityType fixField -> WriteUnderlyingRepoCollateralSecurityType dest nextFreeIdx fixField
    | UnderlyingRepurchaseTerm fixField -> WriteUnderlyingRepurchaseTerm dest nextFreeIdx fixField
    | UnderlyingRepurchaseRate fixField -> WriteUnderlyingRepurchaseRate dest nextFreeIdx fixField
    | UnderlyingFactor fixField -> WriteUnderlyingFactor dest nextFreeIdx fixField
    | UnderlyingRedemptionDate fixField -> WriteUnderlyingRedemptionDate dest nextFreeIdx fixField
    | LegCouponPaymentDate fixField -> WriteLegCouponPaymentDate dest nextFreeIdx fixField
    | LegIssueDate fixField -> WriteLegIssueDate dest nextFreeIdx fixField
    | LegRepoCollateralSecurityType fixField -> WriteLegRepoCollateralSecurityType dest nextFreeIdx fixField
    | LegRepurchaseTerm fixField -> WriteLegRepurchaseTerm dest nextFreeIdx fixField
    | LegRepurchaseRate fixField -> WriteLegRepurchaseRate dest nextFreeIdx fixField
    | LegFactor fixField -> WriteLegFactor dest nextFreeIdx fixField
    | LegRedemptionDate fixField -> WriteLegRedemptionDate dest nextFreeIdx fixField
    | CreditRating fixField -> WriteCreditRating dest nextFreeIdx fixField
    | UnderlyingCreditRating fixField -> WriteUnderlyingCreditRating dest nextFreeIdx fixField
    | LegCreditRating fixField -> WriteLegCreditRating dest nextFreeIdx fixField
    | TradedFlatSwitch fixField -> WriteTradedFlatSwitch dest nextFreeIdx fixField
    | BasisFeatureDate fixField -> WriteBasisFeatureDate dest nextFreeIdx fixField
    | BasisFeaturePrice fixField -> WriteBasisFeaturePrice dest nextFreeIdx fixField
    | MDReqID fixField -> WriteMDReqID dest nextFreeIdx fixField
    | SubscriptionRequestType fixField -> WriteSubscriptionRequestType dest nextFreeIdx fixField
    | MarketDepth fixField -> WriteMarketDepth dest nextFreeIdx fixField
    | MDUpdateType fixField -> WriteMDUpdateType dest nextFreeIdx fixField
    | AggregatedBook fixField -> WriteAggregatedBook dest nextFreeIdx fixField
    | NoMDEntryTypes fixField -> WriteNoMDEntryTypes dest nextFreeIdx fixField
    | NoMDEntries fixField -> WriteNoMDEntries dest nextFreeIdx fixField
    | MDEntryType fixField -> WriteMDEntryType dest nextFreeIdx fixField
    | MDEntryPx fixField -> WriteMDEntryPx dest nextFreeIdx fixField
    | MDEntrySize fixField -> WriteMDEntrySize dest nextFreeIdx fixField
    | MDEntryDate fixField -> WriteMDEntryDate dest nextFreeIdx fixField
    | MDEntryTime fixField -> WriteMDEntryTime dest nextFreeIdx fixField
    | TickDirection fixField -> WriteTickDirection dest nextFreeIdx fixField
    | MDMkt fixField -> WriteMDMkt dest nextFreeIdx fixField
    | QuoteCondition fixField -> WriteQuoteCondition dest nextFreeIdx fixField
    | TradeCondition fixField -> WriteTradeCondition dest nextFreeIdx fixField
    | MDEntryID fixField -> WriteMDEntryID dest nextFreeIdx fixField
    | MDUpdateAction fixField -> WriteMDUpdateAction dest nextFreeIdx fixField
    | MDEntryRefID fixField -> WriteMDEntryRefID dest nextFreeIdx fixField
    | MDReqRejReason fixField -> WriteMDReqRejReason dest nextFreeIdx fixField
    | MDEntryOriginator fixField -> WriteMDEntryOriginator dest nextFreeIdx fixField
    | LocationID fixField -> WriteLocationID dest nextFreeIdx fixField
    | DeskID fixField -> WriteDeskID dest nextFreeIdx fixField
    | DeleteReason fixField -> WriteDeleteReason dest nextFreeIdx fixField
    | OpenCloseSettlFlag fixField -> WriteOpenCloseSettlFlag dest nextFreeIdx fixField
    | SellerDays fixField -> WriteSellerDays dest nextFreeIdx fixField
    | MDEntryBuyer fixField -> WriteMDEntryBuyer dest nextFreeIdx fixField
    | MDEntrySeller fixField -> WriteMDEntrySeller dest nextFreeIdx fixField
    | MDEntryPositionNo fixField -> WriteMDEntryPositionNo dest nextFreeIdx fixField
    | FinancialStatus fixField -> WriteFinancialStatus dest nextFreeIdx fixField
    | CorporateAction fixField -> WriteCorporateAction dest nextFreeIdx fixField
    | DefBidSize fixField -> WriteDefBidSize dest nextFreeIdx fixField
    | DefOfferSize fixField -> WriteDefOfferSize dest nextFreeIdx fixField
    | NoQuoteEntries fixField -> WriteNoQuoteEntries dest nextFreeIdx fixField
    | NoQuoteSets fixField -> WriteNoQuoteSets dest nextFreeIdx fixField
    | QuoteStatus fixField -> WriteQuoteStatus dest nextFreeIdx fixField
    | QuoteCancelType fixField -> WriteQuoteCancelType dest nextFreeIdx fixField
    | QuoteEntryID fixField -> WriteQuoteEntryID dest nextFreeIdx fixField
    | QuoteRejectReason fixField -> WriteQuoteRejectReason dest nextFreeIdx fixField
    | QuoteResponseLevel fixField -> WriteQuoteResponseLevel dest nextFreeIdx fixField
    | QuoteSetID fixField -> WriteQuoteSetID dest nextFreeIdx fixField
    | QuoteRequestType fixField -> WriteQuoteRequestType dest nextFreeIdx fixField
    | TotNoQuoteEntries fixField -> WriteTotNoQuoteEntries dest nextFreeIdx fixField
    | UnderlyingSecurityIDSource fixField -> WriteUnderlyingSecurityIDSource dest nextFreeIdx fixField
    | UnderlyingIssuer fixField -> WriteUnderlyingIssuer dest nextFreeIdx fixField
    | UnderlyingSecurityDesc fixField -> WriteUnderlyingSecurityDesc dest nextFreeIdx fixField
    | UnderlyingSecurityExchange fixField -> WriteUnderlyingSecurityExchange dest nextFreeIdx fixField
    | UnderlyingSecurityID fixField -> WriteUnderlyingSecurityID dest nextFreeIdx fixField
    | UnderlyingSecurityType fixField -> WriteUnderlyingSecurityType dest nextFreeIdx fixField
    | UnderlyingSymbol fixField -> WriteUnderlyingSymbol dest nextFreeIdx fixField
    | UnderlyingSymbolSfx fixField -> WriteUnderlyingSymbolSfx dest nextFreeIdx fixField
    | UnderlyingMaturityMonthYear fixField -> WriteUnderlyingMaturityMonthYear dest nextFreeIdx fixField
    | UnderlyingPutOrCall fixField -> WriteUnderlyingPutOrCall dest nextFreeIdx fixField
    | UnderlyingStrikePrice fixField -> WriteUnderlyingStrikePrice dest nextFreeIdx fixField
    | UnderlyingOptAttribute fixField -> WriteUnderlyingOptAttribute dest nextFreeIdx fixField
    | UnderlyingCurrency fixField -> WriteUnderlyingCurrency dest nextFreeIdx fixField
    | SecurityReqID fixField -> WriteSecurityReqID dest nextFreeIdx fixField
    | SecurityRequestType fixField -> WriteSecurityRequestType dest nextFreeIdx fixField
    | SecurityResponseID fixField -> WriteSecurityResponseID dest nextFreeIdx fixField
    | SecurityResponseType fixField -> WriteSecurityResponseType dest nextFreeIdx fixField
    | SecurityStatusReqID fixField -> WriteSecurityStatusReqID dest nextFreeIdx fixField
    | UnsolicitedIndicator fixField -> WriteUnsolicitedIndicator dest nextFreeIdx fixField
    | SecurityTradingStatus fixField -> WriteSecurityTradingStatus dest nextFreeIdx fixField
    | HaltReason fixField -> WriteHaltReason dest nextFreeIdx fixField
    | InViewOfCommon fixField -> WriteInViewOfCommon dest nextFreeIdx fixField
    | DueToRelated fixField -> WriteDueToRelated dest nextFreeIdx fixField
    | BuyVolume fixField -> WriteBuyVolume dest nextFreeIdx fixField
    | SellVolume fixField -> WriteSellVolume dest nextFreeIdx fixField
    | HighPx fixField -> WriteHighPx dest nextFreeIdx fixField
    | LowPx fixField -> WriteLowPx dest nextFreeIdx fixField
    | Adjustment fixField -> WriteAdjustment dest nextFreeIdx fixField
    | TradSesReqID fixField -> WriteTradSesReqID dest nextFreeIdx fixField
    | TradingSessionID fixField -> WriteTradingSessionID dest nextFreeIdx fixField
    | ContraTrader fixField -> WriteContraTrader dest nextFreeIdx fixField
    | TradSesMethod fixField -> WriteTradSesMethod dest nextFreeIdx fixField
    | TradSesMode fixField -> WriteTradSesMode dest nextFreeIdx fixField
    | TradSesStatus fixField -> WriteTradSesStatus dest nextFreeIdx fixField
    | TradSesStartTime fixField -> WriteTradSesStartTime dest nextFreeIdx fixField
    | TradSesOpenTime fixField -> WriteTradSesOpenTime dest nextFreeIdx fixField
    | TradSesPreCloseTime fixField -> WriteTradSesPreCloseTime dest nextFreeIdx fixField
    | TradSesCloseTime fixField -> WriteTradSesCloseTime dest nextFreeIdx fixField
    | TradSesEndTime fixField -> WriteTradSesEndTime dest nextFreeIdx fixField
    | NumberOfOrders fixField -> WriteNumberOfOrders dest nextFreeIdx fixField
    | MessageEncoding fixField -> WriteMessageEncoding dest nextFreeIdx fixField
    | EncodedIssuer fixField -> WriteEncodedIssuer dest nextFreeIdx fixField // compound field
    | EncodedSecurityDesc fixField -> WriteEncodedSecurityDesc dest nextFreeIdx fixField // compound field
    | EncodedListExecInst fixField -> WriteEncodedListExecInst dest nextFreeIdx fixField // compound field
    | EncodedText fixField -> WriteEncodedText dest nextFreeIdx fixField // compound field
    | EncodedSubject fixField -> WriteEncodedSubject dest nextFreeIdx fixField // compound field
    | EncodedHeadline fixField -> WriteEncodedHeadline dest nextFreeIdx fixField // compound field
    | EncodedAllocText fixField -> WriteEncodedAllocText dest nextFreeIdx fixField // compound field
    | EncodedUnderlyingIssuer fixField -> WriteEncodedUnderlyingIssuer dest nextFreeIdx fixField // compound field
    | EncodedUnderlyingSecurityDesc fixField -> WriteEncodedUnderlyingSecurityDesc dest nextFreeIdx fixField // compound field
    | AllocPrice fixField -> WriteAllocPrice dest nextFreeIdx fixField
    | QuoteSetValidUntilTime fixField -> WriteQuoteSetValidUntilTime dest nextFreeIdx fixField
    | QuoteEntryRejectReason fixField -> WriteQuoteEntryRejectReason dest nextFreeIdx fixField
    | LastMsgSeqNumProcessed fixField -> WriteLastMsgSeqNumProcessed dest nextFreeIdx fixField
    | RefTagID fixField -> WriteRefTagID dest nextFreeIdx fixField
    | RefMsgType fixField -> WriteRefMsgType dest nextFreeIdx fixField
    | SessionRejectReason fixField -> WriteSessionRejectReason dest nextFreeIdx fixField
    | BidRequestTransType fixField -> WriteBidRequestTransType dest nextFreeIdx fixField
    | ContraBroker fixField -> WriteContraBroker dest nextFreeIdx fixField
    | ComplianceID fixField -> WriteComplianceID dest nextFreeIdx fixField
    | SolicitedFlag fixField -> WriteSolicitedFlag dest nextFreeIdx fixField
    | ExecRestatementReason fixField -> WriteExecRestatementReason dest nextFreeIdx fixField
    | BusinessRejectRefID fixField -> WriteBusinessRejectRefID dest nextFreeIdx fixField
    | BusinessRejectReason fixField -> WriteBusinessRejectReason dest nextFreeIdx fixField
    | GrossTradeAmt fixField -> WriteGrossTradeAmt dest nextFreeIdx fixField
    | NoContraBrokers fixField -> WriteNoContraBrokers dest nextFreeIdx fixField
    | MaxMessageSize fixField -> WriteMaxMessageSize dest nextFreeIdx fixField
    | NoMsgTypes fixField -> WriteNoMsgTypes dest nextFreeIdx fixField
    | MsgDirection fixField -> WriteMsgDirection dest nextFreeIdx fixField
    | NoTradingSessions fixField -> WriteNoTradingSessions dest nextFreeIdx fixField
    | TotalVolumeTraded fixField -> WriteTotalVolumeTraded dest nextFreeIdx fixField
    | DiscretionInst fixField -> WriteDiscretionInst dest nextFreeIdx fixField
    | DiscretionOffsetValue fixField -> WriteDiscretionOffsetValue dest nextFreeIdx fixField
    | BidID fixField -> WriteBidID dest nextFreeIdx fixField
    | ClientBidID fixField -> WriteClientBidID dest nextFreeIdx fixField
    | ListName fixField -> WriteListName dest nextFreeIdx fixField
    | TotNoRelatedSym fixField -> WriteTotNoRelatedSym dest nextFreeIdx fixField
    | BidType fixField -> WriteBidType dest nextFreeIdx fixField
    | NumTickets fixField -> WriteNumTickets dest nextFreeIdx fixField
    | SideValue1 fixField -> WriteSideValue1 dest nextFreeIdx fixField
    | SideValue2 fixField -> WriteSideValue2 dest nextFreeIdx fixField
    | NoBidDescriptors fixField -> WriteNoBidDescriptors dest nextFreeIdx fixField
    | BidDescriptorType fixField -> WriteBidDescriptorType dest nextFreeIdx fixField
    | BidDescriptor fixField -> WriteBidDescriptor dest nextFreeIdx fixField
    | SideValueInd fixField -> WriteSideValueInd dest nextFreeIdx fixField
    | LiquidityPctLow fixField -> WriteLiquidityPctLow dest nextFreeIdx fixField
    | LiquidityPctHigh fixField -> WriteLiquidityPctHigh dest nextFreeIdx fixField
    | LiquidityValue fixField -> WriteLiquidityValue dest nextFreeIdx fixField
    | EFPTrackingError fixField -> WriteEFPTrackingError dest nextFreeIdx fixField
    | FairValue fixField -> WriteFairValue dest nextFreeIdx fixField
    | OutsideIndexPct fixField -> WriteOutsideIndexPct dest nextFreeIdx fixField
    | ValueOfFutures fixField -> WriteValueOfFutures dest nextFreeIdx fixField
    | LiquidityIndType fixField -> WriteLiquidityIndType dest nextFreeIdx fixField
    | WtAverageLiquidity fixField -> WriteWtAverageLiquidity dest nextFreeIdx fixField
    | ExchangeForPhysical fixField -> WriteExchangeForPhysical dest nextFreeIdx fixField
    | OutMainCntryUIndex fixField -> WriteOutMainCntryUIndex dest nextFreeIdx fixField
    | CrossPercent fixField -> WriteCrossPercent dest nextFreeIdx fixField
    | ProgRptReqs fixField -> WriteProgRptReqs dest nextFreeIdx fixField
    | ProgPeriodInterval fixField -> WriteProgPeriodInterval dest nextFreeIdx fixField
    | IncTaxInd fixField -> WriteIncTaxInd dest nextFreeIdx fixField
    | NumBidders fixField -> WriteNumBidders dest nextFreeIdx fixField
    | BidTradeType fixField -> WriteBidTradeType dest nextFreeIdx fixField
    | BasisPxType fixField -> WriteBasisPxType dest nextFreeIdx fixField
    | NoBidComponents fixField -> WriteNoBidComponents dest nextFreeIdx fixField
    | Country fixField -> WriteCountry dest nextFreeIdx fixField
    | TotNoStrikes fixField -> WriteTotNoStrikes dest nextFreeIdx fixField
    | PriceType fixField -> WritePriceType dest nextFreeIdx fixField
    | DayOrderQty fixField -> WriteDayOrderQty dest nextFreeIdx fixField
    | DayCumQty fixField -> WriteDayCumQty dest nextFreeIdx fixField
    | DayAvgPx fixField -> WriteDayAvgPx dest nextFreeIdx fixField
    | GTBookingInst fixField -> WriteGTBookingInst dest nextFreeIdx fixField
    | NoStrikes fixField -> WriteNoStrikes dest nextFreeIdx fixField
    | ListStatusType fixField -> WriteListStatusType dest nextFreeIdx fixField
    | NetGrossInd fixField -> WriteNetGrossInd dest nextFreeIdx fixField
    | ListOrderStatus fixField -> WriteListOrderStatus dest nextFreeIdx fixField
    | ExpireDate fixField -> WriteExpireDate dest nextFreeIdx fixField
    | ListExecInstType fixField -> WriteListExecInstType dest nextFreeIdx fixField
    | CxlRejResponseTo fixField -> WriteCxlRejResponseTo dest nextFreeIdx fixField
    | UnderlyingCouponRate fixField -> WriteUnderlyingCouponRate dest nextFreeIdx fixField
    | UnderlyingContractMultiplier fixField -> WriteUnderlyingContractMultiplier dest nextFreeIdx fixField
    | ContraTradeQty fixField -> WriteContraTradeQty dest nextFreeIdx fixField
    | ContraTradeTime fixField -> WriteContraTradeTime dest nextFreeIdx fixField
    | LiquidityNumSecurities fixField -> WriteLiquidityNumSecurities dest nextFreeIdx fixField
    | MultiLegReportingType fixField -> WriteMultiLegReportingType dest nextFreeIdx fixField
    | StrikeTime fixField -> WriteStrikeTime dest nextFreeIdx fixField
    | ListStatusText fixField -> WriteListStatusText dest nextFreeIdx fixField
    | EncodedListStatusText fixField -> WriteEncodedListStatusText dest nextFreeIdx fixField // compound field
    | PartyIDSource fixField -> WritePartyIDSource dest nextFreeIdx fixField
    | PartyID fixField -> WritePartyID dest nextFreeIdx fixField
    | NetChgPrevDay fixField -> WriteNetChgPrevDay dest nextFreeIdx fixField
    | PartyRole fixField -> WritePartyRole dest nextFreeIdx fixField
    | NoPartyIDs fixField -> WriteNoPartyIDs dest nextFreeIdx fixField
    | NoSecurityAltID fixField -> WriteNoSecurityAltID dest nextFreeIdx fixField
    | SecurityAltID fixField -> WriteSecurityAltID dest nextFreeIdx fixField
    | SecurityAltIDSource fixField -> WriteSecurityAltIDSource dest nextFreeIdx fixField
    | NoUnderlyingSecurityAltID fixField -> WriteNoUnderlyingSecurityAltID dest nextFreeIdx fixField
    | UnderlyingSecurityAltID fixField -> WriteUnderlyingSecurityAltID dest nextFreeIdx fixField
    | UnderlyingSecurityAltIDSource fixField -> WriteUnderlyingSecurityAltIDSource dest nextFreeIdx fixField
    | Product fixField -> WriteProduct dest nextFreeIdx fixField
    | CFICode fixField -> WriteCFICode dest nextFreeIdx fixField
    | UnderlyingProduct fixField -> WriteUnderlyingProduct dest nextFreeIdx fixField
    | UnderlyingCFICode fixField -> WriteUnderlyingCFICode dest nextFreeIdx fixField
    | TestMessageIndicator fixField -> WriteTestMessageIndicator dest nextFreeIdx fixField
    | QuantityType fixField -> WriteQuantityType dest nextFreeIdx fixField
    | BookingRefID fixField -> WriteBookingRefID dest nextFreeIdx fixField
    | IndividualAllocID fixField -> WriteIndividualAllocID dest nextFreeIdx fixField
    | RoundingDirection fixField -> WriteRoundingDirection dest nextFreeIdx fixField
    | RoundingModulus fixField -> WriteRoundingModulus dest nextFreeIdx fixField
    | CountryOfIssue fixField -> WriteCountryOfIssue dest nextFreeIdx fixField
    | StateOrProvinceOfIssue fixField -> WriteStateOrProvinceOfIssue dest nextFreeIdx fixField
    | LocaleOfIssue fixField -> WriteLocaleOfIssue dest nextFreeIdx fixField
    | NoRegistDtls fixField -> WriteNoRegistDtls dest nextFreeIdx fixField
    | MailingDtls fixField -> WriteMailingDtls dest nextFreeIdx fixField
    | InvestorCountryOfResidence fixField -> WriteInvestorCountryOfResidence dest nextFreeIdx fixField
    | PaymentRef fixField -> WritePaymentRef dest nextFreeIdx fixField
    | DistribPaymentMethod fixField -> WriteDistribPaymentMethod dest nextFreeIdx fixField
    | CashDistribCurr fixField -> WriteCashDistribCurr dest nextFreeIdx fixField
    | CommCurrency fixField -> WriteCommCurrency dest nextFreeIdx fixField
    | CancellationRights fixField -> WriteCancellationRights dest nextFreeIdx fixField
    | MoneyLaunderingStatus fixField -> WriteMoneyLaunderingStatus dest nextFreeIdx fixField
    | MailingInst fixField -> WriteMailingInst dest nextFreeIdx fixField
    | TransBkdTime fixField -> WriteTransBkdTime dest nextFreeIdx fixField
    | ExecPriceType fixField -> WriteExecPriceType dest nextFreeIdx fixField
    | ExecPriceAdjustment fixField -> WriteExecPriceAdjustment dest nextFreeIdx fixField
    | DateOfBirth fixField -> WriteDateOfBirth dest nextFreeIdx fixField
    | TradeReportTransType fixField -> WriteTradeReportTransType dest nextFreeIdx fixField
    | CardHolderName fixField -> WriteCardHolderName dest nextFreeIdx fixField
    | CardNumber fixField -> WriteCardNumber dest nextFreeIdx fixField
    | CardExpDate fixField -> WriteCardExpDate dest nextFreeIdx fixField
    | CardIssNum fixField -> WriteCardIssNum dest nextFreeIdx fixField
    | PaymentMethod fixField -> WritePaymentMethod dest nextFreeIdx fixField
    | RegistAcctType fixField -> WriteRegistAcctType dest nextFreeIdx fixField
    | Designation fixField -> WriteDesignation dest nextFreeIdx fixField
    | TaxAdvantageType fixField -> WriteTaxAdvantageType dest nextFreeIdx fixField
    | RegistRejReasonText fixField -> WriteRegistRejReasonText dest nextFreeIdx fixField
    | FundRenewWaiv fixField -> WriteFundRenewWaiv dest nextFreeIdx fixField
    | CashDistribAgentName fixField -> WriteCashDistribAgentName dest nextFreeIdx fixField
    | CashDistribAgentCode fixField -> WriteCashDistribAgentCode dest nextFreeIdx fixField
    | CashDistribAgentAcctNumber fixField -> WriteCashDistribAgentAcctNumber dest nextFreeIdx fixField
    | CashDistribPayRef fixField -> WriteCashDistribPayRef dest nextFreeIdx fixField
    | CashDistribAgentAcctName fixField -> WriteCashDistribAgentAcctName dest nextFreeIdx fixField
    | CardStartDate fixField -> WriteCardStartDate dest nextFreeIdx fixField
    | PaymentDate fixField -> WritePaymentDate dest nextFreeIdx fixField
    | PaymentRemitterID fixField -> WritePaymentRemitterID dest nextFreeIdx fixField
    | RegistStatus fixField -> WriteRegistStatus dest nextFreeIdx fixField
    | RegistRejReasonCode fixField -> WriteRegistRejReasonCode dest nextFreeIdx fixField
    | RegistRefID fixField -> WriteRegistRefID dest nextFreeIdx fixField
    | RegistDtls fixField -> WriteRegistDtls dest nextFreeIdx fixField
    | NoDistribInsts fixField -> WriteNoDistribInsts dest nextFreeIdx fixField
    | RegistEmail fixField -> WriteRegistEmail dest nextFreeIdx fixField
    | DistribPercentage fixField -> WriteDistribPercentage dest nextFreeIdx fixField
    | RegistID fixField -> WriteRegistID dest nextFreeIdx fixField
    | RegistTransType fixField -> WriteRegistTransType dest nextFreeIdx fixField
    | ExecValuationPoint fixField -> WriteExecValuationPoint dest nextFreeIdx fixField
    | OrderPercent fixField -> WriteOrderPercent dest nextFreeIdx fixField
    | OwnershipType fixField -> WriteOwnershipType dest nextFreeIdx fixField
    | NoContAmts fixField -> WriteNoContAmts dest nextFreeIdx fixField
    | ContAmtType fixField -> WriteContAmtType dest nextFreeIdx fixField
    | ContAmtValue fixField -> WriteContAmtValue dest nextFreeIdx fixField
    | ContAmtCurr fixField -> WriteContAmtCurr dest nextFreeIdx fixField
    | OwnerType fixField -> WriteOwnerType dest nextFreeIdx fixField
    | PartySubID fixField -> WritePartySubID dest nextFreeIdx fixField
    | NestedPartyID fixField -> WriteNestedPartyID dest nextFreeIdx fixField
    | NestedPartyIDSource fixField -> WriteNestedPartyIDSource dest nextFreeIdx fixField
    | SecondaryClOrdID fixField -> WriteSecondaryClOrdID dest nextFreeIdx fixField
    | SecondaryExecID fixField -> WriteSecondaryExecID dest nextFreeIdx fixField
    | OrderCapacity fixField -> WriteOrderCapacity dest nextFreeIdx fixField
    | OrderRestrictions fixField -> WriteOrderRestrictions dest nextFreeIdx fixField
    | MassCancelRequestType fixField -> WriteMassCancelRequestType dest nextFreeIdx fixField
    | MassCancelResponse fixField -> WriteMassCancelResponse dest nextFreeIdx fixField
    | MassCancelRejectReason fixField -> WriteMassCancelRejectReason dest nextFreeIdx fixField
    | TotalAffectedOrders fixField -> WriteTotalAffectedOrders dest nextFreeIdx fixField
    | NoAffectedOrders fixField -> WriteNoAffectedOrders dest nextFreeIdx fixField
    | AffectedOrderID fixField -> WriteAffectedOrderID dest nextFreeIdx fixField
    | AffectedSecondaryOrderID fixField -> WriteAffectedSecondaryOrderID dest nextFreeIdx fixField
    | QuoteType fixField -> WriteQuoteType dest nextFreeIdx fixField
    | NestedPartyRole fixField -> WriteNestedPartyRole dest nextFreeIdx fixField
    | NoNestedPartyIDs fixField -> WriteNoNestedPartyIDs dest nextFreeIdx fixField
    | TotalAccruedInterestAmt fixField -> WriteTotalAccruedInterestAmt dest nextFreeIdx fixField
    | MaturityDate fixField -> WriteMaturityDate dest nextFreeIdx fixField
    | UnderlyingMaturityDate fixField -> WriteUnderlyingMaturityDate dest nextFreeIdx fixField
    | InstrRegistry fixField -> WriteInstrRegistry dest nextFreeIdx fixField
    | CashMargin fixField -> WriteCashMargin dest nextFreeIdx fixField
    | NestedPartySubID fixField -> WriteNestedPartySubID dest nextFreeIdx fixField
    | Scope fixField -> WriteScope dest nextFreeIdx fixField
    | MDImplicitDelete fixField -> WriteMDImplicitDelete dest nextFreeIdx fixField
    | CrossID fixField -> WriteCrossID dest nextFreeIdx fixField
    | CrossType fixField -> WriteCrossType dest nextFreeIdx fixField
    | CrossPrioritization fixField -> WriteCrossPrioritization dest nextFreeIdx fixField
    | OrigCrossID fixField -> WriteOrigCrossID dest nextFreeIdx fixField
    | NoSides fixField -> WriteNoSides dest nextFreeIdx fixField
    | Username fixField -> WriteUsername dest nextFreeIdx fixField
    | Password fixField -> WritePassword dest nextFreeIdx fixField
    | NoLegs fixField -> WriteNoLegs dest nextFreeIdx fixField
    | LegCurrency fixField -> WriteLegCurrency dest nextFreeIdx fixField
    | TotNoSecurityTypes fixField -> WriteTotNoSecurityTypes dest nextFreeIdx fixField
    | NoSecurityTypes fixField -> WriteNoSecurityTypes dest nextFreeIdx fixField
    | SecurityListRequestType fixField -> WriteSecurityListRequestType dest nextFreeIdx fixField
    | SecurityRequestResult fixField -> WriteSecurityRequestResult dest nextFreeIdx fixField
    | RoundLot fixField -> WriteRoundLot dest nextFreeIdx fixField
    | MinTradeVol fixField -> WriteMinTradeVol dest nextFreeIdx fixField
    | MultiLegRptTypeReq fixField -> WriteMultiLegRptTypeReq dest nextFreeIdx fixField
    | LegPositionEffect fixField -> WriteLegPositionEffect dest nextFreeIdx fixField
    | LegCoveredOrUncovered fixField -> WriteLegCoveredOrUncovered dest nextFreeIdx fixField
    | LegPrice fixField -> WriteLegPrice dest nextFreeIdx fixField
    | TradSesStatusRejReason fixField -> WriteTradSesStatusRejReason dest nextFreeIdx fixField
    | TradeRequestID fixField -> WriteTradeRequestID dest nextFreeIdx fixField
    | TradeRequestType fixField -> WriteTradeRequestType dest nextFreeIdx fixField
    | PreviouslyReported fixField -> WritePreviouslyReported dest nextFreeIdx fixField
    | TradeReportID fixField -> WriteTradeReportID dest nextFreeIdx fixField
    | TradeReportRefID fixField -> WriteTradeReportRefID dest nextFreeIdx fixField
    | MatchStatus fixField -> WriteMatchStatus dest nextFreeIdx fixField
    | MatchType fixField -> WriteMatchType dest nextFreeIdx fixField
    | OddLot fixField -> WriteOddLot dest nextFreeIdx fixField
    | NoClearingInstructions fixField -> WriteNoClearingInstructions dest nextFreeIdx fixField
    | ClearingInstruction fixField -> WriteClearingInstruction dest nextFreeIdx fixField
    | TradeInputSource fixField -> WriteTradeInputSource dest nextFreeIdx fixField
    | TradeInputDevice fixField -> WriteTradeInputDevice dest nextFreeIdx fixField
    | NoDates fixField -> WriteNoDates dest nextFreeIdx fixField
    | AccountType fixField -> WriteAccountType dest nextFreeIdx fixField
    | CustOrderCapacity fixField -> WriteCustOrderCapacity dest nextFreeIdx fixField
    | ClOrdLinkID fixField -> WriteClOrdLinkID dest nextFreeIdx fixField
    | MassStatusReqID fixField -> WriteMassStatusReqID dest nextFreeIdx fixField
    | MassStatusReqType fixField -> WriteMassStatusReqType dest nextFreeIdx fixField
    | OrigOrdModTime fixField -> WriteOrigOrdModTime dest nextFreeIdx fixField
    | LegSettlType fixField -> WriteLegSettlType dest nextFreeIdx fixField
    | LegSettlDate fixField -> WriteLegSettlDate dest nextFreeIdx fixField
    | DayBookingInst fixField -> WriteDayBookingInst dest nextFreeIdx fixField
    | BookingUnit fixField -> WriteBookingUnit dest nextFreeIdx fixField
    | PreallocMethod fixField -> WritePreallocMethod dest nextFreeIdx fixField
    | UnderlyingCountryOfIssue fixField -> WriteUnderlyingCountryOfIssue dest nextFreeIdx fixField
    | UnderlyingStateOrProvinceOfIssue fixField -> WriteUnderlyingStateOrProvinceOfIssue dest nextFreeIdx fixField
    | UnderlyingLocaleOfIssue fixField -> WriteUnderlyingLocaleOfIssue dest nextFreeIdx fixField
    | UnderlyingInstrRegistry fixField -> WriteUnderlyingInstrRegistry dest nextFreeIdx fixField
    | LegCountryOfIssue fixField -> WriteLegCountryOfIssue dest nextFreeIdx fixField
    | LegStateOrProvinceOfIssue fixField -> WriteLegStateOrProvinceOfIssue dest nextFreeIdx fixField
    | LegLocaleOfIssue fixField -> WriteLegLocaleOfIssue dest nextFreeIdx fixField
    | LegInstrRegistry fixField -> WriteLegInstrRegistry dest nextFreeIdx fixField
    | LegSymbol fixField -> WriteLegSymbol dest nextFreeIdx fixField
    | LegSymbolSfx fixField -> WriteLegSymbolSfx dest nextFreeIdx fixField
    | LegSecurityID fixField -> WriteLegSecurityID dest nextFreeIdx fixField
    | LegSecurityIDSource fixField -> WriteLegSecurityIDSource dest nextFreeIdx fixField
    | NoLegSecurityAltID fixField -> WriteNoLegSecurityAltID dest nextFreeIdx fixField
    | LegSecurityAltID fixField -> WriteLegSecurityAltID dest nextFreeIdx fixField
    | LegSecurityAltIDSource fixField -> WriteLegSecurityAltIDSource dest nextFreeIdx fixField
    | LegProduct fixField -> WriteLegProduct dest nextFreeIdx fixField
    | LegCFICode fixField -> WriteLegCFICode dest nextFreeIdx fixField
    | LegSecurityType fixField -> WriteLegSecurityType dest nextFreeIdx fixField
    | LegMaturityMonthYear fixField -> WriteLegMaturityMonthYear dest nextFreeIdx fixField
    | LegMaturityDate fixField -> WriteLegMaturityDate dest nextFreeIdx fixField
    | LegStrikePrice fixField -> WriteLegStrikePrice dest nextFreeIdx fixField
    | LegOptAttribute fixField -> WriteLegOptAttribute dest nextFreeIdx fixField
    | LegContractMultiplier fixField -> WriteLegContractMultiplier dest nextFreeIdx fixField
    | LegCouponRate fixField -> WriteLegCouponRate dest nextFreeIdx fixField
    | LegSecurityExchange fixField -> WriteLegSecurityExchange dest nextFreeIdx fixField
    | LegIssuer fixField -> WriteLegIssuer dest nextFreeIdx fixField
    | EncodedLegIssuer fixField -> WriteEncodedLegIssuer dest nextFreeIdx fixField // compound field
    | LegSecurityDesc fixField -> WriteLegSecurityDesc dest nextFreeIdx fixField
    | EncodedLegSecurityDesc fixField -> WriteEncodedLegSecurityDesc dest nextFreeIdx fixField // compound field
    | LegRatioQty fixField -> WriteLegRatioQty dest nextFreeIdx fixField
    | LegSide fixField -> WriteLegSide dest nextFreeIdx fixField
    | TradingSessionSubID fixField -> WriteTradingSessionSubID dest nextFreeIdx fixField
    | AllocType fixField -> WriteAllocType dest nextFreeIdx fixField
    | NoHops fixField -> WriteNoHops dest nextFreeIdx fixField
    | HopCompID fixField -> WriteHopCompID dest nextFreeIdx fixField
    | HopSendingTime fixField -> WriteHopSendingTime dest nextFreeIdx fixField
    | HopRefID fixField -> WriteHopRefID dest nextFreeIdx fixField
    | MidPx fixField -> WriteMidPx dest nextFreeIdx fixField
    | BidYield fixField -> WriteBidYield dest nextFreeIdx fixField
    | MidYield fixField -> WriteMidYield dest nextFreeIdx fixField
    | OfferYield fixField -> WriteOfferYield dest nextFreeIdx fixField
    | ClearingFeeIndicator fixField -> WriteClearingFeeIndicator dest nextFreeIdx fixField
    | WorkingIndicator fixField -> WriteWorkingIndicator dest nextFreeIdx fixField
    | LegLastPx fixField -> WriteLegLastPx dest nextFreeIdx fixField
    | PriorityIndicator fixField -> WritePriorityIndicator dest nextFreeIdx fixField
    | PriceImprovement fixField -> WritePriceImprovement dest nextFreeIdx fixField
    | Price2 fixField -> WritePrice2 dest nextFreeIdx fixField
    | LastForwardPoints2 fixField -> WriteLastForwardPoints2 dest nextFreeIdx fixField
    | BidForwardPoints2 fixField -> WriteBidForwardPoints2 dest nextFreeIdx fixField
    | OfferForwardPoints2 fixField -> WriteOfferForwardPoints2 dest nextFreeIdx fixField
    | RFQReqID fixField -> WriteRFQReqID dest nextFreeIdx fixField
    | MktBidPx fixField -> WriteMktBidPx dest nextFreeIdx fixField
    | MktOfferPx fixField -> WriteMktOfferPx dest nextFreeIdx fixField
    | MinBidSize fixField -> WriteMinBidSize dest nextFreeIdx fixField
    | MinOfferSize fixField -> WriteMinOfferSize dest nextFreeIdx fixField
    | QuoteStatusReqID fixField -> WriteQuoteStatusReqID dest nextFreeIdx fixField
    | LegalConfirm fixField -> WriteLegalConfirm dest nextFreeIdx fixField
    | UnderlyingLastPx fixField -> WriteUnderlyingLastPx dest nextFreeIdx fixField
    | UnderlyingLastQty fixField -> WriteUnderlyingLastQty dest nextFreeIdx fixField
    | LegRefID fixField -> WriteLegRefID dest nextFreeIdx fixField
    | ContraLegRefID fixField -> WriteContraLegRefID dest nextFreeIdx fixField
    | SettlCurrBidFxRate fixField -> WriteSettlCurrBidFxRate dest nextFreeIdx fixField
    | SettlCurrOfferFxRate fixField -> WriteSettlCurrOfferFxRate dest nextFreeIdx fixField
    | QuoteRequestRejectReason fixField -> WriteQuoteRequestRejectReason dest nextFreeIdx fixField
    | SideComplianceID fixField -> WriteSideComplianceID dest nextFreeIdx fixField
    | AcctIDSource fixField -> WriteAcctIDSource dest nextFreeIdx fixField
    | AllocAcctIDSource fixField -> WriteAllocAcctIDSource dest nextFreeIdx fixField
    | BenchmarkPrice fixField -> WriteBenchmarkPrice dest nextFreeIdx fixField
    | BenchmarkPriceType fixField -> WriteBenchmarkPriceType dest nextFreeIdx fixField
    | ConfirmID fixField -> WriteConfirmID dest nextFreeIdx fixField
    | ConfirmStatus fixField -> WriteConfirmStatus dest nextFreeIdx fixField
    | ConfirmTransType fixField -> WriteConfirmTransType dest nextFreeIdx fixField
    | ContractSettlMonth fixField -> WriteContractSettlMonth dest nextFreeIdx fixField
    | DeliveryForm fixField -> WriteDeliveryForm dest nextFreeIdx fixField
    | LastParPx fixField -> WriteLastParPx dest nextFreeIdx fixField
    | NoLegAllocs fixField -> WriteNoLegAllocs dest nextFreeIdx fixField
    | LegAllocAccount fixField -> WriteLegAllocAccount dest nextFreeIdx fixField
    | LegIndividualAllocID fixField -> WriteLegIndividualAllocID dest nextFreeIdx fixField
    | LegAllocQty fixField -> WriteLegAllocQty dest nextFreeIdx fixField
    | LegAllocAcctIDSource fixField -> WriteLegAllocAcctIDSource dest nextFreeIdx fixField
    | LegSettlCurrency fixField -> WriteLegSettlCurrency dest nextFreeIdx fixField
    | LegBenchmarkCurveCurrency fixField -> WriteLegBenchmarkCurveCurrency dest nextFreeIdx fixField
    | LegBenchmarkCurveName fixField -> WriteLegBenchmarkCurveName dest nextFreeIdx fixField
    | LegBenchmarkCurvePoint fixField -> WriteLegBenchmarkCurvePoint dest nextFreeIdx fixField
    | LegBenchmarkPrice fixField -> WriteLegBenchmarkPrice dest nextFreeIdx fixField
    | LegBenchmarkPriceType fixField -> WriteLegBenchmarkPriceType dest nextFreeIdx fixField
    | LegBidPx fixField -> WriteLegBidPx dest nextFreeIdx fixField
    | LegIOIQty fixField -> WriteLegIOIQty dest nextFreeIdx fixField
    | NoLegStipulations fixField -> WriteNoLegStipulations dest nextFreeIdx fixField
    | LegOfferPx fixField -> WriteLegOfferPx dest nextFreeIdx fixField
    | LegOrderQty fixField -> WriteLegOrderQty dest nextFreeIdx fixField
    | LegPriceType fixField -> WriteLegPriceType dest nextFreeIdx fixField
    | LegQty fixField -> WriteLegQty dest nextFreeIdx fixField
    | LegStipulationType fixField -> WriteLegStipulationType dest nextFreeIdx fixField
    | LegStipulationValue fixField -> WriteLegStipulationValue dest nextFreeIdx fixField
    | LegSwapType fixField -> WriteLegSwapType dest nextFreeIdx fixField
    | Pool fixField -> WritePool dest nextFreeIdx fixField
    | QuotePriceType fixField -> WriteQuotePriceType dest nextFreeIdx fixField
    | QuoteRespID fixField -> WriteQuoteRespID dest nextFreeIdx fixField
    | QuoteRespType fixField -> WriteQuoteRespType dest nextFreeIdx fixField
    | QuoteQualifier fixField -> WriteQuoteQualifier dest nextFreeIdx fixField
    | YieldRedemptionDate fixField -> WriteYieldRedemptionDate dest nextFreeIdx fixField
    | YieldRedemptionPrice fixField -> WriteYieldRedemptionPrice dest nextFreeIdx fixField
    | YieldRedemptionPriceType fixField -> WriteYieldRedemptionPriceType dest nextFreeIdx fixField
    | BenchmarkSecurityID fixField -> WriteBenchmarkSecurityID dest nextFreeIdx fixField
    | ReversalIndicator fixField -> WriteReversalIndicator dest nextFreeIdx fixField
    | YieldCalcDate fixField -> WriteYieldCalcDate dest nextFreeIdx fixField
    | NoPositions fixField -> WriteNoPositions dest nextFreeIdx fixField
    | PosType fixField -> WritePosType dest nextFreeIdx fixField
    | LongQty fixField -> WriteLongQty dest nextFreeIdx fixField
    | ShortQty fixField -> WriteShortQty dest nextFreeIdx fixField
    | PosQtyStatus fixField -> WritePosQtyStatus dest nextFreeIdx fixField
    | PosAmtType fixField -> WritePosAmtType dest nextFreeIdx fixField
    | PosAmt fixField -> WritePosAmt dest nextFreeIdx fixField
    | PosTransType fixField -> WritePosTransType dest nextFreeIdx fixField
    | PosReqID fixField -> WritePosReqID dest nextFreeIdx fixField
    | NoUnderlyings fixField -> WriteNoUnderlyings dest nextFreeIdx fixField
    | PosMaintAction fixField -> WritePosMaintAction dest nextFreeIdx fixField
    | OrigPosReqRefID fixField -> WriteOrigPosReqRefID dest nextFreeIdx fixField
    | PosMaintRptRefID fixField -> WritePosMaintRptRefID dest nextFreeIdx fixField
    | ClearingBusinessDate fixField -> WriteClearingBusinessDate dest nextFreeIdx fixField
    | SettlSessID fixField -> WriteSettlSessID dest nextFreeIdx fixField
    | SettlSessSubID fixField -> WriteSettlSessSubID dest nextFreeIdx fixField
    | AdjustmentType fixField -> WriteAdjustmentType dest nextFreeIdx fixField
    | ContraryInstructionIndicator fixField -> WriteContraryInstructionIndicator dest nextFreeIdx fixField
    | PriorSpreadIndicator fixField -> WritePriorSpreadIndicator dest nextFreeIdx fixField
    | PosMaintRptID fixField -> WritePosMaintRptID dest nextFreeIdx fixField
    | PosMaintStatus fixField -> WritePosMaintStatus dest nextFreeIdx fixField
    | PosMaintResult fixField -> WritePosMaintResult dest nextFreeIdx fixField
    | PosReqType fixField -> WritePosReqType dest nextFreeIdx fixField
    | ResponseTransportType fixField -> WriteResponseTransportType dest nextFreeIdx fixField
    | ResponseDestination fixField -> WriteResponseDestination dest nextFreeIdx fixField
    | TotalNumPosReports fixField -> WriteTotalNumPosReports dest nextFreeIdx fixField
    | PosReqResult fixField -> WritePosReqResult dest nextFreeIdx fixField
    | PosReqStatus fixField -> WritePosReqStatus dest nextFreeIdx fixField
    | SettlPrice fixField -> WriteSettlPrice dest nextFreeIdx fixField
    | SettlPriceType fixField -> WriteSettlPriceType dest nextFreeIdx fixField
    | UnderlyingSettlPrice fixField -> WriteUnderlyingSettlPrice dest nextFreeIdx fixField
    | UnderlyingSettlPriceType fixField -> WriteUnderlyingSettlPriceType dest nextFreeIdx fixField
    | PriorSettlPrice fixField -> WritePriorSettlPrice dest nextFreeIdx fixField
    | NoQuoteQualifiers fixField -> WriteNoQuoteQualifiers dest nextFreeIdx fixField
    | AllocSettlCurrency fixField -> WriteAllocSettlCurrency dest nextFreeIdx fixField
    | AllocSettlCurrAmt fixField -> WriteAllocSettlCurrAmt dest nextFreeIdx fixField
    | InterestAtMaturity fixField -> WriteInterestAtMaturity dest nextFreeIdx fixField
    | LegDatedDate fixField -> WriteLegDatedDate dest nextFreeIdx fixField
    | LegPool fixField -> WriteLegPool dest nextFreeIdx fixField
    | AllocInterestAtMaturity fixField -> WriteAllocInterestAtMaturity dest nextFreeIdx fixField
    | AllocAccruedInterestAmt fixField -> WriteAllocAccruedInterestAmt dest nextFreeIdx fixField
    | DeliveryDate fixField -> WriteDeliveryDate dest nextFreeIdx fixField
    | AssignmentMethod fixField -> WriteAssignmentMethod dest nextFreeIdx fixField
    | AssignmentUnit fixField -> WriteAssignmentUnit dest nextFreeIdx fixField
    | OpenInterest fixField -> WriteOpenInterest dest nextFreeIdx fixField
    | ExerciseMethod fixField -> WriteExerciseMethod dest nextFreeIdx fixField
    | TotNumTradeReports fixField -> WriteTotNumTradeReports dest nextFreeIdx fixField
    | TradeRequestResult fixField -> WriteTradeRequestResult dest nextFreeIdx fixField
    | TradeRequestStatus fixField -> WriteTradeRequestStatus dest nextFreeIdx fixField
    | TradeReportRejectReason fixField -> WriteTradeReportRejectReason dest nextFreeIdx fixField
    | SideMultiLegReportingType fixField -> WriteSideMultiLegReportingType dest nextFreeIdx fixField
    | NoPosAmt fixField -> WriteNoPosAmt dest nextFreeIdx fixField
    | AutoAcceptIndicator fixField -> WriteAutoAcceptIndicator dest nextFreeIdx fixField
    | AllocReportID fixField -> WriteAllocReportID dest nextFreeIdx fixField
    | NoNested2PartyIDs fixField -> WriteNoNested2PartyIDs dest nextFreeIdx fixField
    | Nested2PartyID fixField -> WriteNested2PartyID dest nextFreeIdx fixField
    | Nested2PartyIDSource fixField -> WriteNested2PartyIDSource dest nextFreeIdx fixField
    | Nested2PartyRole fixField -> WriteNested2PartyRole dest nextFreeIdx fixField
    | Nested2PartySubID fixField -> WriteNested2PartySubID dest nextFreeIdx fixField
    | BenchmarkSecurityIDSource fixField -> WriteBenchmarkSecurityIDSource dest nextFreeIdx fixField
    | SecuritySubType fixField -> WriteSecuritySubType dest nextFreeIdx fixField
    | UnderlyingSecuritySubType fixField -> WriteUnderlyingSecuritySubType dest nextFreeIdx fixField
    | LegSecuritySubType fixField -> WriteLegSecuritySubType dest nextFreeIdx fixField
    | AllowableOneSidednessPct fixField -> WriteAllowableOneSidednessPct dest nextFreeIdx fixField
    | AllowableOneSidednessValue fixField -> WriteAllowableOneSidednessValue dest nextFreeIdx fixField
    | AllowableOneSidednessCurr fixField -> WriteAllowableOneSidednessCurr dest nextFreeIdx fixField
    | NoTrdRegTimestamps fixField -> WriteNoTrdRegTimestamps dest nextFreeIdx fixField
    | TrdRegTimestamp fixField -> WriteTrdRegTimestamp dest nextFreeIdx fixField
    | TrdRegTimestampType fixField -> WriteTrdRegTimestampType dest nextFreeIdx fixField
    | TrdRegTimestampOrigin fixField -> WriteTrdRegTimestampOrigin dest nextFreeIdx fixField
    | ConfirmRefID fixField -> WriteConfirmRefID dest nextFreeIdx fixField
    | ConfirmType fixField -> WriteConfirmType dest nextFreeIdx fixField
    | ConfirmRejReason fixField -> WriteConfirmRejReason dest nextFreeIdx fixField
    | BookingType fixField -> WriteBookingType dest nextFreeIdx fixField
    | IndividualAllocRejCode fixField -> WriteIndividualAllocRejCode dest nextFreeIdx fixField
    | SettlInstMsgID fixField -> WriteSettlInstMsgID dest nextFreeIdx fixField
    | NoSettlInst fixField -> WriteNoSettlInst dest nextFreeIdx fixField
    | LastUpdateTime fixField -> WriteLastUpdateTime dest nextFreeIdx fixField
    | AllocSettlInstType fixField -> WriteAllocSettlInstType dest nextFreeIdx fixField
    | NoSettlPartyIDs fixField -> WriteNoSettlPartyIDs dest nextFreeIdx fixField
    | SettlPartyID fixField -> WriteSettlPartyID dest nextFreeIdx fixField
    | SettlPartyIDSource fixField -> WriteSettlPartyIDSource dest nextFreeIdx fixField
    | SettlPartyRole fixField -> WriteSettlPartyRole dest nextFreeIdx fixField
    | SettlPartySubID fixField -> WriteSettlPartySubID dest nextFreeIdx fixField
    | SettlPartySubIDType fixField -> WriteSettlPartySubIDType dest nextFreeIdx fixField
    | DlvyInstType fixField -> WriteDlvyInstType dest nextFreeIdx fixField
    | TerminationType fixField -> WriteTerminationType dest nextFreeIdx fixField
    | NextExpectedMsgSeqNum fixField -> WriteNextExpectedMsgSeqNum dest nextFreeIdx fixField
    | OrdStatusReqID fixField -> WriteOrdStatusReqID dest nextFreeIdx fixField
    | SettlInstReqID fixField -> WriteSettlInstReqID dest nextFreeIdx fixField
    | SettlInstReqRejCode fixField -> WriteSettlInstReqRejCode dest nextFreeIdx fixField
    | SecondaryAllocID fixField -> WriteSecondaryAllocID dest nextFreeIdx fixField
    | AllocReportType fixField -> WriteAllocReportType dest nextFreeIdx fixField
    | AllocReportRefID fixField -> WriteAllocReportRefID dest nextFreeIdx fixField
    | AllocCancReplaceReason fixField -> WriteAllocCancReplaceReason dest nextFreeIdx fixField
    | CopyMsgIndicator fixField -> WriteCopyMsgIndicator dest nextFreeIdx fixField
    | AllocAccountType fixField -> WriteAllocAccountType dest nextFreeIdx fixField
    | OrderAvgPx fixField -> WriteOrderAvgPx dest nextFreeIdx fixField
    | OrderBookingQty fixField -> WriteOrderBookingQty dest nextFreeIdx fixField
    | NoSettlPartySubIDs fixField -> WriteNoSettlPartySubIDs dest nextFreeIdx fixField
    | NoPartySubIDs fixField -> WriteNoPartySubIDs dest nextFreeIdx fixField
    | PartySubIDType fixField -> WritePartySubIDType dest nextFreeIdx fixField
    | NoNestedPartySubIDs fixField -> WriteNoNestedPartySubIDs dest nextFreeIdx fixField
    | NestedPartySubIDType fixField -> WriteNestedPartySubIDType dest nextFreeIdx fixField
    | NoNested2PartySubIDs fixField -> WriteNoNested2PartySubIDs dest nextFreeIdx fixField
    | Nested2PartySubIDType fixField -> WriteNested2PartySubIDType dest nextFreeIdx fixField
    | AllocIntermedReqType fixField -> WriteAllocIntermedReqType dest nextFreeIdx fixField
    | UnderlyingPx fixField -> WriteUnderlyingPx dest nextFreeIdx fixField
    | PriceDelta fixField -> WritePriceDelta dest nextFreeIdx fixField
    | ApplQueueMax fixField -> WriteApplQueueMax dest nextFreeIdx fixField
    | ApplQueueDepth fixField -> WriteApplQueueDepth dest nextFreeIdx fixField
    | ApplQueueResolution fixField -> WriteApplQueueResolution dest nextFreeIdx fixField
    | ApplQueueAction fixField -> WriteApplQueueAction dest nextFreeIdx fixField
    | NoAltMDSource fixField -> WriteNoAltMDSource dest nextFreeIdx fixField
    | AltMDSourceID fixField -> WriteAltMDSourceID dest nextFreeIdx fixField
    | SecondaryTradeReportID fixField -> WriteSecondaryTradeReportID dest nextFreeIdx fixField
    | AvgPxIndicator fixField -> WriteAvgPxIndicator dest nextFreeIdx fixField
    | TradeLinkID fixField -> WriteTradeLinkID dest nextFreeIdx fixField
    | OrderInputDevice fixField -> WriteOrderInputDevice dest nextFreeIdx fixField
    | UnderlyingTradingSessionID fixField -> WriteUnderlyingTradingSessionID dest nextFreeIdx fixField
    | UnderlyingTradingSessionSubID fixField -> WriteUnderlyingTradingSessionSubID dest nextFreeIdx fixField
    | TradeLegRefID fixField -> WriteTradeLegRefID dest nextFreeIdx fixField
    | ExchangeRule fixField -> WriteExchangeRule dest nextFreeIdx fixField
    | TradeAllocIndicator fixField -> WriteTradeAllocIndicator dest nextFreeIdx fixField
    | ExpirationCycle fixField -> WriteExpirationCycle dest nextFreeIdx fixField
    | TrdType fixField -> WriteTrdType dest nextFreeIdx fixField
    | TrdSubType fixField -> WriteTrdSubType dest nextFreeIdx fixField
    | TransferReason fixField -> WriteTransferReason dest nextFreeIdx fixField
    | AsgnReqID fixField -> WriteAsgnReqID dest nextFreeIdx fixField
    | TotNumAssignmentReports fixField -> WriteTotNumAssignmentReports dest nextFreeIdx fixField
    | AsgnRptID fixField -> WriteAsgnRptID dest nextFreeIdx fixField
    | ThresholdAmount fixField -> WriteThresholdAmount dest nextFreeIdx fixField
    | PegMoveType fixField -> WritePegMoveType dest nextFreeIdx fixField
    | PegOffsetType fixField -> WritePegOffsetType dest nextFreeIdx fixField
    | PegLimitType fixField -> WritePegLimitType dest nextFreeIdx fixField
    | PegRoundDirection fixField -> WritePegRoundDirection dest nextFreeIdx fixField
    | PeggedPrice fixField -> WritePeggedPrice dest nextFreeIdx fixField
    | PegScope fixField -> WritePegScope dest nextFreeIdx fixField
    | DiscretionMoveType fixField -> WriteDiscretionMoveType dest nextFreeIdx fixField
    | DiscretionOffsetType fixField -> WriteDiscretionOffsetType dest nextFreeIdx fixField
    | DiscretionLimitType fixField -> WriteDiscretionLimitType dest nextFreeIdx fixField
    | DiscretionRoundDirection fixField -> WriteDiscretionRoundDirection dest nextFreeIdx fixField
    | DiscretionPrice fixField -> WriteDiscretionPrice dest nextFreeIdx fixField
    | DiscretionScope fixField -> WriteDiscretionScope dest nextFreeIdx fixField
    | TargetStrategy fixField -> WriteTargetStrategy dest nextFreeIdx fixField
    | TargetStrategyParameters fixField -> WriteTargetStrategyParameters dest nextFreeIdx fixField
    | ParticipationRate fixField -> WriteParticipationRate dest nextFreeIdx fixField
    | TargetStrategyPerformance fixField -> WriteTargetStrategyPerformance dest nextFreeIdx fixField
    | LastLiquidityInd fixField -> WriteLastLiquidityInd dest nextFreeIdx fixField
    | PublishTrdIndicator fixField -> WritePublishTrdIndicator dest nextFreeIdx fixField
    | ShortSaleReason fixField -> WriteShortSaleReason dest nextFreeIdx fixField
    | QtyType fixField -> WriteQtyType dest nextFreeIdx fixField
    | SecondaryTrdType fixField -> WriteSecondaryTrdType dest nextFreeIdx fixField
    | TradeReportType fixField -> WriteTradeReportType dest nextFreeIdx fixField
    | AllocNoOrdersType fixField -> WriteAllocNoOrdersType dest nextFreeIdx fixField
    | SharedCommission fixField -> WriteSharedCommission dest nextFreeIdx fixField
    | ConfirmReqID fixField -> WriteConfirmReqID dest nextFreeIdx fixField
    | AvgParPx fixField -> WriteAvgParPx dest nextFreeIdx fixField
    | ReportedPx fixField -> WriteReportedPx dest nextFreeIdx fixField
    | NoCapacities fixField -> WriteNoCapacities dest nextFreeIdx fixField
    | OrderCapacityQty fixField -> WriteOrderCapacityQty dest nextFreeIdx fixField
    | NoEvents fixField -> WriteNoEvents dest nextFreeIdx fixField
    | EventType fixField -> WriteEventType dest nextFreeIdx fixField
    | EventDate fixField -> WriteEventDate dest nextFreeIdx fixField
    | EventPx fixField -> WriteEventPx dest nextFreeIdx fixField
    | EventText fixField -> WriteEventText dest nextFreeIdx fixField
    | PctAtRisk fixField -> WritePctAtRisk dest nextFreeIdx fixField
    | NoInstrAttrib fixField -> WriteNoInstrAttrib dest nextFreeIdx fixField
    | InstrAttribType fixField -> WriteInstrAttribType dest nextFreeIdx fixField
    | InstrAttribValue fixField -> WriteInstrAttribValue dest nextFreeIdx fixField
    | DatedDate fixField -> WriteDatedDate dest nextFreeIdx fixField
    | InterestAccrualDate fixField -> WriteInterestAccrualDate dest nextFreeIdx fixField
    | CPProgram fixField -> WriteCPProgram dest nextFreeIdx fixField
    | CPRegType fixField -> WriteCPRegType dest nextFreeIdx fixField
    | UnderlyingCPProgram fixField -> WriteUnderlyingCPProgram dest nextFreeIdx fixField
    | UnderlyingCPRegType fixField -> WriteUnderlyingCPRegType dest nextFreeIdx fixField
    | UnderlyingQty fixField -> WriteUnderlyingQty dest nextFreeIdx fixField
    | TrdMatchID fixField -> WriteTrdMatchID dest nextFreeIdx fixField
    | SecondaryTradeReportRefID fixField -> WriteSecondaryTradeReportRefID dest nextFreeIdx fixField
    | UnderlyingDirtyPrice fixField -> WriteUnderlyingDirtyPrice dest nextFreeIdx fixField
    | UnderlyingEndPrice fixField -> WriteUnderlyingEndPrice dest nextFreeIdx fixField
    | UnderlyingStartValue fixField -> WriteUnderlyingStartValue dest nextFreeIdx fixField
    | UnderlyingCurrentValue fixField -> WriteUnderlyingCurrentValue dest nextFreeIdx fixField
    | UnderlyingEndValue fixField -> WriteUnderlyingEndValue dest nextFreeIdx fixField
    | NoUnderlyingStips fixField -> WriteNoUnderlyingStips dest nextFreeIdx fixField
    | UnderlyingStipType fixField -> WriteUnderlyingStipType dest nextFreeIdx fixField
    | UnderlyingStipValue fixField -> WriteUnderlyingStipValue dest nextFreeIdx fixField
    | MaturityNetMoney fixField -> WriteMaturityNetMoney dest nextFreeIdx fixField
    | MiscFeeBasis fixField -> WriteMiscFeeBasis dest nextFreeIdx fixField
    | TotNoAllocs fixField -> WriteTotNoAllocs dest nextFreeIdx fixField
    | LastFragment fixField -> WriteLastFragment dest nextFreeIdx fixField
    | CollReqID fixField -> WriteCollReqID dest nextFreeIdx fixField
    | CollAsgnReason fixField -> WriteCollAsgnReason dest nextFreeIdx fixField
    | CollInquiryQualifier fixField -> WriteCollInquiryQualifier dest nextFreeIdx fixField
    | NoTrades fixField -> WriteNoTrades dest nextFreeIdx fixField
    | MarginRatio fixField -> WriteMarginRatio dest nextFreeIdx fixField
    | MarginExcess fixField -> WriteMarginExcess dest nextFreeIdx fixField
    | TotalNetValue fixField -> WriteTotalNetValue dest nextFreeIdx fixField
    | CashOutstanding fixField -> WriteCashOutstanding dest nextFreeIdx fixField
    | CollAsgnID fixField -> WriteCollAsgnID dest nextFreeIdx fixField
    | CollAsgnTransType fixField -> WriteCollAsgnTransType dest nextFreeIdx fixField
    | CollRespID fixField -> WriteCollRespID dest nextFreeIdx fixField
    | CollAsgnRespType fixField -> WriteCollAsgnRespType dest nextFreeIdx fixField
    | CollAsgnRejectReason fixField -> WriteCollAsgnRejectReason dest nextFreeIdx fixField
    | CollAsgnRefID fixField -> WriteCollAsgnRefID dest nextFreeIdx fixField
    | CollRptID fixField -> WriteCollRptID dest nextFreeIdx fixField
    | CollInquiryID fixField -> WriteCollInquiryID dest nextFreeIdx fixField
    | CollStatus fixField -> WriteCollStatus dest nextFreeIdx fixField
    | TotNumReports fixField -> WriteTotNumReports dest nextFreeIdx fixField
    | LastRptRequested fixField -> WriteLastRptRequested dest nextFreeIdx fixField
    | AgreementDesc fixField -> WriteAgreementDesc dest nextFreeIdx fixField
    | AgreementID fixField -> WriteAgreementID dest nextFreeIdx fixField
    | AgreementDate fixField -> WriteAgreementDate dest nextFreeIdx fixField
    | StartDate fixField -> WriteStartDate dest nextFreeIdx fixField
    | EndDate fixField -> WriteEndDate dest nextFreeIdx fixField
    | AgreementCurrency fixField -> WriteAgreementCurrency dest nextFreeIdx fixField
    | DeliveryType fixField -> WriteDeliveryType dest nextFreeIdx fixField
    | EndAccruedInterestAmt fixField -> WriteEndAccruedInterestAmt dest nextFreeIdx fixField
    | StartCash fixField -> WriteStartCash dest nextFreeIdx fixField
    | EndCash fixField -> WriteEndCash dest nextFreeIdx fixField
    | UserRequestID fixField -> WriteUserRequestID dest nextFreeIdx fixField
    | UserRequestType fixField -> WriteUserRequestType dest nextFreeIdx fixField
    | NewPassword fixField -> WriteNewPassword dest nextFreeIdx fixField
    | UserStatus fixField -> WriteUserStatus dest nextFreeIdx fixField
    | UserStatusText fixField -> WriteUserStatusText dest nextFreeIdx fixField
    | StatusValue fixField -> WriteStatusValue dest nextFreeIdx fixField
    | StatusText fixField -> WriteStatusText dest nextFreeIdx fixField
    | RefCompID fixField -> WriteRefCompID dest nextFreeIdx fixField
    | RefSubID fixField -> WriteRefSubID dest nextFreeIdx fixField
    | NetworkResponseID fixField -> WriteNetworkResponseID dest nextFreeIdx fixField
    | NetworkRequestID fixField -> WriteNetworkRequestID dest nextFreeIdx fixField
    | LastNetworkResponseID fixField -> WriteLastNetworkResponseID dest nextFreeIdx fixField
    | NetworkRequestType fixField -> WriteNetworkRequestType dest nextFreeIdx fixField
    | NoCompIDs fixField -> WriteNoCompIDs dest nextFreeIdx fixField
    | NetworkStatusResponseType fixField -> WriteNetworkStatusResponseType dest nextFreeIdx fixField
    | NoCollInquiryQualifier fixField -> WriteNoCollInquiryQualifier dest nextFreeIdx fixField
    | TrdRptStatus fixField -> WriteTrdRptStatus dest nextFreeIdx fixField
    | AffirmStatus fixField -> WriteAffirmStatus dest nextFreeIdx fixField
    | UnderlyingStrikeCurrency fixField -> WriteUnderlyingStrikeCurrency dest nextFreeIdx fixField
    | LegStrikeCurrency fixField -> WriteLegStrikeCurrency dest nextFreeIdx fixField
    | TimeBracket fixField -> WriteTimeBracket dest nextFreeIdx fixField
    | CollAction fixField -> WriteCollAction dest nextFreeIdx fixField
    | CollInquiryStatus fixField -> WriteCollInquiryStatus dest nextFreeIdx fixField
    | CollInquiryResult fixField -> WriteCollInquiryResult dest nextFreeIdx fixField
    | StrikeCurrency fixField -> WriteStrikeCurrency dest nextFreeIdx fixField
    | NoNested3PartyIDs fixField -> WriteNoNested3PartyIDs dest nextFreeIdx fixField
    | Nested3PartyID fixField -> WriteNested3PartyID dest nextFreeIdx fixField
    | Nested3PartyIDSource fixField -> WriteNested3PartyIDSource dest nextFreeIdx fixField
    | Nested3PartyRole fixField -> WriteNested3PartyRole dest nextFreeIdx fixField
    | NoNested3PartySubIDs fixField -> WriteNoNested3PartySubIDs dest nextFreeIdx fixField
    | Nested3PartySubID fixField -> WriteNested3PartySubID dest nextFreeIdx fixField
    | Nested3PartySubIDType fixField -> WriteNested3PartySubIDType dest nextFreeIdx fixField
    | LegContractSettlMonth fixField -> WriteLegContractSettlMonth dest nextFreeIdx fixField
    | LegInterestAccrualDate fixField -> WriteLegInterestAccrualDate dest nextFreeIdx fixField


// this function is only used in property based testing
let ReadField (bs:byte[]) (pos:int) =
   let posSep = FIXBuf.findNextTagValSep bs pos
   let pos2 = posSep + 1
   let tag = FIXBufIndexer.convTagToInt bs pos (posSep - pos)
   let posEnd = FIXBuf.findNextFieldTermOrEnd bs pos2
   let len = posEnd - pos2
   match tag with
    | 1 ->
        let fld = ReadAccount bs pos2 len
        fld |> FIXField.Account
    | 2 ->
        let fld = ReadAdvId bs pos2 len
        fld |> FIXField.AdvId
    | 3 ->
        let fld = ReadAdvRefID bs pos2 len
        fld |> FIXField.AdvRefID
    | 4 ->
        let fld = ReadAdvSide bs pos2 len
        fld |> FIXField.AdvSide
    | 5 ->
        let fld = ReadAdvTransType bs pos2 len
        fld |> FIXField.AdvTransType
    | 6 ->
        let fld = ReadAvgPx bs pos2 len
        fld |> FIXField.AvgPx
    | 7 ->
        let fld = ReadBeginSeqNo bs pos2 len
        fld |> FIXField.BeginSeqNo
    | 8 ->
        let fld = ReadBeginString bs pos2 len
        fld |> FIXField.BeginString
    | 9 ->
        let fld = ReadBodyLength bs pos2 len
        fld |> FIXField.BodyLength
    | 10 ->
        let fld = ReadCheckSum bs pos2 len
        fld |> FIXField.CheckSum
    | 11 ->
        let fld = ReadClOrdID bs pos2 len
        fld |> FIXField.ClOrdID
    | 12 ->
        let fld = ReadCommission bs pos2 len
        fld |> FIXField.Commission
    | 13 ->
        let fld = ReadCommType bs pos2 len
        fld |> FIXField.CommType
    | 14 ->
        let fld = ReadCumQty bs pos2 len
        fld |> FIXField.CumQty
    | 15 ->
        let fld = ReadCurrency bs pos2 len
        fld |> FIXField.Currency
    | 16 ->
        let fld = ReadEndSeqNo bs pos2 len
        fld |> FIXField.EndSeqNo
    | 17 ->
        let fld = ReadExecID bs pos2 len
        fld |> FIXField.ExecID
    | 18 ->
        let fld = ReadExecInst bs pos2 len
        fld |> FIXField.ExecInst
    | 19 ->
        let fld = ReadExecRefID bs pos2 len
        fld |> FIXField.ExecRefID
    | 21 ->
        let fld = ReadHandlInst bs pos2 len
        fld |> FIXField.HandlInst
    | 22 ->
        let fld = ReadSecurityIDSource bs pos2 len
        fld |> FIXField.SecurityIDSource
    | 23 ->
        let fld = ReadIOIid bs pos2 len
        fld |> FIXField.IOIid
    | 25 ->
        let fld = ReadIOIQltyInd bs pos2 len
        fld |> FIXField.IOIQltyInd
    | 26 ->
        let fld = ReadIOIRefID bs pos2 len
        fld |> FIXField.IOIRefID
    | 27 ->
        let fld = ReadIOIQty bs pos2 len
        fld |> FIXField.IOIQty
    | 28 ->
        let fld = ReadIOITransType bs pos2 len
        fld |> FIXField.IOITransType
    | 29 ->
        let fld = ReadLastCapacity bs pos2 len
        fld |> FIXField.LastCapacity
    | 30 ->
        let fld = ReadLastMkt bs pos2 len
        fld |> FIXField.LastMkt
    | 31 ->
        let fld = ReadLastPx bs pos2 len
        fld |> FIXField.LastPx
    | 32 ->
        let fld = ReadLastQty bs pos2 len
        fld |> FIXField.LastQty
    | 33 ->
        let fld = ReadLinesOfText bs pos2 len
        fld |> FIXField.LinesOfText
    | 34 ->
        let fld = ReadMsgSeqNum bs pos2 len
        fld |> FIXField.MsgSeqNum
    | 35 ->
        let fld = ReadMsgType bs pos2 len
        fld |> FIXField.MsgType
    | 36 ->
        let fld = ReadNewSeqNo bs pos2 len
        fld |> FIXField.NewSeqNo
    | 37 ->
        let fld = ReadOrderID bs pos2 len
        fld |> FIXField.OrderID
    | 38 ->
        let fld = ReadOrderQty bs pos2 len
        fld |> FIXField.OrderQty
    | 39 ->
        let fld = ReadOrdStatus bs pos2 len
        fld |> FIXField.OrdStatus
    | 40 ->
        let fld = ReadOrdType bs pos2 len
        fld |> FIXField.OrdType
    | 41 ->
        let fld = ReadOrigClOrdID bs pos2 len
        fld |> FIXField.OrigClOrdID
    | 42 ->
        let fld = ReadOrigTime bs pos2 len
        fld |> FIXField.OrigTime
    | 43 ->
        let fld = ReadPossDupFlag bs pos2 len
        fld |> FIXField.PossDupFlag
    | 44 ->
        let fld = ReadPrice bs pos2 len
        fld |> FIXField.Price
    | 45 ->
        let fld = ReadRefSeqNum bs pos2 len
        fld |> FIXField.RefSeqNum
    | 48 ->
        let fld = ReadSecurityID bs pos2 len
        fld |> FIXField.SecurityID
    | 49 ->
        let fld = ReadSenderCompID bs pos2 len
        fld |> FIXField.SenderCompID
    | 50 ->
        let fld = ReadSenderSubID bs pos2 len
        fld |> FIXField.SenderSubID
    | 52 ->
        let fld = ReadSendingTime bs pos2 len
        fld |> FIXField.SendingTime
    | 53 ->
        let fld = ReadQuantity bs pos2 len
        fld |> FIXField.Quantity
    | 54 ->
        let fld = ReadSide bs pos2 len
        fld |> FIXField.Side
    | 55 ->
        let fld = ReadSymbol bs pos2 len
        fld |> FIXField.Symbol
    | 56 ->
        let fld = ReadTargetCompID bs pos2 len
        fld |> FIXField.TargetCompID
    | 57 ->
        let fld = ReadTargetSubID bs pos2 len
        fld |> FIXField.TargetSubID
    | 58 ->
        let fld = ReadText bs pos2 len
        fld |> FIXField.Text
    | 59 ->
        let fld = ReadTimeInForce bs pos2 len
        fld |> FIXField.TimeInForce
    | 60 ->
        let fld = ReadTransactTime bs pos2 len
        fld |> FIXField.TransactTime
    | 61 ->
        let fld = ReadUrgency bs pos2 len
        fld |> FIXField.Urgency
    | 62 ->
        let fld = ReadValidUntilTime bs pos2 len
        fld |> FIXField.ValidUntilTime
    | 63 ->
        let fld = ReadSettlType bs pos2 len
        fld |> FIXField.SettlType
    | 64 ->
        let fld = ReadSettlDate bs pos2 len
        fld |> FIXField.SettlDate
    | 65 ->
        let fld = ReadSymbolSfx bs pos2 len
        fld |> FIXField.SymbolSfx
    | 66 ->
        let fld = ReadListID bs pos2 len
        fld |> FIXField.ListID
    | 67 ->
        let fld = ReadListSeqNo bs pos2 len
        fld |> FIXField.ListSeqNo
    | 68 ->
        let fld = ReadTotNoOrders bs pos2 len
        fld |> FIXField.TotNoOrders
    | 69 ->
        let fld = ReadListExecInst bs pos2 len
        fld |> FIXField.ListExecInst
    | 70 ->
        let fld = ReadAllocID bs pos2 len
        fld |> FIXField.AllocID
    | 71 ->
        let fld = ReadAllocTransType bs pos2 len
        fld |> FIXField.AllocTransType
    | 72 ->
        let fld = ReadRefAllocID bs pos2 len
        fld |> FIXField.RefAllocID
    | 73 ->
        let fld = ReadNoOrders bs pos2 len
        fld |> FIXField.NoOrders
    | 74 ->
        let fld = ReadAvgPxPrecision bs pos2 len
        fld |> FIXField.AvgPxPrecision
    | 75 ->
        let fld = ReadTradeDate bs pos2 len
        fld |> FIXField.TradeDate
    | 77 ->
        let fld = ReadPositionEffect bs pos2 len
        fld |> FIXField.PositionEffect
    | 78 ->
        let fld = ReadNoAllocs bs pos2 len
        fld |> FIXField.NoAllocs
    | 79 ->
        let fld = ReadAllocAccount bs pos2 len
        fld |> FIXField.AllocAccount
    | 80 ->
        let fld = ReadAllocQty bs pos2 len
        fld |> FIXField.AllocQty
    | 81 ->
        let fld = ReadProcessCode bs pos2 len
        fld |> FIXField.ProcessCode
    | 82 ->
        let fld = ReadNoRpts bs pos2 len
        fld |> FIXField.NoRpts
    | 83 ->
        let fld = ReadRptSeq bs pos2 len
        fld |> FIXField.RptSeq
    | 84 ->
        let fld = ReadCxlQty bs pos2 len
        fld |> FIXField.CxlQty
    | 85 ->
        let fld = ReadNoDlvyInst bs pos2 len
        fld |> FIXField.NoDlvyInst
    | 87 ->
        let fld = ReadAllocStatus bs pos2 len
        fld |> FIXField.AllocStatus
    | 88 ->
        let fld = ReadAllocRejCode bs pos2 len
        fld |> FIXField.AllocRejCode
    | 93 ->
        let fld = ReadSignature bs pos2 len
        fld |> FIXField.Signature // len->string compound field
    | 90 ->
        let fld = ReadSecureData bs pos2 len
        fld |> FIXField.SecureData // len->string compound field
    | 94 ->
        let fld = ReadEmailType bs pos2 len
        fld |> FIXField.EmailType
    | 95 ->
        let fld = ReadRawData bs pos2 len
        fld |> FIXField.RawData // len->string compound field
    | 97 ->
        let fld = ReadPossResend bs pos2 len
        fld |> FIXField.PossResend
    | 98 ->
        let fld = ReadEncryptMethod bs pos2 len
        fld |> FIXField.EncryptMethod
    | 99 ->
        let fld = ReadStopPx bs pos2 len
        fld |> FIXField.StopPx
    | 100 ->
        let fld = ReadExDestination bs pos2 len
        fld |> FIXField.ExDestination
    | 102 ->
        let fld = ReadCxlRejReason bs pos2 len
        fld |> FIXField.CxlRejReason
    | 103 ->
        let fld = ReadOrdRejReason bs pos2 len
        fld |> FIXField.OrdRejReason
    | 104 ->
        let fld = ReadIOIQualifier bs pos2 len
        fld |> FIXField.IOIQualifier
    | 105 ->
        let fld = ReadWaveNo bs pos2 len
        fld |> FIXField.WaveNo
    | 106 ->
        let fld = ReadIssuer bs pos2 len
        fld |> FIXField.Issuer
    | 107 ->
        let fld = ReadSecurityDesc bs pos2 len
        fld |> FIXField.SecurityDesc
    | 108 ->
        let fld = ReadHeartBtInt bs pos2 len
        fld |> FIXField.HeartBtInt
    | 110 ->
        let fld = ReadMinQty bs pos2 len
        fld |> FIXField.MinQty
    | 111 ->
        let fld = ReadMaxFloor bs pos2 len
        fld |> FIXField.MaxFloor
    | 112 ->
        let fld = ReadTestReqID bs pos2 len
        fld |> FIXField.TestReqID
    | 113 ->
        let fld = ReadReportToExch bs pos2 len
        fld |> FIXField.ReportToExch
    | 114 ->
        let fld = ReadLocateReqd bs pos2 len
        fld |> FIXField.LocateReqd
    | 115 ->
        let fld = ReadOnBehalfOfCompID bs pos2 len
        fld |> FIXField.OnBehalfOfCompID
    | 116 ->
        let fld = ReadOnBehalfOfSubID bs pos2 len
        fld |> FIXField.OnBehalfOfSubID
    | 117 ->
        let fld = ReadQuoteID bs pos2 len
        fld |> FIXField.QuoteID
    | 118 ->
        let fld = ReadNetMoney bs pos2 len
        fld |> FIXField.NetMoney
    | 119 ->
        let fld = ReadSettlCurrAmt bs pos2 len
        fld |> FIXField.SettlCurrAmt
    | 120 ->
        let fld = ReadSettlCurrency bs pos2 len
        fld |> FIXField.SettlCurrency
    | 121 ->
        let fld = ReadForexReq bs pos2 len
        fld |> FIXField.ForexReq
    | 122 ->
        let fld = ReadOrigSendingTime bs pos2 len
        fld |> FIXField.OrigSendingTime
    | 123 ->
        let fld = ReadGapFillFlag bs pos2 len
        fld |> FIXField.GapFillFlag
    | 124 ->
        let fld = ReadNoExecs bs pos2 len
        fld |> FIXField.NoExecs
    | 126 ->
        let fld = ReadExpireTime bs pos2 len
        fld |> FIXField.ExpireTime
    | 127 ->
        let fld = ReadDKReason bs pos2 len
        fld |> FIXField.DKReason
    | 128 ->
        let fld = ReadDeliverToCompID bs pos2 len
        fld |> FIXField.DeliverToCompID
    | 129 ->
        let fld = ReadDeliverToSubID bs pos2 len
        fld |> FIXField.DeliverToSubID
    | 130 ->
        let fld = ReadIOINaturalFlag bs pos2 len
        fld |> FIXField.IOINaturalFlag
    | 131 ->
        let fld = ReadQuoteReqID bs pos2 len
        fld |> FIXField.QuoteReqID
    | 132 ->
        let fld = ReadBidPx bs pos2 len
        fld |> FIXField.BidPx
    | 133 ->
        let fld = ReadOfferPx bs pos2 len
        fld |> FIXField.OfferPx
    | 134 ->
        let fld = ReadBidSize bs pos2 len
        fld |> FIXField.BidSize
    | 135 ->
        let fld = ReadOfferSize bs pos2 len
        fld |> FIXField.OfferSize
    | 136 ->
        let fld = ReadNoMiscFees bs pos2 len
        fld |> FIXField.NoMiscFees
    | 137 ->
        let fld = ReadMiscFeeAmt bs pos2 len
        fld |> FIXField.MiscFeeAmt
    | 138 ->
        let fld = ReadMiscFeeCurr bs pos2 len
        fld |> FIXField.MiscFeeCurr
    | 139 ->
        let fld = ReadMiscFeeType bs pos2 len
        fld |> FIXField.MiscFeeType
    | 140 ->
        let fld = ReadPrevClosePx bs pos2 len
        fld |> FIXField.PrevClosePx
    | 141 ->
        let fld = ReadResetSeqNumFlag bs pos2 len
        fld |> FIXField.ResetSeqNumFlag
    | 142 ->
        let fld = ReadSenderLocationID bs pos2 len
        fld |> FIXField.SenderLocationID
    | 143 ->
        let fld = ReadTargetLocationID bs pos2 len
        fld |> FIXField.TargetLocationID
    | 144 ->
        let fld = ReadOnBehalfOfLocationID bs pos2 len
        fld |> FIXField.OnBehalfOfLocationID
    | 145 ->
        let fld = ReadDeliverToLocationID bs pos2 len
        fld |> FIXField.DeliverToLocationID
    | 146 ->
        let fld = ReadNoRelatedSym bs pos2 len
        fld |> FIXField.NoRelatedSym
    | 147 ->
        let fld = ReadSubject bs pos2 len
        fld |> FIXField.Subject
    | 148 ->
        let fld = ReadHeadline bs pos2 len
        fld |> FIXField.Headline
    | 149 ->
        let fld = ReadURLLink bs pos2 len
        fld |> FIXField.URLLink
    | 150 ->
        let fld = ReadExecType bs pos2 len
        fld |> FIXField.ExecType
    | 151 ->
        let fld = ReadLeavesQty bs pos2 len
        fld |> FIXField.LeavesQty
    | 152 ->
        let fld = ReadCashOrderQty bs pos2 len
        fld |> FIXField.CashOrderQty
    | 153 ->
        let fld = ReadAllocAvgPx bs pos2 len
        fld |> FIXField.AllocAvgPx
    | 154 ->
        let fld = ReadAllocNetMoney bs pos2 len
        fld |> FIXField.AllocNetMoney
    | 155 ->
        let fld = ReadSettlCurrFxRate bs pos2 len
        fld |> FIXField.SettlCurrFxRate
    | 156 ->
        let fld = ReadSettlCurrFxRateCalc bs pos2 len
        fld |> FIXField.SettlCurrFxRateCalc
    | 157 ->
        let fld = ReadNumDaysInterest bs pos2 len
        fld |> FIXField.NumDaysInterest
    | 158 ->
        let fld = ReadAccruedInterestRate bs pos2 len
        fld |> FIXField.AccruedInterestRate
    | 159 ->
        let fld = ReadAccruedInterestAmt bs pos2 len
        fld |> FIXField.AccruedInterestAmt
    | 160 ->
        let fld = ReadSettlInstMode bs pos2 len
        fld |> FIXField.SettlInstMode
    | 161 ->
        let fld = ReadAllocText bs pos2 len
        fld |> FIXField.AllocText
    | 162 ->
        let fld = ReadSettlInstID bs pos2 len
        fld |> FIXField.SettlInstID
    | 163 ->
        let fld = ReadSettlInstTransType bs pos2 len
        fld |> FIXField.SettlInstTransType
    | 164 ->
        let fld = ReadEmailThreadID bs pos2 len
        fld |> FIXField.EmailThreadID
    | 165 ->
        let fld = ReadSettlInstSource bs pos2 len
        fld |> FIXField.SettlInstSource
    | 167 ->
        let fld = ReadSecurityType bs pos2 len
        fld |> FIXField.SecurityType
    | 168 ->
        let fld = ReadEffectiveTime bs pos2 len
        fld |> FIXField.EffectiveTime
    | 169 ->
        let fld = ReadStandInstDbType bs pos2 len
        fld |> FIXField.StandInstDbType
    | 170 ->
        let fld = ReadStandInstDbName bs pos2 len
        fld |> FIXField.StandInstDbName
    | 171 ->
        let fld = ReadStandInstDbID bs pos2 len
        fld |> FIXField.StandInstDbID
    | 172 ->
        let fld = ReadSettlDeliveryType bs pos2 len
        fld |> FIXField.SettlDeliveryType
    | 188 ->
        let fld = ReadBidSpotRate bs pos2 len
        fld |> FIXField.BidSpotRate
    | 189 ->
        let fld = ReadBidForwardPoints bs pos2 len
        fld |> FIXField.BidForwardPoints
    | 190 ->
        let fld = ReadOfferSpotRate bs pos2 len
        fld |> FIXField.OfferSpotRate
    | 191 ->
        let fld = ReadOfferForwardPoints bs pos2 len
        fld |> FIXField.OfferForwardPoints
    | 192 ->
        let fld = ReadOrderQty2 bs pos2 len
        fld |> FIXField.OrderQty2
    | 193 ->
        let fld = ReadSettlDate2 bs pos2 len
        fld |> FIXField.SettlDate2
    | 194 ->
        let fld = ReadLastSpotRate bs pos2 len
        fld |> FIXField.LastSpotRate
    | 195 ->
        let fld = ReadLastForwardPoints bs pos2 len
        fld |> FIXField.LastForwardPoints
    | 196 ->
        let fld = ReadAllocLinkID bs pos2 len
        fld |> FIXField.AllocLinkID
    | 197 ->
        let fld = ReadAllocLinkType bs pos2 len
        fld |> FIXField.AllocLinkType
    | 198 ->
        let fld = ReadSecondaryOrderID bs pos2 len
        fld |> FIXField.SecondaryOrderID
    | 199 ->
        let fld = ReadNoIOIQualifiers bs pos2 len
        fld |> FIXField.NoIOIQualifiers
    | 200 ->
        let fld = ReadMaturityMonthYear bs pos2 len
        fld |> FIXField.MaturityMonthYear
    | 201 ->
        let fld = ReadPutOrCall bs pos2 len
        fld |> FIXField.PutOrCall
    | 202 ->
        let fld = ReadStrikePrice bs pos2 len
        fld |> FIXField.StrikePrice
    | 203 ->
        let fld = ReadCoveredOrUncovered bs pos2 len
        fld |> FIXField.CoveredOrUncovered
    | 206 ->
        let fld = ReadOptAttribute bs pos2 len
        fld |> FIXField.OptAttribute
    | 207 ->
        let fld = ReadSecurityExchange bs pos2 len
        fld |> FIXField.SecurityExchange
    | 208 ->
        let fld = ReadNotifyBrokerOfCredit bs pos2 len
        fld |> FIXField.NotifyBrokerOfCredit
    | 209 ->
        let fld = ReadAllocHandlInst bs pos2 len
        fld |> FIXField.AllocHandlInst
    | 210 ->
        let fld = ReadMaxShow bs pos2 len
        fld |> FIXField.MaxShow
    | 211 ->
        let fld = ReadPegOffsetValue bs pos2 len
        fld |> FIXField.PegOffsetValue
    | 212 ->
        let fld = ReadXmlData bs pos2 len
        fld |> FIXField.XmlData // len->string compound field
    | 214 ->
        let fld = ReadSettlInstRefID bs pos2 len
        fld |> FIXField.SettlInstRefID
    | 215 ->
        let fld = ReadNoRoutingIDs bs pos2 len
        fld |> FIXField.NoRoutingIDs
    | 216 ->
        let fld = ReadRoutingType bs pos2 len
        fld |> FIXField.RoutingType
    | 217 ->
        let fld = ReadRoutingID bs pos2 len
        fld |> FIXField.RoutingID
    | 218 ->
        let fld = ReadSpread bs pos2 len
        fld |> FIXField.Spread
    | 220 ->
        let fld = ReadBenchmarkCurveCurrency bs pos2 len
        fld |> FIXField.BenchmarkCurveCurrency
    | 221 ->
        let fld = ReadBenchmarkCurveName bs pos2 len
        fld |> FIXField.BenchmarkCurveName
    | 222 ->
        let fld = ReadBenchmarkCurvePoint bs pos2 len
        fld |> FIXField.BenchmarkCurvePoint
    | 223 ->
        let fld = ReadCouponRate bs pos2 len
        fld |> FIXField.CouponRate
    | 224 ->
        let fld = ReadCouponPaymentDate bs pos2 len
        fld |> FIXField.CouponPaymentDate
    | 225 ->
        let fld = ReadIssueDate bs pos2 len
        fld |> FIXField.IssueDate
    | 226 ->
        let fld = ReadRepurchaseTerm bs pos2 len
        fld |> FIXField.RepurchaseTerm
    | 227 ->
        let fld = ReadRepurchaseRate bs pos2 len
        fld |> FIXField.RepurchaseRate
    | 228 ->
        let fld = ReadFactor bs pos2 len
        fld |> FIXField.Factor
    | 229 ->
        let fld = ReadTradeOriginationDate bs pos2 len
        fld |> FIXField.TradeOriginationDate
    | 230 ->
        let fld = ReadExDate bs pos2 len
        fld |> FIXField.ExDate
    | 231 ->
        let fld = ReadContractMultiplier bs pos2 len
        fld |> FIXField.ContractMultiplier
    | 232 ->
        let fld = ReadNoStipulations bs pos2 len
        fld |> FIXField.NoStipulations
    | 233 ->
        let fld = ReadStipulationType bs pos2 len
        fld |> FIXField.StipulationType
    | 234 ->
        let fld = ReadStipulationValue bs pos2 len
        fld |> FIXField.StipulationValue
    | 235 ->
        let fld = ReadYieldType bs pos2 len
        fld |> FIXField.YieldType
    | 236 ->
        let fld = ReadYield bs pos2 len
        fld |> FIXField.Yield
    | 237 ->
        let fld = ReadTotalTakedown bs pos2 len
        fld |> FIXField.TotalTakedown
    | 238 ->
        let fld = ReadConcession bs pos2 len
        fld |> FIXField.Concession
    | 239 ->
        let fld = ReadRepoCollateralSecurityType bs pos2 len
        fld |> FIXField.RepoCollateralSecurityType
    | 240 ->
        let fld = ReadRedemptionDate bs pos2 len
        fld |> FIXField.RedemptionDate
    | 241 ->
        let fld = ReadUnderlyingCouponPaymentDate bs pos2 len
        fld |> FIXField.UnderlyingCouponPaymentDate
    | 242 ->
        let fld = ReadUnderlyingIssueDate bs pos2 len
        fld |> FIXField.UnderlyingIssueDate
    | 243 ->
        let fld = ReadUnderlyingRepoCollateralSecurityType bs pos2 len
        fld |> FIXField.UnderlyingRepoCollateralSecurityType
    | 244 ->
        let fld = ReadUnderlyingRepurchaseTerm bs pos2 len
        fld |> FIXField.UnderlyingRepurchaseTerm
    | 245 ->
        let fld = ReadUnderlyingRepurchaseRate bs pos2 len
        fld |> FIXField.UnderlyingRepurchaseRate
    | 246 ->
        let fld = ReadUnderlyingFactor bs pos2 len
        fld |> FIXField.UnderlyingFactor
    | 247 ->
        let fld = ReadUnderlyingRedemptionDate bs pos2 len
        fld |> FIXField.UnderlyingRedemptionDate
    | 248 ->
        let fld = ReadLegCouponPaymentDate bs pos2 len
        fld |> FIXField.LegCouponPaymentDate
    | 249 ->
        let fld = ReadLegIssueDate bs pos2 len
        fld |> FIXField.LegIssueDate
    | 250 ->
        let fld = ReadLegRepoCollateralSecurityType bs pos2 len
        fld |> FIXField.LegRepoCollateralSecurityType
    | 251 ->
        let fld = ReadLegRepurchaseTerm bs pos2 len
        fld |> FIXField.LegRepurchaseTerm
    | 252 ->
        let fld = ReadLegRepurchaseRate bs pos2 len
        fld |> FIXField.LegRepurchaseRate
    | 253 ->
        let fld = ReadLegFactor bs pos2 len
        fld |> FIXField.LegFactor
    | 254 ->
        let fld = ReadLegRedemptionDate bs pos2 len
        fld |> FIXField.LegRedemptionDate
    | 255 ->
        let fld = ReadCreditRating bs pos2 len
        fld |> FIXField.CreditRating
    | 256 ->
        let fld = ReadUnderlyingCreditRating bs pos2 len
        fld |> FIXField.UnderlyingCreditRating
    | 257 ->
        let fld = ReadLegCreditRating bs pos2 len
        fld |> FIXField.LegCreditRating
    | 258 ->
        let fld = ReadTradedFlatSwitch bs pos2 len
        fld |> FIXField.TradedFlatSwitch
    | 259 ->
        let fld = ReadBasisFeatureDate bs pos2 len
        fld |> FIXField.BasisFeatureDate
    | 260 ->
        let fld = ReadBasisFeaturePrice bs pos2 len
        fld |> FIXField.BasisFeaturePrice
    | 262 ->
        let fld = ReadMDReqID bs pos2 len
        fld |> FIXField.MDReqID
    | 263 ->
        let fld = ReadSubscriptionRequestType bs pos2 len
        fld |> FIXField.SubscriptionRequestType
    | 264 ->
        let fld = ReadMarketDepth bs pos2 len
        fld |> FIXField.MarketDepth
    | 265 ->
        let fld = ReadMDUpdateType bs pos2 len
        fld |> FIXField.MDUpdateType
    | 266 ->
        let fld = ReadAggregatedBook bs pos2 len
        fld |> FIXField.AggregatedBook
    | 267 ->
        let fld = ReadNoMDEntryTypes bs pos2 len
        fld |> FIXField.NoMDEntryTypes
    | 268 ->
        let fld = ReadNoMDEntries bs pos2 len
        fld |> FIXField.NoMDEntries
    | 269 ->
        let fld = ReadMDEntryType bs pos2 len
        fld |> FIXField.MDEntryType
    | 270 ->
        let fld = ReadMDEntryPx bs pos2 len
        fld |> FIXField.MDEntryPx
    | 271 ->
        let fld = ReadMDEntrySize bs pos2 len
        fld |> FIXField.MDEntrySize
    | 272 ->
        let fld = ReadMDEntryDate bs pos2 len
        fld |> FIXField.MDEntryDate
    | 273 ->
        let fld = ReadMDEntryTime bs pos2 len
        fld |> FIXField.MDEntryTime
    | 274 ->
        let fld = ReadTickDirection bs pos2 len
        fld |> FIXField.TickDirection
    | 275 ->
        let fld = ReadMDMkt bs pos2 len
        fld |> FIXField.MDMkt
    | 276 ->
        let fld = ReadQuoteCondition bs pos2 len
        fld |> FIXField.QuoteCondition
    | 277 ->
        let fld = ReadTradeCondition bs pos2 len
        fld |> FIXField.TradeCondition
    | 278 ->
        let fld = ReadMDEntryID bs pos2 len
        fld |> FIXField.MDEntryID
    | 279 ->
        let fld = ReadMDUpdateAction bs pos2 len
        fld |> FIXField.MDUpdateAction
    | 280 ->
        let fld = ReadMDEntryRefID bs pos2 len
        fld |> FIXField.MDEntryRefID
    | 281 ->
        let fld = ReadMDReqRejReason bs pos2 len
        fld |> FIXField.MDReqRejReason
    | 282 ->
        let fld = ReadMDEntryOriginator bs pos2 len
        fld |> FIXField.MDEntryOriginator
    | 283 ->
        let fld = ReadLocationID bs pos2 len
        fld |> FIXField.LocationID
    | 284 ->
        let fld = ReadDeskID bs pos2 len
        fld |> FIXField.DeskID
    | 285 ->
        let fld = ReadDeleteReason bs pos2 len
        fld |> FIXField.DeleteReason
    | 286 ->
        let fld = ReadOpenCloseSettlFlag bs pos2 len
        fld |> FIXField.OpenCloseSettlFlag
    | 287 ->
        let fld = ReadSellerDays bs pos2 len
        fld |> FIXField.SellerDays
    | 288 ->
        let fld = ReadMDEntryBuyer bs pos2 len
        fld |> FIXField.MDEntryBuyer
    | 289 ->
        let fld = ReadMDEntrySeller bs pos2 len
        fld |> FIXField.MDEntrySeller
    | 290 ->
        let fld = ReadMDEntryPositionNo bs pos2 len
        fld |> FIXField.MDEntryPositionNo
    | 291 ->
        let fld = ReadFinancialStatus bs pos2 len
        fld |> FIXField.FinancialStatus
    | 292 ->
        let fld = ReadCorporateAction bs pos2 len
        fld |> FIXField.CorporateAction
    | 293 ->
        let fld = ReadDefBidSize bs pos2 len
        fld |> FIXField.DefBidSize
    | 294 ->
        let fld = ReadDefOfferSize bs pos2 len
        fld |> FIXField.DefOfferSize
    | 295 ->
        let fld = ReadNoQuoteEntries bs pos2 len
        fld |> FIXField.NoQuoteEntries
    | 296 ->
        let fld = ReadNoQuoteSets bs pos2 len
        fld |> FIXField.NoQuoteSets
    | 297 ->
        let fld = ReadQuoteStatus bs pos2 len
        fld |> FIXField.QuoteStatus
    | 298 ->
        let fld = ReadQuoteCancelType bs pos2 len
        fld |> FIXField.QuoteCancelType
    | 299 ->
        let fld = ReadQuoteEntryID bs pos2 len
        fld |> FIXField.QuoteEntryID
    | 300 ->
        let fld = ReadQuoteRejectReason bs pos2 len
        fld |> FIXField.QuoteRejectReason
    | 301 ->
        let fld = ReadQuoteResponseLevel bs pos2 len
        fld |> FIXField.QuoteResponseLevel
    | 302 ->
        let fld = ReadQuoteSetID bs pos2 len
        fld |> FIXField.QuoteSetID
    | 303 ->
        let fld = ReadQuoteRequestType bs pos2 len
        fld |> FIXField.QuoteRequestType
    | 304 ->
        let fld = ReadTotNoQuoteEntries bs pos2 len
        fld |> FIXField.TotNoQuoteEntries
    | 305 ->
        let fld = ReadUnderlyingSecurityIDSource bs pos2 len
        fld |> FIXField.UnderlyingSecurityIDSource
    | 306 ->
        let fld = ReadUnderlyingIssuer bs pos2 len
        fld |> FIXField.UnderlyingIssuer
    | 307 ->
        let fld = ReadUnderlyingSecurityDesc bs pos2 len
        fld |> FIXField.UnderlyingSecurityDesc
    | 308 ->
        let fld = ReadUnderlyingSecurityExchange bs pos2 len
        fld |> FIXField.UnderlyingSecurityExchange
    | 309 ->
        let fld = ReadUnderlyingSecurityID bs pos2 len
        fld |> FIXField.UnderlyingSecurityID
    | 310 ->
        let fld = ReadUnderlyingSecurityType bs pos2 len
        fld |> FIXField.UnderlyingSecurityType
    | 311 ->
        let fld = ReadUnderlyingSymbol bs pos2 len
        fld |> FIXField.UnderlyingSymbol
    | 312 ->
        let fld = ReadUnderlyingSymbolSfx bs pos2 len
        fld |> FIXField.UnderlyingSymbolSfx
    | 313 ->
        let fld = ReadUnderlyingMaturityMonthYear bs pos2 len
        fld |> FIXField.UnderlyingMaturityMonthYear
    | 315 ->
        let fld = ReadUnderlyingPutOrCall bs pos2 len
        fld |> FIXField.UnderlyingPutOrCall
    | 316 ->
        let fld = ReadUnderlyingStrikePrice bs pos2 len
        fld |> FIXField.UnderlyingStrikePrice
    | 317 ->
        let fld = ReadUnderlyingOptAttribute bs pos2 len
        fld |> FIXField.UnderlyingOptAttribute
    | 318 ->
        let fld = ReadUnderlyingCurrency bs pos2 len
        fld |> FIXField.UnderlyingCurrency
    | 320 ->
        let fld = ReadSecurityReqID bs pos2 len
        fld |> FIXField.SecurityReqID
    | 321 ->
        let fld = ReadSecurityRequestType bs pos2 len
        fld |> FIXField.SecurityRequestType
    | 322 ->
        let fld = ReadSecurityResponseID bs pos2 len
        fld |> FIXField.SecurityResponseID
    | 323 ->
        let fld = ReadSecurityResponseType bs pos2 len
        fld |> FIXField.SecurityResponseType
    | 324 ->
        let fld = ReadSecurityStatusReqID bs pos2 len
        fld |> FIXField.SecurityStatusReqID
    | 325 ->
        let fld = ReadUnsolicitedIndicator bs pos2 len
        fld |> FIXField.UnsolicitedIndicator
    | 326 ->
        let fld = ReadSecurityTradingStatus bs pos2 len
        fld |> FIXField.SecurityTradingStatus
    | 327 ->
        let fld = ReadHaltReason bs pos2 len
        fld |> FIXField.HaltReason
    | 328 ->
        let fld = ReadInViewOfCommon bs pos2 len
        fld |> FIXField.InViewOfCommon
    | 329 ->
        let fld = ReadDueToRelated bs pos2 len
        fld |> FIXField.DueToRelated
    | 330 ->
        let fld = ReadBuyVolume bs pos2 len
        fld |> FIXField.BuyVolume
    | 331 ->
        let fld = ReadSellVolume bs pos2 len
        fld |> FIXField.SellVolume
    | 332 ->
        let fld = ReadHighPx bs pos2 len
        fld |> FIXField.HighPx
    | 333 ->
        let fld = ReadLowPx bs pos2 len
        fld |> FIXField.LowPx
    | 334 ->
        let fld = ReadAdjustment bs pos2 len
        fld |> FIXField.Adjustment
    | 335 ->
        let fld = ReadTradSesReqID bs pos2 len
        fld |> FIXField.TradSesReqID
    | 336 ->
        let fld = ReadTradingSessionID bs pos2 len
        fld |> FIXField.TradingSessionID
    | 337 ->
        let fld = ReadContraTrader bs pos2 len
        fld |> FIXField.ContraTrader
    | 338 ->
        let fld = ReadTradSesMethod bs pos2 len
        fld |> FIXField.TradSesMethod
    | 339 ->
        let fld = ReadTradSesMode bs pos2 len
        fld |> FIXField.TradSesMode
    | 340 ->
        let fld = ReadTradSesStatus bs pos2 len
        fld |> FIXField.TradSesStatus
    | 341 ->
        let fld = ReadTradSesStartTime bs pos2 len
        fld |> FIXField.TradSesStartTime
    | 342 ->
        let fld = ReadTradSesOpenTime bs pos2 len
        fld |> FIXField.TradSesOpenTime
    | 343 ->
        let fld = ReadTradSesPreCloseTime bs pos2 len
        fld |> FIXField.TradSesPreCloseTime
    | 344 ->
        let fld = ReadTradSesCloseTime bs pos2 len
        fld |> FIXField.TradSesCloseTime
    | 345 ->
        let fld = ReadTradSesEndTime bs pos2 len
        fld |> FIXField.TradSesEndTime
    | 346 ->
        let fld = ReadNumberOfOrders bs pos2 len
        fld |> FIXField.NumberOfOrders
    | 347 ->
        let fld = ReadMessageEncoding bs pos2 len
        fld |> FIXField.MessageEncoding
    | 348 ->
        let fld = ReadEncodedIssuer bs pos2 len
        fld |> FIXField.EncodedIssuer // len->string compound field
    | 350 ->
        let fld = ReadEncodedSecurityDesc bs pos2 len
        fld |> FIXField.EncodedSecurityDesc // len->string compound field
    | 352 ->
        let fld = ReadEncodedListExecInst bs pos2 len
        fld |> FIXField.EncodedListExecInst // len->string compound field
    | 354 ->
        let fld = ReadEncodedText bs pos2 len
        fld |> FIXField.EncodedText // len->string compound field
    | 356 ->
        let fld = ReadEncodedSubject bs pos2 len
        fld |> FIXField.EncodedSubject // len->string compound field
    | 358 ->
        let fld = ReadEncodedHeadline bs pos2 len
        fld |> FIXField.EncodedHeadline // len->string compound field
    | 360 ->
        let fld = ReadEncodedAllocText bs pos2 len
        fld |> FIXField.EncodedAllocText // len->string compound field
    | 362 ->
        let fld = ReadEncodedUnderlyingIssuer bs pos2 len
        fld |> FIXField.EncodedUnderlyingIssuer // len->string compound field
    | 364 ->
        let fld = ReadEncodedUnderlyingSecurityDesc bs pos2 len
        fld |> FIXField.EncodedUnderlyingSecurityDesc // len->string compound field
    | 366 ->
        let fld = ReadAllocPrice bs pos2 len
        fld |> FIXField.AllocPrice
    | 367 ->
        let fld = ReadQuoteSetValidUntilTime bs pos2 len
        fld |> FIXField.QuoteSetValidUntilTime
    | 368 ->
        let fld = ReadQuoteEntryRejectReason bs pos2 len
        fld |> FIXField.QuoteEntryRejectReason
    | 369 ->
        let fld = ReadLastMsgSeqNumProcessed bs pos2 len
        fld |> FIXField.LastMsgSeqNumProcessed
    | 371 ->
        let fld = ReadRefTagID bs pos2 len
        fld |> FIXField.RefTagID
    | 372 ->
        let fld = ReadRefMsgType bs pos2 len
        fld |> FIXField.RefMsgType
    | 373 ->
        let fld = ReadSessionRejectReason bs pos2 len
        fld |> FIXField.SessionRejectReason
    | 374 ->
        let fld = ReadBidRequestTransType bs pos2 len
        fld |> FIXField.BidRequestTransType
    | 375 ->
        let fld = ReadContraBroker bs pos2 len
        fld |> FIXField.ContraBroker
    | 376 ->
        let fld = ReadComplianceID bs pos2 len
        fld |> FIXField.ComplianceID
    | 377 ->
        let fld = ReadSolicitedFlag bs pos2 len
        fld |> FIXField.SolicitedFlag
    | 378 ->
        let fld = ReadExecRestatementReason bs pos2 len
        fld |> FIXField.ExecRestatementReason
    | 379 ->
        let fld = ReadBusinessRejectRefID bs pos2 len
        fld |> FIXField.BusinessRejectRefID
    | 380 ->
        let fld = ReadBusinessRejectReason bs pos2 len
        fld |> FIXField.BusinessRejectReason
    | 381 ->
        let fld = ReadGrossTradeAmt bs pos2 len
        fld |> FIXField.GrossTradeAmt
    | 382 ->
        let fld = ReadNoContraBrokers bs pos2 len
        fld |> FIXField.NoContraBrokers
    | 383 ->
        let fld = ReadMaxMessageSize bs pos2 len
        fld |> FIXField.MaxMessageSize
    | 384 ->
        let fld = ReadNoMsgTypes bs pos2 len
        fld |> FIXField.NoMsgTypes
    | 385 ->
        let fld = ReadMsgDirection bs pos2 len
        fld |> FIXField.MsgDirection
    | 386 ->
        let fld = ReadNoTradingSessions bs pos2 len
        fld |> FIXField.NoTradingSessions
    | 387 ->
        let fld = ReadTotalVolumeTraded bs pos2 len
        fld |> FIXField.TotalVolumeTraded
    | 388 ->
        let fld = ReadDiscretionInst bs pos2 len
        fld |> FIXField.DiscretionInst
    | 389 ->
        let fld = ReadDiscretionOffsetValue bs pos2 len
        fld |> FIXField.DiscretionOffsetValue
    | 390 ->
        let fld = ReadBidID bs pos2 len
        fld |> FIXField.BidID
    | 391 ->
        let fld = ReadClientBidID bs pos2 len
        fld |> FIXField.ClientBidID
    | 392 ->
        let fld = ReadListName bs pos2 len
        fld |> FIXField.ListName
    | 393 ->
        let fld = ReadTotNoRelatedSym bs pos2 len
        fld |> FIXField.TotNoRelatedSym
    | 394 ->
        let fld = ReadBidType bs pos2 len
        fld |> FIXField.BidType
    | 395 ->
        let fld = ReadNumTickets bs pos2 len
        fld |> FIXField.NumTickets
    | 396 ->
        let fld = ReadSideValue1 bs pos2 len
        fld |> FIXField.SideValue1
    | 397 ->
        let fld = ReadSideValue2 bs pos2 len
        fld |> FIXField.SideValue2
    | 398 ->
        let fld = ReadNoBidDescriptors bs pos2 len
        fld |> FIXField.NoBidDescriptors
    | 399 ->
        let fld = ReadBidDescriptorType bs pos2 len
        fld |> FIXField.BidDescriptorType
    | 400 ->
        let fld = ReadBidDescriptor bs pos2 len
        fld |> FIXField.BidDescriptor
    | 401 ->
        let fld = ReadSideValueInd bs pos2 len
        fld |> FIXField.SideValueInd
    | 402 ->
        let fld = ReadLiquidityPctLow bs pos2 len
        fld |> FIXField.LiquidityPctLow
    | 403 ->
        let fld = ReadLiquidityPctHigh bs pos2 len
        fld |> FIXField.LiquidityPctHigh
    | 404 ->
        let fld = ReadLiquidityValue bs pos2 len
        fld |> FIXField.LiquidityValue
    | 405 ->
        let fld = ReadEFPTrackingError bs pos2 len
        fld |> FIXField.EFPTrackingError
    | 406 ->
        let fld = ReadFairValue bs pos2 len
        fld |> FIXField.FairValue
    | 407 ->
        let fld = ReadOutsideIndexPct bs pos2 len
        fld |> FIXField.OutsideIndexPct
    | 408 ->
        let fld = ReadValueOfFutures bs pos2 len
        fld |> FIXField.ValueOfFutures
    | 409 ->
        let fld = ReadLiquidityIndType bs pos2 len
        fld |> FIXField.LiquidityIndType
    | 410 ->
        let fld = ReadWtAverageLiquidity bs pos2 len
        fld |> FIXField.WtAverageLiquidity
    | 411 ->
        let fld = ReadExchangeForPhysical bs pos2 len
        fld |> FIXField.ExchangeForPhysical
    | 412 ->
        let fld = ReadOutMainCntryUIndex bs pos2 len
        fld |> FIXField.OutMainCntryUIndex
    | 413 ->
        let fld = ReadCrossPercent bs pos2 len
        fld |> FIXField.CrossPercent
    | 414 ->
        let fld = ReadProgRptReqs bs pos2 len
        fld |> FIXField.ProgRptReqs
    | 415 ->
        let fld = ReadProgPeriodInterval bs pos2 len
        fld |> FIXField.ProgPeriodInterval
    | 416 ->
        let fld = ReadIncTaxInd bs pos2 len
        fld |> FIXField.IncTaxInd
    | 417 ->
        let fld = ReadNumBidders bs pos2 len
        fld |> FIXField.NumBidders
    | 418 ->
        let fld = ReadBidTradeType bs pos2 len
        fld |> FIXField.BidTradeType
    | 419 ->
        let fld = ReadBasisPxType bs pos2 len
        fld |> FIXField.BasisPxType
    | 420 ->
        let fld = ReadNoBidComponents bs pos2 len
        fld |> FIXField.NoBidComponents
    | 421 ->
        let fld = ReadCountry bs pos2 len
        fld |> FIXField.Country
    | 422 ->
        let fld = ReadTotNoStrikes bs pos2 len
        fld |> FIXField.TotNoStrikes
    | 423 ->
        let fld = ReadPriceType bs pos2 len
        fld |> FIXField.PriceType
    | 424 ->
        let fld = ReadDayOrderQty bs pos2 len
        fld |> FIXField.DayOrderQty
    | 425 ->
        let fld = ReadDayCumQty bs pos2 len
        fld |> FIXField.DayCumQty
    | 426 ->
        let fld = ReadDayAvgPx bs pos2 len
        fld |> FIXField.DayAvgPx
    | 427 ->
        let fld = ReadGTBookingInst bs pos2 len
        fld |> FIXField.GTBookingInst
    | 428 ->
        let fld = ReadNoStrikes bs pos2 len
        fld |> FIXField.NoStrikes
    | 429 ->
        let fld = ReadListStatusType bs pos2 len
        fld |> FIXField.ListStatusType
    | 430 ->
        let fld = ReadNetGrossInd bs pos2 len
        fld |> FIXField.NetGrossInd
    | 431 ->
        let fld = ReadListOrderStatus bs pos2 len
        fld |> FIXField.ListOrderStatus
    | 432 ->
        let fld = ReadExpireDate bs pos2 len
        fld |> FIXField.ExpireDate
    | 433 ->
        let fld = ReadListExecInstType bs pos2 len
        fld |> FIXField.ListExecInstType
    | 434 ->
        let fld = ReadCxlRejResponseTo bs pos2 len
        fld |> FIXField.CxlRejResponseTo
    | 435 ->
        let fld = ReadUnderlyingCouponRate bs pos2 len
        fld |> FIXField.UnderlyingCouponRate
    | 436 ->
        let fld = ReadUnderlyingContractMultiplier bs pos2 len
        fld |> FIXField.UnderlyingContractMultiplier
    | 437 ->
        let fld = ReadContraTradeQty bs pos2 len
        fld |> FIXField.ContraTradeQty
    | 438 ->
        let fld = ReadContraTradeTime bs pos2 len
        fld |> FIXField.ContraTradeTime
    | 441 ->
        let fld = ReadLiquidityNumSecurities bs pos2 len
        fld |> FIXField.LiquidityNumSecurities
    | 442 ->
        let fld = ReadMultiLegReportingType bs pos2 len
        fld |> FIXField.MultiLegReportingType
    | 443 ->
        let fld = ReadStrikeTime bs pos2 len
        fld |> FIXField.StrikeTime
    | 444 ->
        let fld = ReadListStatusText bs pos2 len
        fld |> FIXField.ListStatusText
    | 445 ->
        let fld = ReadEncodedListStatusText bs pos2 len
        fld |> FIXField.EncodedListStatusText // len->string compound field
    | 447 ->
        let fld = ReadPartyIDSource bs pos2 len
        fld |> FIXField.PartyIDSource
    | 448 ->
        let fld = ReadPartyID bs pos2 len
        fld |> FIXField.PartyID
    | 451 ->
        let fld = ReadNetChgPrevDay bs pos2 len
        fld |> FIXField.NetChgPrevDay
    | 452 ->
        let fld = ReadPartyRole bs pos2 len
        fld |> FIXField.PartyRole
    | 453 ->
        let fld = ReadNoPartyIDs bs pos2 len
        fld |> FIXField.NoPartyIDs
    | 454 ->
        let fld = ReadNoSecurityAltID bs pos2 len
        fld |> FIXField.NoSecurityAltID
    | 455 ->
        let fld = ReadSecurityAltID bs pos2 len
        fld |> FIXField.SecurityAltID
    | 456 ->
        let fld = ReadSecurityAltIDSource bs pos2 len
        fld |> FIXField.SecurityAltIDSource
    | 457 ->
        let fld = ReadNoUnderlyingSecurityAltID bs pos2 len
        fld |> FIXField.NoUnderlyingSecurityAltID
    | 458 ->
        let fld = ReadUnderlyingSecurityAltID bs pos2 len
        fld |> FIXField.UnderlyingSecurityAltID
    | 459 ->
        let fld = ReadUnderlyingSecurityAltIDSource bs pos2 len
        fld |> FIXField.UnderlyingSecurityAltIDSource
    | 460 ->
        let fld = ReadProduct bs pos2 len
        fld |> FIXField.Product
    | 461 ->
        let fld = ReadCFICode bs pos2 len
        fld |> FIXField.CFICode
    | 462 ->
        let fld = ReadUnderlyingProduct bs pos2 len
        fld |> FIXField.UnderlyingProduct
    | 463 ->
        let fld = ReadUnderlyingCFICode bs pos2 len
        fld |> FIXField.UnderlyingCFICode
    | 464 ->
        let fld = ReadTestMessageIndicator bs pos2 len
        fld |> FIXField.TestMessageIndicator
    | 465 ->
        let fld = ReadQuantityType bs pos2 len
        fld |> FIXField.QuantityType
    | 466 ->
        let fld = ReadBookingRefID bs pos2 len
        fld |> FIXField.BookingRefID
    | 467 ->
        let fld = ReadIndividualAllocID bs pos2 len
        fld |> FIXField.IndividualAllocID
    | 468 ->
        let fld = ReadRoundingDirection bs pos2 len
        fld |> FIXField.RoundingDirection
    | 469 ->
        let fld = ReadRoundingModulus bs pos2 len
        fld |> FIXField.RoundingModulus
    | 470 ->
        let fld = ReadCountryOfIssue bs pos2 len
        fld |> FIXField.CountryOfIssue
    | 471 ->
        let fld = ReadStateOrProvinceOfIssue bs pos2 len
        fld |> FIXField.StateOrProvinceOfIssue
    | 472 ->
        let fld = ReadLocaleOfIssue bs pos2 len
        fld |> FIXField.LocaleOfIssue
    | 473 ->
        let fld = ReadNoRegistDtls bs pos2 len
        fld |> FIXField.NoRegistDtls
    | 474 ->
        let fld = ReadMailingDtls bs pos2 len
        fld |> FIXField.MailingDtls
    | 475 ->
        let fld = ReadInvestorCountryOfResidence bs pos2 len
        fld |> FIXField.InvestorCountryOfResidence
    | 476 ->
        let fld = ReadPaymentRef bs pos2 len
        fld |> FIXField.PaymentRef
    | 477 ->
        let fld = ReadDistribPaymentMethod bs pos2 len
        fld |> FIXField.DistribPaymentMethod
    | 478 ->
        let fld = ReadCashDistribCurr bs pos2 len
        fld |> FIXField.CashDistribCurr
    | 479 ->
        let fld = ReadCommCurrency bs pos2 len
        fld |> FIXField.CommCurrency
    | 480 ->
        let fld = ReadCancellationRights bs pos2 len
        fld |> FIXField.CancellationRights
    | 481 ->
        let fld = ReadMoneyLaunderingStatus bs pos2 len
        fld |> FIXField.MoneyLaunderingStatus
    | 482 ->
        let fld = ReadMailingInst bs pos2 len
        fld |> FIXField.MailingInst
    | 483 ->
        let fld = ReadTransBkdTime bs pos2 len
        fld |> FIXField.TransBkdTime
    | 484 ->
        let fld = ReadExecPriceType bs pos2 len
        fld |> FIXField.ExecPriceType
    | 485 ->
        let fld = ReadExecPriceAdjustment bs pos2 len
        fld |> FIXField.ExecPriceAdjustment
    | 486 ->
        let fld = ReadDateOfBirth bs pos2 len
        fld |> FIXField.DateOfBirth
    | 487 ->
        let fld = ReadTradeReportTransType bs pos2 len
        fld |> FIXField.TradeReportTransType
    | 488 ->
        let fld = ReadCardHolderName bs pos2 len
        fld |> FIXField.CardHolderName
    | 489 ->
        let fld = ReadCardNumber bs pos2 len
        fld |> FIXField.CardNumber
    | 490 ->
        let fld = ReadCardExpDate bs pos2 len
        fld |> FIXField.CardExpDate
    | 491 ->
        let fld = ReadCardIssNum bs pos2 len
        fld |> FIXField.CardIssNum
    | 492 ->
        let fld = ReadPaymentMethod bs pos2 len
        fld |> FIXField.PaymentMethod
    | 493 ->
        let fld = ReadRegistAcctType bs pos2 len
        fld |> FIXField.RegistAcctType
    | 494 ->
        let fld = ReadDesignation bs pos2 len
        fld |> FIXField.Designation
    | 495 ->
        let fld = ReadTaxAdvantageType bs pos2 len
        fld |> FIXField.TaxAdvantageType
    | 496 ->
        let fld = ReadRegistRejReasonText bs pos2 len
        fld |> FIXField.RegistRejReasonText
    | 497 ->
        let fld = ReadFundRenewWaiv bs pos2 len
        fld |> FIXField.FundRenewWaiv
    | 498 ->
        let fld = ReadCashDistribAgentName bs pos2 len
        fld |> FIXField.CashDistribAgentName
    | 499 ->
        let fld = ReadCashDistribAgentCode bs pos2 len
        fld |> FIXField.CashDistribAgentCode
    | 500 ->
        let fld = ReadCashDistribAgentAcctNumber bs pos2 len
        fld |> FIXField.CashDistribAgentAcctNumber
    | 501 ->
        let fld = ReadCashDistribPayRef bs pos2 len
        fld |> FIXField.CashDistribPayRef
    | 502 ->
        let fld = ReadCashDistribAgentAcctName bs pos2 len
        fld |> FIXField.CashDistribAgentAcctName
    | 503 ->
        let fld = ReadCardStartDate bs pos2 len
        fld |> FIXField.CardStartDate
    | 504 ->
        let fld = ReadPaymentDate bs pos2 len
        fld |> FIXField.PaymentDate
    | 505 ->
        let fld = ReadPaymentRemitterID bs pos2 len
        fld |> FIXField.PaymentRemitterID
    | 506 ->
        let fld = ReadRegistStatus bs pos2 len
        fld |> FIXField.RegistStatus
    | 507 ->
        let fld = ReadRegistRejReasonCode bs pos2 len
        fld |> FIXField.RegistRejReasonCode
    | 508 ->
        let fld = ReadRegistRefID bs pos2 len
        fld |> FIXField.RegistRefID
    | 509 ->
        let fld = ReadRegistDtls bs pos2 len
        fld |> FIXField.RegistDtls
    | 510 ->
        let fld = ReadNoDistribInsts bs pos2 len
        fld |> FIXField.NoDistribInsts
    | 511 ->
        let fld = ReadRegistEmail bs pos2 len
        fld |> FIXField.RegistEmail
    | 512 ->
        let fld = ReadDistribPercentage bs pos2 len
        fld |> FIXField.DistribPercentage
    | 513 ->
        let fld = ReadRegistID bs pos2 len
        fld |> FIXField.RegistID
    | 514 ->
        let fld = ReadRegistTransType bs pos2 len
        fld |> FIXField.RegistTransType
    | 515 ->
        let fld = ReadExecValuationPoint bs pos2 len
        fld |> FIXField.ExecValuationPoint
    | 516 ->
        let fld = ReadOrderPercent bs pos2 len
        fld |> FIXField.OrderPercent
    | 517 ->
        let fld = ReadOwnershipType bs pos2 len
        fld |> FIXField.OwnershipType
    | 518 ->
        let fld = ReadNoContAmts bs pos2 len
        fld |> FIXField.NoContAmts
    | 519 ->
        let fld = ReadContAmtType bs pos2 len
        fld |> FIXField.ContAmtType
    | 520 ->
        let fld = ReadContAmtValue bs pos2 len
        fld |> FIXField.ContAmtValue
    | 521 ->
        let fld = ReadContAmtCurr bs pos2 len
        fld |> FIXField.ContAmtCurr
    | 522 ->
        let fld = ReadOwnerType bs pos2 len
        fld |> FIXField.OwnerType
    | 523 ->
        let fld = ReadPartySubID bs pos2 len
        fld |> FIXField.PartySubID
    | 524 ->
        let fld = ReadNestedPartyID bs pos2 len
        fld |> FIXField.NestedPartyID
    | 525 ->
        let fld = ReadNestedPartyIDSource bs pos2 len
        fld |> FIXField.NestedPartyIDSource
    | 526 ->
        let fld = ReadSecondaryClOrdID bs pos2 len
        fld |> FIXField.SecondaryClOrdID
    | 527 ->
        let fld = ReadSecondaryExecID bs pos2 len
        fld |> FIXField.SecondaryExecID
    | 528 ->
        let fld = ReadOrderCapacity bs pos2 len
        fld |> FIXField.OrderCapacity
    | 529 ->
        let fld = ReadOrderRestrictions bs pos2 len
        fld |> FIXField.OrderRestrictions
    | 530 ->
        let fld = ReadMassCancelRequestType bs pos2 len
        fld |> FIXField.MassCancelRequestType
    | 531 ->
        let fld = ReadMassCancelResponse bs pos2 len
        fld |> FIXField.MassCancelResponse
    | 532 ->
        let fld = ReadMassCancelRejectReason bs pos2 len
        fld |> FIXField.MassCancelRejectReason
    | 533 ->
        let fld = ReadTotalAffectedOrders bs pos2 len
        fld |> FIXField.TotalAffectedOrders
    | 534 ->
        let fld = ReadNoAffectedOrders bs pos2 len
        fld |> FIXField.NoAffectedOrders
    | 535 ->
        let fld = ReadAffectedOrderID bs pos2 len
        fld |> FIXField.AffectedOrderID
    | 536 ->
        let fld = ReadAffectedSecondaryOrderID bs pos2 len
        fld |> FIXField.AffectedSecondaryOrderID
    | 537 ->
        let fld = ReadQuoteType bs pos2 len
        fld |> FIXField.QuoteType
    | 538 ->
        let fld = ReadNestedPartyRole bs pos2 len
        fld |> FIXField.NestedPartyRole
    | 539 ->
        let fld = ReadNoNestedPartyIDs bs pos2 len
        fld |> FIXField.NoNestedPartyIDs
    | 540 ->
        let fld = ReadTotalAccruedInterestAmt bs pos2 len
        fld |> FIXField.TotalAccruedInterestAmt
    | 541 ->
        let fld = ReadMaturityDate bs pos2 len
        fld |> FIXField.MaturityDate
    | 542 ->
        let fld = ReadUnderlyingMaturityDate bs pos2 len
        fld |> FIXField.UnderlyingMaturityDate
    | 543 ->
        let fld = ReadInstrRegistry bs pos2 len
        fld |> FIXField.InstrRegistry
    | 544 ->
        let fld = ReadCashMargin bs pos2 len
        fld |> FIXField.CashMargin
    | 545 ->
        let fld = ReadNestedPartySubID bs pos2 len
        fld |> FIXField.NestedPartySubID
    | 546 ->
        let fld = ReadScope bs pos2 len
        fld |> FIXField.Scope
    | 547 ->
        let fld = ReadMDImplicitDelete bs pos2 len
        fld |> FIXField.MDImplicitDelete
    | 548 ->
        let fld = ReadCrossID bs pos2 len
        fld |> FIXField.CrossID
    | 549 ->
        let fld = ReadCrossType bs pos2 len
        fld |> FIXField.CrossType
    | 550 ->
        let fld = ReadCrossPrioritization bs pos2 len
        fld |> FIXField.CrossPrioritization
    | 551 ->
        let fld = ReadOrigCrossID bs pos2 len
        fld |> FIXField.OrigCrossID
    | 552 ->
        let fld = ReadNoSides bs pos2 len
        fld |> FIXField.NoSides
    | 553 ->
        let fld = ReadUsername bs pos2 len
        fld |> FIXField.Username
    | 554 ->
        let fld = ReadPassword bs pos2 len
        fld |> FIXField.Password
    | 555 ->
        let fld = ReadNoLegs bs pos2 len
        fld |> FIXField.NoLegs
    | 556 ->
        let fld = ReadLegCurrency bs pos2 len
        fld |> FIXField.LegCurrency
    | 557 ->
        let fld = ReadTotNoSecurityTypes bs pos2 len
        fld |> FIXField.TotNoSecurityTypes
    | 558 ->
        let fld = ReadNoSecurityTypes bs pos2 len
        fld |> FIXField.NoSecurityTypes
    | 559 ->
        let fld = ReadSecurityListRequestType bs pos2 len
        fld |> FIXField.SecurityListRequestType
    | 560 ->
        let fld = ReadSecurityRequestResult bs pos2 len
        fld |> FIXField.SecurityRequestResult
    | 561 ->
        let fld = ReadRoundLot bs pos2 len
        fld |> FIXField.RoundLot
    | 562 ->
        let fld = ReadMinTradeVol bs pos2 len
        fld |> FIXField.MinTradeVol
    | 563 ->
        let fld = ReadMultiLegRptTypeReq bs pos2 len
        fld |> FIXField.MultiLegRptTypeReq
    | 564 ->
        let fld = ReadLegPositionEffect bs pos2 len
        fld |> FIXField.LegPositionEffect
    | 565 ->
        let fld = ReadLegCoveredOrUncovered bs pos2 len
        fld |> FIXField.LegCoveredOrUncovered
    | 566 ->
        let fld = ReadLegPrice bs pos2 len
        fld |> FIXField.LegPrice
    | 567 ->
        let fld = ReadTradSesStatusRejReason bs pos2 len
        fld |> FIXField.TradSesStatusRejReason
    | 568 ->
        let fld = ReadTradeRequestID bs pos2 len
        fld |> FIXField.TradeRequestID
    | 569 ->
        let fld = ReadTradeRequestType bs pos2 len
        fld |> FIXField.TradeRequestType
    | 570 ->
        let fld = ReadPreviouslyReported bs pos2 len
        fld |> FIXField.PreviouslyReported
    | 571 ->
        let fld = ReadTradeReportID bs pos2 len
        fld |> FIXField.TradeReportID
    | 572 ->
        let fld = ReadTradeReportRefID bs pos2 len
        fld |> FIXField.TradeReportRefID
    | 573 ->
        let fld = ReadMatchStatus bs pos2 len
        fld |> FIXField.MatchStatus
    | 574 ->
        let fld = ReadMatchType bs pos2 len
        fld |> FIXField.MatchType
    | 575 ->
        let fld = ReadOddLot bs pos2 len
        fld |> FIXField.OddLot
    | 576 ->
        let fld = ReadNoClearingInstructions bs pos2 len
        fld |> FIXField.NoClearingInstructions
    | 577 ->
        let fld = ReadClearingInstruction bs pos2 len
        fld |> FIXField.ClearingInstruction
    | 578 ->
        let fld = ReadTradeInputSource bs pos2 len
        fld |> FIXField.TradeInputSource
    | 579 ->
        let fld = ReadTradeInputDevice bs pos2 len
        fld |> FIXField.TradeInputDevice
    | 580 ->
        let fld = ReadNoDates bs pos2 len
        fld |> FIXField.NoDates
    | 581 ->
        let fld = ReadAccountType bs pos2 len
        fld |> FIXField.AccountType
    | 582 ->
        let fld = ReadCustOrderCapacity bs pos2 len
        fld |> FIXField.CustOrderCapacity
    | 583 ->
        let fld = ReadClOrdLinkID bs pos2 len
        fld |> FIXField.ClOrdLinkID
    | 584 ->
        let fld = ReadMassStatusReqID bs pos2 len
        fld |> FIXField.MassStatusReqID
    | 585 ->
        let fld = ReadMassStatusReqType bs pos2 len
        fld |> FIXField.MassStatusReqType
    | 586 ->
        let fld = ReadOrigOrdModTime bs pos2 len
        fld |> FIXField.OrigOrdModTime
    | 587 ->
        let fld = ReadLegSettlType bs pos2 len
        fld |> FIXField.LegSettlType
    | 588 ->
        let fld = ReadLegSettlDate bs pos2 len
        fld |> FIXField.LegSettlDate
    | 589 ->
        let fld = ReadDayBookingInst bs pos2 len
        fld |> FIXField.DayBookingInst
    | 590 ->
        let fld = ReadBookingUnit bs pos2 len
        fld |> FIXField.BookingUnit
    | 591 ->
        let fld = ReadPreallocMethod bs pos2 len
        fld |> FIXField.PreallocMethod
    | 592 ->
        let fld = ReadUnderlyingCountryOfIssue bs pos2 len
        fld |> FIXField.UnderlyingCountryOfIssue
    | 593 ->
        let fld = ReadUnderlyingStateOrProvinceOfIssue bs pos2 len
        fld |> FIXField.UnderlyingStateOrProvinceOfIssue
    | 594 ->
        let fld = ReadUnderlyingLocaleOfIssue bs pos2 len
        fld |> FIXField.UnderlyingLocaleOfIssue
    | 595 ->
        let fld = ReadUnderlyingInstrRegistry bs pos2 len
        fld |> FIXField.UnderlyingInstrRegistry
    | 596 ->
        let fld = ReadLegCountryOfIssue bs pos2 len
        fld |> FIXField.LegCountryOfIssue
    | 597 ->
        let fld = ReadLegStateOrProvinceOfIssue bs pos2 len
        fld |> FIXField.LegStateOrProvinceOfIssue
    | 598 ->
        let fld = ReadLegLocaleOfIssue bs pos2 len
        fld |> FIXField.LegLocaleOfIssue
    | 599 ->
        let fld = ReadLegInstrRegistry bs pos2 len
        fld |> FIXField.LegInstrRegistry
    | 600 ->
        let fld = ReadLegSymbol bs pos2 len
        fld |> FIXField.LegSymbol
    | 601 ->
        let fld = ReadLegSymbolSfx bs pos2 len
        fld |> FIXField.LegSymbolSfx
    | 602 ->
        let fld = ReadLegSecurityID bs pos2 len
        fld |> FIXField.LegSecurityID
    | 603 ->
        let fld = ReadLegSecurityIDSource bs pos2 len
        fld |> FIXField.LegSecurityIDSource
    | 604 ->
        let fld = ReadNoLegSecurityAltID bs pos2 len
        fld |> FIXField.NoLegSecurityAltID
    | 605 ->
        let fld = ReadLegSecurityAltID bs pos2 len
        fld |> FIXField.LegSecurityAltID
    | 606 ->
        let fld = ReadLegSecurityAltIDSource bs pos2 len
        fld |> FIXField.LegSecurityAltIDSource
    | 607 ->
        let fld = ReadLegProduct bs pos2 len
        fld |> FIXField.LegProduct
    | 608 ->
        let fld = ReadLegCFICode bs pos2 len
        fld |> FIXField.LegCFICode
    | 609 ->
        let fld = ReadLegSecurityType bs pos2 len
        fld |> FIXField.LegSecurityType
    | 610 ->
        let fld = ReadLegMaturityMonthYear bs pos2 len
        fld |> FIXField.LegMaturityMonthYear
    | 611 ->
        let fld = ReadLegMaturityDate bs pos2 len
        fld |> FIXField.LegMaturityDate
    | 612 ->
        let fld = ReadLegStrikePrice bs pos2 len
        fld |> FIXField.LegStrikePrice
    | 613 ->
        let fld = ReadLegOptAttribute bs pos2 len
        fld |> FIXField.LegOptAttribute
    | 614 ->
        let fld = ReadLegContractMultiplier bs pos2 len
        fld |> FIXField.LegContractMultiplier
    | 615 ->
        let fld = ReadLegCouponRate bs pos2 len
        fld |> FIXField.LegCouponRate
    | 616 ->
        let fld = ReadLegSecurityExchange bs pos2 len
        fld |> FIXField.LegSecurityExchange
    | 617 ->
        let fld = ReadLegIssuer bs pos2 len
        fld |> FIXField.LegIssuer
    | 618 ->
        let fld = ReadEncodedLegIssuer bs pos2 len
        fld |> FIXField.EncodedLegIssuer // len->string compound field
    | 620 ->
        let fld = ReadLegSecurityDesc bs pos2 len
        fld |> FIXField.LegSecurityDesc
    | 621 ->
        let fld = ReadEncodedLegSecurityDesc bs pos2 len
        fld |> FIXField.EncodedLegSecurityDesc // len->string compound field
    | 623 ->
        let fld = ReadLegRatioQty bs pos2 len
        fld |> FIXField.LegRatioQty
    | 624 ->
        let fld = ReadLegSide bs pos2 len
        fld |> FIXField.LegSide
    | 625 ->
        let fld = ReadTradingSessionSubID bs pos2 len
        fld |> FIXField.TradingSessionSubID
    | 626 ->
        let fld = ReadAllocType bs pos2 len
        fld |> FIXField.AllocType
    | 627 ->
        let fld = ReadNoHops bs pos2 len
        fld |> FIXField.NoHops
    | 628 ->
        let fld = ReadHopCompID bs pos2 len
        fld |> FIXField.HopCompID
    | 629 ->
        let fld = ReadHopSendingTime bs pos2 len
        fld |> FIXField.HopSendingTime
    | 630 ->
        let fld = ReadHopRefID bs pos2 len
        fld |> FIXField.HopRefID
    | 631 ->
        let fld = ReadMidPx bs pos2 len
        fld |> FIXField.MidPx
    | 632 ->
        let fld = ReadBidYield bs pos2 len
        fld |> FIXField.BidYield
    | 633 ->
        let fld = ReadMidYield bs pos2 len
        fld |> FIXField.MidYield
    | 634 ->
        let fld = ReadOfferYield bs pos2 len
        fld |> FIXField.OfferYield
    | 635 ->
        let fld = ReadClearingFeeIndicator bs pos2 len
        fld |> FIXField.ClearingFeeIndicator
    | 636 ->
        let fld = ReadWorkingIndicator bs pos2 len
        fld |> FIXField.WorkingIndicator
    | 637 ->
        let fld = ReadLegLastPx bs pos2 len
        fld |> FIXField.LegLastPx
    | 638 ->
        let fld = ReadPriorityIndicator bs pos2 len
        fld |> FIXField.PriorityIndicator
    | 639 ->
        let fld = ReadPriceImprovement bs pos2 len
        fld |> FIXField.PriceImprovement
    | 640 ->
        let fld = ReadPrice2 bs pos2 len
        fld |> FIXField.Price2
    | 641 ->
        let fld = ReadLastForwardPoints2 bs pos2 len
        fld |> FIXField.LastForwardPoints2
    | 642 ->
        let fld = ReadBidForwardPoints2 bs pos2 len
        fld |> FIXField.BidForwardPoints2
    | 643 ->
        let fld = ReadOfferForwardPoints2 bs pos2 len
        fld |> FIXField.OfferForwardPoints2
    | 644 ->
        let fld = ReadRFQReqID bs pos2 len
        fld |> FIXField.RFQReqID
    | 645 ->
        let fld = ReadMktBidPx bs pos2 len
        fld |> FIXField.MktBidPx
    | 646 ->
        let fld = ReadMktOfferPx bs pos2 len
        fld |> FIXField.MktOfferPx
    | 647 ->
        let fld = ReadMinBidSize bs pos2 len
        fld |> FIXField.MinBidSize
    | 648 ->
        let fld = ReadMinOfferSize bs pos2 len
        fld |> FIXField.MinOfferSize
    | 649 ->
        let fld = ReadQuoteStatusReqID bs pos2 len
        fld |> FIXField.QuoteStatusReqID
    | 650 ->
        let fld = ReadLegalConfirm bs pos2 len
        fld |> FIXField.LegalConfirm
    | 651 ->
        let fld = ReadUnderlyingLastPx bs pos2 len
        fld |> FIXField.UnderlyingLastPx
    | 652 ->
        let fld = ReadUnderlyingLastQty bs pos2 len
        fld |> FIXField.UnderlyingLastQty
    | 654 ->
        let fld = ReadLegRefID bs pos2 len
        fld |> FIXField.LegRefID
    | 655 ->
        let fld = ReadContraLegRefID bs pos2 len
        fld |> FIXField.ContraLegRefID
    | 656 ->
        let fld = ReadSettlCurrBidFxRate bs pos2 len
        fld |> FIXField.SettlCurrBidFxRate
    | 657 ->
        let fld = ReadSettlCurrOfferFxRate bs pos2 len
        fld |> FIXField.SettlCurrOfferFxRate
    | 658 ->
        let fld = ReadQuoteRequestRejectReason bs pos2 len
        fld |> FIXField.QuoteRequestRejectReason
    | 659 ->
        let fld = ReadSideComplianceID bs pos2 len
        fld |> FIXField.SideComplianceID
    | 660 ->
        let fld = ReadAcctIDSource bs pos2 len
        fld |> FIXField.AcctIDSource
    | 661 ->
        let fld = ReadAllocAcctIDSource bs pos2 len
        fld |> FIXField.AllocAcctIDSource
    | 662 ->
        let fld = ReadBenchmarkPrice bs pos2 len
        fld |> FIXField.BenchmarkPrice
    | 663 ->
        let fld = ReadBenchmarkPriceType bs pos2 len
        fld |> FIXField.BenchmarkPriceType
    | 664 ->
        let fld = ReadConfirmID bs pos2 len
        fld |> FIXField.ConfirmID
    | 665 ->
        let fld = ReadConfirmStatus bs pos2 len
        fld |> FIXField.ConfirmStatus
    | 666 ->
        let fld = ReadConfirmTransType bs pos2 len
        fld |> FIXField.ConfirmTransType
    | 667 ->
        let fld = ReadContractSettlMonth bs pos2 len
        fld |> FIXField.ContractSettlMonth
    | 668 ->
        let fld = ReadDeliveryForm bs pos2 len
        fld |> FIXField.DeliveryForm
    | 669 ->
        let fld = ReadLastParPx bs pos2 len
        fld |> FIXField.LastParPx
    | 670 ->
        let fld = ReadNoLegAllocs bs pos2 len
        fld |> FIXField.NoLegAllocs
    | 671 ->
        let fld = ReadLegAllocAccount bs pos2 len
        fld |> FIXField.LegAllocAccount
    | 672 ->
        let fld = ReadLegIndividualAllocID bs pos2 len
        fld |> FIXField.LegIndividualAllocID
    | 673 ->
        let fld = ReadLegAllocQty bs pos2 len
        fld |> FIXField.LegAllocQty
    | 674 ->
        let fld = ReadLegAllocAcctIDSource bs pos2 len
        fld |> FIXField.LegAllocAcctIDSource
    | 675 ->
        let fld = ReadLegSettlCurrency bs pos2 len
        fld |> FIXField.LegSettlCurrency
    | 676 ->
        let fld = ReadLegBenchmarkCurveCurrency bs pos2 len
        fld |> FIXField.LegBenchmarkCurveCurrency
    | 677 ->
        let fld = ReadLegBenchmarkCurveName bs pos2 len
        fld |> FIXField.LegBenchmarkCurveName
    | 678 ->
        let fld = ReadLegBenchmarkCurvePoint bs pos2 len
        fld |> FIXField.LegBenchmarkCurvePoint
    | 679 ->
        let fld = ReadLegBenchmarkPrice bs pos2 len
        fld |> FIXField.LegBenchmarkPrice
    | 680 ->
        let fld = ReadLegBenchmarkPriceType bs pos2 len
        fld |> FIXField.LegBenchmarkPriceType
    | 681 ->
        let fld = ReadLegBidPx bs pos2 len
        fld |> FIXField.LegBidPx
    | 682 ->
        let fld = ReadLegIOIQty bs pos2 len
        fld |> FIXField.LegIOIQty
    | 683 ->
        let fld = ReadNoLegStipulations bs pos2 len
        fld |> FIXField.NoLegStipulations
    | 684 ->
        let fld = ReadLegOfferPx bs pos2 len
        fld |> FIXField.LegOfferPx
    | 685 ->
        let fld = ReadLegOrderQty bs pos2 len
        fld |> FIXField.LegOrderQty
    | 686 ->
        let fld = ReadLegPriceType bs pos2 len
        fld |> FIXField.LegPriceType
    | 687 ->
        let fld = ReadLegQty bs pos2 len
        fld |> FIXField.LegQty
    | 688 ->
        let fld = ReadLegStipulationType bs pos2 len
        fld |> FIXField.LegStipulationType
    | 689 ->
        let fld = ReadLegStipulationValue bs pos2 len
        fld |> FIXField.LegStipulationValue
    | 690 ->
        let fld = ReadLegSwapType bs pos2 len
        fld |> FIXField.LegSwapType
    | 691 ->
        let fld = ReadPool bs pos2 len
        fld |> FIXField.Pool
    | 692 ->
        let fld = ReadQuotePriceType bs pos2 len
        fld |> FIXField.QuotePriceType
    | 693 ->
        let fld = ReadQuoteRespID bs pos2 len
        fld |> FIXField.QuoteRespID
    | 694 ->
        let fld = ReadQuoteRespType bs pos2 len
        fld |> FIXField.QuoteRespType
    | 695 ->
        let fld = ReadQuoteQualifier bs pos2 len
        fld |> FIXField.QuoteQualifier
    | 696 ->
        let fld = ReadYieldRedemptionDate bs pos2 len
        fld |> FIXField.YieldRedemptionDate
    | 697 ->
        let fld = ReadYieldRedemptionPrice bs pos2 len
        fld |> FIXField.YieldRedemptionPrice
    | 698 ->
        let fld = ReadYieldRedemptionPriceType bs pos2 len
        fld |> FIXField.YieldRedemptionPriceType
    | 699 ->
        let fld = ReadBenchmarkSecurityID bs pos2 len
        fld |> FIXField.BenchmarkSecurityID
    | 700 ->
        let fld = ReadReversalIndicator bs pos2 len
        fld |> FIXField.ReversalIndicator
    | 701 ->
        let fld = ReadYieldCalcDate bs pos2 len
        fld |> FIXField.YieldCalcDate
    | 702 ->
        let fld = ReadNoPositions bs pos2 len
        fld |> FIXField.NoPositions
    | 703 ->
        let fld = ReadPosType bs pos2 len
        fld |> FIXField.PosType
    | 704 ->
        let fld = ReadLongQty bs pos2 len
        fld |> FIXField.LongQty
    | 705 ->
        let fld = ReadShortQty bs pos2 len
        fld |> FIXField.ShortQty
    | 706 ->
        let fld = ReadPosQtyStatus bs pos2 len
        fld |> FIXField.PosQtyStatus
    | 707 ->
        let fld = ReadPosAmtType bs pos2 len
        fld |> FIXField.PosAmtType
    | 708 ->
        let fld = ReadPosAmt bs pos2 len
        fld |> FIXField.PosAmt
    | 709 ->
        let fld = ReadPosTransType bs pos2 len
        fld |> FIXField.PosTransType
    | 710 ->
        let fld = ReadPosReqID bs pos2 len
        fld |> FIXField.PosReqID
    | 711 ->
        let fld = ReadNoUnderlyings bs pos2 len
        fld |> FIXField.NoUnderlyings
    | 712 ->
        let fld = ReadPosMaintAction bs pos2 len
        fld |> FIXField.PosMaintAction
    | 713 ->
        let fld = ReadOrigPosReqRefID bs pos2 len
        fld |> FIXField.OrigPosReqRefID
    | 714 ->
        let fld = ReadPosMaintRptRefID bs pos2 len
        fld |> FIXField.PosMaintRptRefID
    | 715 ->
        let fld = ReadClearingBusinessDate bs pos2 len
        fld |> FIXField.ClearingBusinessDate
    | 716 ->
        let fld = ReadSettlSessID bs pos2 len
        fld |> FIXField.SettlSessID
    | 717 ->
        let fld = ReadSettlSessSubID bs pos2 len
        fld |> FIXField.SettlSessSubID
    | 718 ->
        let fld = ReadAdjustmentType bs pos2 len
        fld |> FIXField.AdjustmentType
    | 719 ->
        let fld = ReadContraryInstructionIndicator bs pos2 len
        fld |> FIXField.ContraryInstructionIndicator
    | 720 ->
        let fld = ReadPriorSpreadIndicator bs pos2 len
        fld |> FIXField.PriorSpreadIndicator
    | 721 ->
        let fld = ReadPosMaintRptID bs pos2 len
        fld |> FIXField.PosMaintRptID
    | 722 ->
        let fld = ReadPosMaintStatus bs pos2 len
        fld |> FIXField.PosMaintStatus
    | 723 ->
        let fld = ReadPosMaintResult bs pos2 len
        fld |> FIXField.PosMaintResult
    | 724 ->
        let fld = ReadPosReqType bs pos2 len
        fld |> FIXField.PosReqType
    | 725 ->
        let fld = ReadResponseTransportType bs pos2 len
        fld |> FIXField.ResponseTransportType
    | 726 ->
        let fld = ReadResponseDestination bs pos2 len
        fld |> FIXField.ResponseDestination
    | 727 ->
        let fld = ReadTotalNumPosReports bs pos2 len
        fld |> FIXField.TotalNumPosReports
    | 728 ->
        let fld = ReadPosReqResult bs pos2 len
        fld |> FIXField.PosReqResult
    | 729 ->
        let fld = ReadPosReqStatus bs pos2 len
        fld |> FIXField.PosReqStatus
    | 730 ->
        let fld = ReadSettlPrice bs pos2 len
        fld |> FIXField.SettlPrice
    | 731 ->
        let fld = ReadSettlPriceType bs pos2 len
        fld |> FIXField.SettlPriceType
    | 732 ->
        let fld = ReadUnderlyingSettlPrice bs pos2 len
        fld |> FIXField.UnderlyingSettlPrice
    | 733 ->
        let fld = ReadUnderlyingSettlPriceType bs pos2 len
        fld |> FIXField.UnderlyingSettlPriceType
    | 734 ->
        let fld = ReadPriorSettlPrice bs pos2 len
        fld |> FIXField.PriorSettlPrice
    | 735 ->
        let fld = ReadNoQuoteQualifiers bs pos2 len
        fld |> FIXField.NoQuoteQualifiers
    | 736 ->
        let fld = ReadAllocSettlCurrency bs pos2 len
        fld |> FIXField.AllocSettlCurrency
    | 737 ->
        let fld = ReadAllocSettlCurrAmt bs pos2 len
        fld |> FIXField.AllocSettlCurrAmt
    | 738 ->
        let fld = ReadInterestAtMaturity bs pos2 len
        fld |> FIXField.InterestAtMaturity
    | 739 ->
        let fld = ReadLegDatedDate bs pos2 len
        fld |> FIXField.LegDatedDate
    | 740 ->
        let fld = ReadLegPool bs pos2 len
        fld |> FIXField.LegPool
    | 741 ->
        let fld = ReadAllocInterestAtMaturity bs pos2 len
        fld |> FIXField.AllocInterestAtMaturity
    | 742 ->
        let fld = ReadAllocAccruedInterestAmt bs pos2 len
        fld |> FIXField.AllocAccruedInterestAmt
    | 743 ->
        let fld = ReadDeliveryDate bs pos2 len
        fld |> FIXField.DeliveryDate
    | 744 ->
        let fld = ReadAssignmentMethod bs pos2 len
        fld |> FIXField.AssignmentMethod
    | 745 ->
        let fld = ReadAssignmentUnit bs pos2 len
        fld |> FIXField.AssignmentUnit
    | 746 ->
        let fld = ReadOpenInterest bs pos2 len
        fld |> FIXField.OpenInterest
    | 747 ->
        let fld = ReadExerciseMethod bs pos2 len
        fld |> FIXField.ExerciseMethod
    | 748 ->
        let fld = ReadTotNumTradeReports bs pos2 len
        fld |> FIXField.TotNumTradeReports
    | 749 ->
        let fld = ReadTradeRequestResult bs pos2 len
        fld |> FIXField.TradeRequestResult
    | 750 ->
        let fld = ReadTradeRequestStatus bs pos2 len
        fld |> FIXField.TradeRequestStatus
    | 751 ->
        let fld = ReadTradeReportRejectReason bs pos2 len
        fld |> FIXField.TradeReportRejectReason
    | 752 ->
        let fld = ReadSideMultiLegReportingType bs pos2 len
        fld |> FIXField.SideMultiLegReportingType
    | 753 ->
        let fld = ReadNoPosAmt bs pos2 len
        fld |> FIXField.NoPosAmt
    | 754 ->
        let fld = ReadAutoAcceptIndicator bs pos2 len
        fld |> FIXField.AutoAcceptIndicator
    | 755 ->
        let fld = ReadAllocReportID bs pos2 len
        fld |> FIXField.AllocReportID
    | 756 ->
        let fld = ReadNoNested2PartyIDs bs pos2 len
        fld |> FIXField.NoNested2PartyIDs
    | 757 ->
        let fld = ReadNested2PartyID bs pos2 len
        fld |> FIXField.Nested2PartyID
    | 758 ->
        let fld = ReadNested2PartyIDSource bs pos2 len
        fld |> FIXField.Nested2PartyIDSource
    | 759 ->
        let fld = ReadNested2PartyRole bs pos2 len
        fld |> FIXField.Nested2PartyRole
    | 760 ->
        let fld = ReadNested2PartySubID bs pos2 len
        fld |> FIXField.Nested2PartySubID
    | 761 ->
        let fld = ReadBenchmarkSecurityIDSource bs pos2 len
        fld |> FIXField.BenchmarkSecurityIDSource
    | 762 ->
        let fld = ReadSecuritySubType bs pos2 len
        fld |> FIXField.SecuritySubType
    | 763 ->
        let fld = ReadUnderlyingSecuritySubType bs pos2 len
        fld |> FIXField.UnderlyingSecuritySubType
    | 764 ->
        let fld = ReadLegSecuritySubType bs pos2 len
        fld |> FIXField.LegSecuritySubType
    | 765 ->
        let fld = ReadAllowableOneSidednessPct bs pos2 len
        fld |> FIXField.AllowableOneSidednessPct
    | 766 ->
        let fld = ReadAllowableOneSidednessValue bs pos2 len
        fld |> FIXField.AllowableOneSidednessValue
    | 767 ->
        let fld = ReadAllowableOneSidednessCurr bs pos2 len
        fld |> FIXField.AllowableOneSidednessCurr
    | 768 ->
        let fld = ReadNoTrdRegTimestamps bs pos2 len
        fld |> FIXField.NoTrdRegTimestamps
    | 769 ->
        let fld = ReadTrdRegTimestamp bs pos2 len
        fld |> FIXField.TrdRegTimestamp
    | 770 ->
        let fld = ReadTrdRegTimestampType bs pos2 len
        fld |> FIXField.TrdRegTimestampType
    | 771 ->
        let fld = ReadTrdRegTimestampOrigin bs pos2 len
        fld |> FIXField.TrdRegTimestampOrigin
    | 772 ->
        let fld = ReadConfirmRefID bs pos2 len
        fld |> FIXField.ConfirmRefID
    | 773 ->
        let fld = ReadConfirmType bs pos2 len
        fld |> FIXField.ConfirmType
    | 774 ->
        let fld = ReadConfirmRejReason bs pos2 len
        fld |> FIXField.ConfirmRejReason
    | 775 ->
        let fld = ReadBookingType bs pos2 len
        fld |> FIXField.BookingType
    | 776 ->
        let fld = ReadIndividualAllocRejCode bs pos2 len
        fld |> FIXField.IndividualAllocRejCode
    | 777 ->
        let fld = ReadSettlInstMsgID bs pos2 len
        fld |> FIXField.SettlInstMsgID
    | 778 ->
        let fld = ReadNoSettlInst bs pos2 len
        fld |> FIXField.NoSettlInst
    | 779 ->
        let fld = ReadLastUpdateTime bs pos2 len
        fld |> FIXField.LastUpdateTime
    | 780 ->
        let fld = ReadAllocSettlInstType bs pos2 len
        fld |> FIXField.AllocSettlInstType
    | 781 ->
        let fld = ReadNoSettlPartyIDs bs pos2 len
        fld |> FIXField.NoSettlPartyIDs
    | 782 ->
        let fld = ReadSettlPartyID bs pos2 len
        fld |> FIXField.SettlPartyID
    | 783 ->
        let fld = ReadSettlPartyIDSource bs pos2 len
        fld |> FIXField.SettlPartyIDSource
    | 784 ->
        let fld = ReadSettlPartyRole bs pos2 len
        fld |> FIXField.SettlPartyRole
    | 785 ->
        let fld = ReadSettlPartySubID bs pos2 len
        fld |> FIXField.SettlPartySubID
    | 786 ->
        let fld = ReadSettlPartySubIDType bs pos2 len
        fld |> FIXField.SettlPartySubIDType
    | 787 ->
        let fld = ReadDlvyInstType bs pos2 len
        fld |> FIXField.DlvyInstType
    | 788 ->
        let fld = ReadTerminationType bs pos2 len
        fld |> FIXField.TerminationType
    | 789 ->
        let fld = ReadNextExpectedMsgSeqNum bs pos2 len
        fld |> FIXField.NextExpectedMsgSeqNum
    | 790 ->
        let fld = ReadOrdStatusReqID bs pos2 len
        fld |> FIXField.OrdStatusReqID
    | 791 ->
        let fld = ReadSettlInstReqID bs pos2 len
        fld |> FIXField.SettlInstReqID
    | 792 ->
        let fld = ReadSettlInstReqRejCode bs pos2 len
        fld |> FIXField.SettlInstReqRejCode
    | 793 ->
        let fld = ReadSecondaryAllocID bs pos2 len
        fld |> FIXField.SecondaryAllocID
    | 794 ->
        let fld = ReadAllocReportType bs pos2 len
        fld |> FIXField.AllocReportType
    | 795 ->
        let fld = ReadAllocReportRefID bs pos2 len
        fld |> FIXField.AllocReportRefID
    | 796 ->
        let fld = ReadAllocCancReplaceReason bs pos2 len
        fld |> FIXField.AllocCancReplaceReason
    | 797 ->
        let fld = ReadCopyMsgIndicator bs pos2 len
        fld |> FIXField.CopyMsgIndicator
    | 798 ->
        let fld = ReadAllocAccountType bs pos2 len
        fld |> FIXField.AllocAccountType
    | 799 ->
        let fld = ReadOrderAvgPx bs pos2 len
        fld |> FIXField.OrderAvgPx
    | 800 ->
        let fld = ReadOrderBookingQty bs pos2 len
        fld |> FIXField.OrderBookingQty
    | 801 ->
        let fld = ReadNoSettlPartySubIDs bs pos2 len
        fld |> FIXField.NoSettlPartySubIDs
    | 802 ->
        let fld = ReadNoPartySubIDs bs pos2 len
        fld |> FIXField.NoPartySubIDs
    | 803 ->
        let fld = ReadPartySubIDType bs pos2 len
        fld |> FIXField.PartySubIDType
    | 804 ->
        let fld = ReadNoNestedPartySubIDs bs pos2 len
        fld |> FIXField.NoNestedPartySubIDs
    | 805 ->
        let fld = ReadNestedPartySubIDType bs pos2 len
        fld |> FIXField.NestedPartySubIDType
    | 806 ->
        let fld = ReadNoNested2PartySubIDs bs pos2 len
        fld |> FIXField.NoNested2PartySubIDs
    | 807 ->
        let fld = ReadNested2PartySubIDType bs pos2 len
        fld |> FIXField.Nested2PartySubIDType
    | 808 ->
        let fld = ReadAllocIntermedReqType bs pos2 len
        fld |> FIXField.AllocIntermedReqType
    | 810 ->
        let fld = ReadUnderlyingPx bs pos2 len
        fld |> FIXField.UnderlyingPx
    | 811 ->
        let fld = ReadPriceDelta bs pos2 len
        fld |> FIXField.PriceDelta
    | 812 ->
        let fld = ReadApplQueueMax bs pos2 len
        fld |> FIXField.ApplQueueMax
    | 813 ->
        let fld = ReadApplQueueDepth bs pos2 len
        fld |> FIXField.ApplQueueDepth
    | 814 ->
        let fld = ReadApplQueueResolution bs pos2 len
        fld |> FIXField.ApplQueueResolution
    | 815 ->
        let fld = ReadApplQueueAction bs pos2 len
        fld |> FIXField.ApplQueueAction
    | 816 ->
        let fld = ReadNoAltMDSource bs pos2 len
        fld |> FIXField.NoAltMDSource
    | 817 ->
        let fld = ReadAltMDSourceID bs pos2 len
        fld |> FIXField.AltMDSourceID
    | 818 ->
        let fld = ReadSecondaryTradeReportID bs pos2 len
        fld |> FIXField.SecondaryTradeReportID
    | 819 ->
        let fld = ReadAvgPxIndicator bs pos2 len
        fld |> FIXField.AvgPxIndicator
    | 820 ->
        let fld = ReadTradeLinkID bs pos2 len
        fld |> FIXField.TradeLinkID
    | 821 ->
        let fld = ReadOrderInputDevice bs pos2 len
        fld |> FIXField.OrderInputDevice
    | 822 ->
        let fld = ReadUnderlyingTradingSessionID bs pos2 len
        fld |> FIXField.UnderlyingTradingSessionID
    | 823 ->
        let fld = ReadUnderlyingTradingSessionSubID bs pos2 len
        fld |> FIXField.UnderlyingTradingSessionSubID
    | 824 ->
        let fld = ReadTradeLegRefID bs pos2 len
        fld |> FIXField.TradeLegRefID
    | 825 ->
        let fld = ReadExchangeRule bs pos2 len
        fld |> FIXField.ExchangeRule
    | 826 ->
        let fld = ReadTradeAllocIndicator bs pos2 len
        fld |> FIXField.TradeAllocIndicator
    | 827 ->
        let fld = ReadExpirationCycle bs pos2 len
        fld |> FIXField.ExpirationCycle
    | 828 ->
        let fld = ReadTrdType bs pos2 len
        fld |> FIXField.TrdType
    | 829 ->
        let fld = ReadTrdSubType bs pos2 len
        fld |> FIXField.TrdSubType
    | 830 ->
        let fld = ReadTransferReason bs pos2 len
        fld |> FIXField.TransferReason
    | 831 ->
        let fld = ReadAsgnReqID bs pos2 len
        fld |> FIXField.AsgnReqID
    | 832 ->
        let fld = ReadTotNumAssignmentReports bs pos2 len
        fld |> FIXField.TotNumAssignmentReports
    | 833 ->
        let fld = ReadAsgnRptID bs pos2 len
        fld |> FIXField.AsgnRptID
    | 834 ->
        let fld = ReadThresholdAmount bs pos2 len
        fld |> FIXField.ThresholdAmount
    | 835 ->
        let fld = ReadPegMoveType bs pos2 len
        fld |> FIXField.PegMoveType
    | 836 ->
        let fld = ReadPegOffsetType bs pos2 len
        fld |> FIXField.PegOffsetType
    | 837 ->
        let fld = ReadPegLimitType bs pos2 len
        fld |> FIXField.PegLimitType
    | 838 ->
        let fld = ReadPegRoundDirection bs pos2 len
        fld |> FIXField.PegRoundDirection
    | 839 ->
        let fld = ReadPeggedPrice bs pos2 len
        fld |> FIXField.PeggedPrice
    | 840 ->
        let fld = ReadPegScope bs pos2 len
        fld |> FIXField.PegScope
    | 841 ->
        let fld = ReadDiscretionMoveType bs pos2 len
        fld |> FIXField.DiscretionMoveType
    | 842 ->
        let fld = ReadDiscretionOffsetType bs pos2 len
        fld |> FIXField.DiscretionOffsetType
    | 843 ->
        let fld = ReadDiscretionLimitType bs pos2 len
        fld |> FIXField.DiscretionLimitType
    | 844 ->
        let fld = ReadDiscretionRoundDirection bs pos2 len
        fld |> FIXField.DiscretionRoundDirection
    | 845 ->
        let fld = ReadDiscretionPrice bs pos2 len
        fld |> FIXField.DiscretionPrice
    | 846 ->
        let fld = ReadDiscretionScope bs pos2 len
        fld |> FIXField.DiscretionScope
    | 847 ->
        let fld = ReadTargetStrategy bs pos2 len
        fld |> FIXField.TargetStrategy
    | 848 ->
        let fld = ReadTargetStrategyParameters bs pos2 len
        fld |> FIXField.TargetStrategyParameters
    | 849 ->
        let fld = ReadParticipationRate bs pos2 len
        fld |> FIXField.ParticipationRate
    | 850 ->
        let fld = ReadTargetStrategyPerformance bs pos2 len
        fld |> FIXField.TargetStrategyPerformance
    | 851 ->
        let fld = ReadLastLiquidityInd bs pos2 len
        fld |> FIXField.LastLiquidityInd
    | 852 ->
        let fld = ReadPublishTrdIndicator bs pos2 len
        fld |> FIXField.PublishTrdIndicator
    | 853 ->
        let fld = ReadShortSaleReason bs pos2 len
        fld |> FIXField.ShortSaleReason
    | 854 ->
        let fld = ReadQtyType bs pos2 len
        fld |> FIXField.QtyType
    | 855 ->
        let fld = ReadSecondaryTrdType bs pos2 len
        fld |> FIXField.SecondaryTrdType
    | 856 ->
        let fld = ReadTradeReportType bs pos2 len
        fld |> FIXField.TradeReportType
    | 857 ->
        let fld = ReadAllocNoOrdersType bs pos2 len
        fld |> FIXField.AllocNoOrdersType
    | 858 ->
        let fld = ReadSharedCommission bs pos2 len
        fld |> FIXField.SharedCommission
    | 859 ->
        let fld = ReadConfirmReqID bs pos2 len
        fld |> FIXField.ConfirmReqID
    | 860 ->
        let fld = ReadAvgParPx bs pos2 len
        fld |> FIXField.AvgParPx
    | 861 ->
        let fld = ReadReportedPx bs pos2 len
        fld |> FIXField.ReportedPx
    | 862 ->
        let fld = ReadNoCapacities bs pos2 len
        fld |> FIXField.NoCapacities
    | 863 ->
        let fld = ReadOrderCapacityQty bs pos2 len
        fld |> FIXField.OrderCapacityQty
    | 864 ->
        let fld = ReadNoEvents bs pos2 len
        fld |> FIXField.NoEvents
    | 865 ->
        let fld = ReadEventType bs pos2 len
        fld |> FIXField.EventType
    | 866 ->
        let fld = ReadEventDate bs pos2 len
        fld |> FIXField.EventDate
    | 867 ->
        let fld = ReadEventPx bs pos2 len
        fld |> FIXField.EventPx
    | 868 ->
        let fld = ReadEventText bs pos2 len
        fld |> FIXField.EventText
    | 869 ->
        let fld = ReadPctAtRisk bs pos2 len
        fld |> FIXField.PctAtRisk
    | 870 ->
        let fld = ReadNoInstrAttrib bs pos2 len
        fld |> FIXField.NoInstrAttrib
    | 871 ->
        let fld = ReadInstrAttribType bs pos2 len
        fld |> FIXField.InstrAttribType
    | 872 ->
        let fld = ReadInstrAttribValue bs pos2 len
        fld |> FIXField.InstrAttribValue
    | 873 ->
        let fld = ReadDatedDate bs pos2 len
        fld |> FIXField.DatedDate
    | 874 ->
        let fld = ReadInterestAccrualDate bs pos2 len
        fld |> FIXField.InterestAccrualDate
    | 875 ->
        let fld = ReadCPProgram bs pos2 len
        fld |> FIXField.CPProgram
    | 876 ->
        let fld = ReadCPRegType bs pos2 len
        fld |> FIXField.CPRegType
    | 877 ->
        let fld = ReadUnderlyingCPProgram bs pos2 len
        fld |> FIXField.UnderlyingCPProgram
    | 878 ->
        let fld = ReadUnderlyingCPRegType bs pos2 len
        fld |> FIXField.UnderlyingCPRegType
    | 879 ->
        let fld = ReadUnderlyingQty bs pos2 len
        fld |> FIXField.UnderlyingQty
    | 880 ->
        let fld = ReadTrdMatchID bs pos2 len
        fld |> FIXField.TrdMatchID
    | 881 ->
        let fld = ReadSecondaryTradeReportRefID bs pos2 len
        fld |> FIXField.SecondaryTradeReportRefID
    | 882 ->
        let fld = ReadUnderlyingDirtyPrice bs pos2 len
        fld |> FIXField.UnderlyingDirtyPrice
    | 883 ->
        let fld = ReadUnderlyingEndPrice bs pos2 len
        fld |> FIXField.UnderlyingEndPrice
    | 884 ->
        let fld = ReadUnderlyingStartValue bs pos2 len
        fld |> FIXField.UnderlyingStartValue
    | 885 ->
        let fld = ReadUnderlyingCurrentValue bs pos2 len
        fld |> FIXField.UnderlyingCurrentValue
    | 886 ->
        let fld = ReadUnderlyingEndValue bs pos2 len
        fld |> FIXField.UnderlyingEndValue
    | 887 ->
        let fld = ReadNoUnderlyingStips bs pos2 len
        fld |> FIXField.NoUnderlyingStips
    | 888 ->
        let fld = ReadUnderlyingStipType bs pos2 len
        fld |> FIXField.UnderlyingStipType
    | 889 ->
        let fld = ReadUnderlyingStipValue bs pos2 len
        fld |> FIXField.UnderlyingStipValue
    | 890 ->
        let fld = ReadMaturityNetMoney bs pos2 len
        fld |> FIXField.MaturityNetMoney
    | 891 ->
        let fld = ReadMiscFeeBasis bs pos2 len
        fld |> FIXField.MiscFeeBasis
    | 892 ->
        let fld = ReadTotNoAllocs bs pos2 len
        fld |> FIXField.TotNoAllocs
    | 893 ->
        let fld = ReadLastFragment bs pos2 len
        fld |> FIXField.LastFragment
    | 894 ->
        let fld = ReadCollReqID bs pos2 len
        fld |> FIXField.CollReqID
    | 895 ->
        let fld = ReadCollAsgnReason bs pos2 len
        fld |> FIXField.CollAsgnReason
    | 896 ->
        let fld = ReadCollInquiryQualifier bs pos2 len
        fld |> FIXField.CollInquiryQualifier
    | 897 ->
        let fld = ReadNoTrades bs pos2 len
        fld |> FIXField.NoTrades
    | 898 ->
        let fld = ReadMarginRatio bs pos2 len
        fld |> FIXField.MarginRatio
    | 899 ->
        let fld = ReadMarginExcess bs pos2 len
        fld |> FIXField.MarginExcess
    | 900 ->
        let fld = ReadTotalNetValue bs pos2 len
        fld |> FIXField.TotalNetValue
    | 901 ->
        let fld = ReadCashOutstanding bs pos2 len
        fld |> FIXField.CashOutstanding
    | 902 ->
        let fld = ReadCollAsgnID bs pos2 len
        fld |> FIXField.CollAsgnID
    | 903 ->
        let fld = ReadCollAsgnTransType bs pos2 len
        fld |> FIXField.CollAsgnTransType
    | 904 ->
        let fld = ReadCollRespID bs pos2 len
        fld |> FIXField.CollRespID
    | 905 ->
        let fld = ReadCollAsgnRespType bs pos2 len
        fld |> FIXField.CollAsgnRespType
    | 906 ->
        let fld = ReadCollAsgnRejectReason bs pos2 len
        fld |> FIXField.CollAsgnRejectReason
    | 907 ->
        let fld = ReadCollAsgnRefID bs pos2 len
        fld |> FIXField.CollAsgnRefID
    | 908 ->
        let fld = ReadCollRptID bs pos2 len
        fld |> FIXField.CollRptID
    | 909 ->
        let fld = ReadCollInquiryID bs pos2 len
        fld |> FIXField.CollInquiryID
    | 910 ->
        let fld = ReadCollStatus bs pos2 len
        fld |> FIXField.CollStatus
    | 911 ->
        let fld = ReadTotNumReports bs pos2 len
        fld |> FIXField.TotNumReports
    | 912 ->
        let fld = ReadLastRptRequested bs pos2 len
        fld |> FIXField.LastRptRequested
    | 913 ->
        let fld = ReadAgreementDesc bs pos2 len
        fld |> FIXField.AgreementDesc
    | 914 ->
        let fld = ReadAgreementID bs pos2 len
        fld |> FIXField.AgreementID
    | 915 ->
        let fld = ReadAgreementDate bs pos2 len
        fld |> FIXField.AgreementDate
    | 916 ->
        let fld = ReadStartDate bs pos2 len
        fld |> FIXField.StartDate
    | 917 ->
        let fld = ReadEndDate bs pos2 len
        fld |> FIXField.EndDate
    | 918 ->
        let fld = ReadAgreementCurrency bs pos2 len
        fld |> FIXField.AgreementCurrency
    | 919 ->
        let fld = ReadDeliveryType bs pos2 len
        fld |> FIXField.DeliveryType
    | 920 ->
        let fld = ReadEndAccruedInterestAmt bs pos2 len
        fld |> FIXField.EndAccruedInterestAmt
    | 921 ->
        let fld = ReadStartCash bs pos2 len
        fld |> FIXField.StartCash
    | 922 ->
        let fld = ReadEndCash bs pos2 len
        fld |> FIXField.EndCash
    | 923 ->
        let fld = ReadUserRequestID bs pos2 len
        fld |> FIXField.UserRequestID
    | 924 ->
        let fld = ReadUserRequestType bs pos2 len
        fld |> FIXField.UserRequestType
    | 925 ->
        let fld = ReadNewPassword bs pos2 len
        fld |> FIXField.NewPassword
    | 926 ->
        let fld = ReadUserStatus bs pos2 len
        fld |> FIXField.UserStatus
    | 927 ->
        let fld = ReadUserStatusText bs pos2 len
        fld |> FIXField.UserStatusText
    | 928 ->
        let fld = ReadStatusValue bs pos2 len
        fld |> FIXField.StatusValue
    | 929 ->
        let fld = ReadStatusText bs pos2 len
        fld |> FIXField.StatusText
    | 930 ->
        let fld = ReadRefCompID bs pos2 len
        fld |> FIXField.RefCompID
    | 931 ->
        let fld = ReadRefSubID bs pos2 len
        fld |> FIXField.RefSubID
    | 932 ->
        let fld = ReadNetworkResponseID bs pos2 len
        fld |> FIXField.NetworkResponseID
    | 933 ->
        let fld = ReadNetworkRequestID bs pos2 len
        fld |> FIXField.NetworkRequestID
    | 934 ->
        let fld = ReadLastNetworkResponseID bs pos2 len
        fld |> FIXField.LastNetworkResponseID
    | 935 ->
        let fld = ReadNetworkRequestType bs pos2 len
        fld |> FIXField.NetworkRequestType
    | 936 ->
        let fld = ReadNoCompIDs bs pos2 len
        fld |> FIXField.NoCompIDs
    | 937 ->
        let fld = ReadNetworkStatusResponseType bs pos2 len
        fld |> FIXField.NetworkStatusResponseType
    | 938 ->
        let fld = ReadNoCollInquiryQualifier bs pos2 len
        fld |> FIXField.NoCollInquiryQualifier
    | 939 ->
        let fld = ReadTrdRptStatus bs pos2 len
        fld |> FIXField.TrdRptStatus
    | 940 ->
        let fld = ReadAffirmStatus bs pos2 len
        fld |> FIXField.AffirmStatus
    | 941 ->
        let fld = ReadUnderlyingStrikeCurrency bs pos2 len
        fld |> FIXField.UnderlyingStrikeCurrency
    | 942 ->
        let fld = ReadLegStrikeCurrency bs pos2 len
        fld |> FIXField.LegStrikeCurrency
    | 943 ->
        let fld = ReadTimeBracket bs pos2 len
        fld |> FIXField.TimeBracket
    | 944 ->
        let fld = ReadCollAction bs pos2 len
        fld |> FIXField.CollAction
    | 945 ->
        let fld = ReadCollInquiryStatus bs pos2 len
        fld |> FIXField.CollInquiryStatus
    | 946 ->
        let fld = ReadCollInquiryResult bs pos2 len
        fld |> FIXField.CollInquiryResult
    | 947 ->
        let fld = ReadStrikeCurrency bs pos2 len
        fld |> FIXField.StrikeCurrency
    | 948 ->
        let fld = ReadNoNested3PartyIDs bs pos2 len
        fld |> FIXField.NoNested3PartyIDs
    | 949 ->
        let fld = ReadNested3PartyID bs pos2 len
        fld |> FIXField.Nested3PartyID
    | 950 ->
        let fld = ReadNested3PartyIDSource bs pos2 len
        fld |> FIXField.Nested3PartyIDSource
    | 951 ->
        let fld = ReadNested3PartyRole bs pos2 len
        fld |> FIXField.Nested3PartyRole
    | 952 ->
        let fld = ReadNoNested3PartySubIDs bs pos2 len
        fld |> FIXField.NoNested3PartySubIDs
    | 953 ->
        let fld = ReadNested3PartySubID bs pos2 len
        fld |> FIXField.Nested3PartySubID
    | 954 ->
        let fld = ReadNested3PartySubIDType bs pos2 len
        fld |> FIXField.Nested3PartySubIDType
    | 955 ->
        let fld = ReadLegContractSettlMonth bs pos2 len
        fld |> FIXField.LegContractSettlMonth
    | 956 ->
        let fld = ReadLegInterestAccrualDate bs pos2 len
        fld |> FIXField.LegInterestAccrualDate
    |  _  -> failwith "FIXField invalid tag" 
