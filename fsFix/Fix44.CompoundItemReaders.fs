module Fix44.CompoundItemReaders

open ReaderUtils
open Fix44.Fields
open Fix44.FieldReaders
open Fix44.CompoundItems


// group
let ReadNoUnderlyingSecurityAltIDGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingSecurityAltIDGrp =
    let underlyingSecurityAltID = ReadFieldOrdered true bs index 458 ReadUnderlyingSecurityAltID
    let underlyingSecurityAltIDSource = ReadOptionalFieldOrdered true bs index 459 ReadUnderlyingSecurityAltIDSource
    let ci:NoUnderlyingSecurityAltIDGrp = {
        UnderlyingSecurityAltID = underlyingSecurityAltID
        UnderlyingSecurityAltIDSource = underlyingSecurityAltIDSource
    }
    ci


// group
let ReadNoUnderlyingStipsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingStipsGrp =
    let underlyingStipType = ReadFieldOrdered true bs index 888 ReadUnderlyingStipType
    let underlyingStipValue = ReadOptionalFieldOrdered true bs index 889 ReadUnderlyingStipValue
    let ci:NoUnderlyingStipsGrp = {
        UnderlyingStipType = underlyingStipType
        UnderlyingStipValue = underlyingStipValue
    }
    ci


// component, random access reader
let ReadUnderlyingInstrument (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingInstrument =
    let underlyingSymbol = ReadField bs index 311 ReadUnderlyingSymbol
    let underlyingSymbolSfx = ReadOptionalField bs index 312 ReadUnderlyingSymbolSfx
    let underlyingSecurityID = ReadOptionalField bs index 309 ReadUnderlyingSecurityID
    let underlyingSecurityIDSource = ReadOptionalField bs index 305 ReadUnderlyingSecurityIDSource
    let noUnderlyingSecurityAltIDGrp = ReadOptionalGroup bs index 457 ReadNoUnderlyingSecurityAltIDGrp
    let underlyingProduct = ReadOptionalField bs index 462 ReadUnderlyingProduct
    let underlyingCFICode = ReadOptionalField bs index 463 ReadUnderlyingCFICode
    let underlyingSecurityType = ReadOptionalField bs index 310 ReadUnderlyingSecurityType
    let underlyingSecuritySubType = ReadOptionalField bs index 763 ReadUnderlyingSecuritySubType
    let underlyingMaturityMonthYear = ReadOptionalField bs index 313 ReadUnderlyingMaturityMonthYear
    let underlyingMaturityDate = ReadOptionalField bs index 542 ReadUnderlyingMaturityDate
    let underlyingPutOrCall = ReadOptionalField bs index 315 ReadUnderlyingPutOrCall
    let underlyingCouponPaymentDate = ReadOptionalField bs index 241 ReadUnderlyingCouponPaymentDate
    let underlyingIssueDate = ReadOptionalField bs index 242 ReadUnderlyingIssueDate
    let underlyingRepoCollateralSecurityType = ReadOptionalField bs index 243 ReadUnderlyingRepoCollateralSecurityType
    let underlyingRepurchaseTerm = ReadOptionalField bs index 244 ReadUnderlyingRepurchaseTerm
    let underlyingRepurchaseRate = ReadOptionalField bs index 245 ReadUnderlyingRepurchaseRate
    let underlyingFactor = ReadOptionalField bs index 246 ReadUnderlyingFactor
    let underlyingCreditRating = ReadOptionalField bs index 256 ReadUnderlyingCreditRating
    let underlyingInstrRegistry = ReadOptionalField bs index 595 ReadUnderlyingInstrRegistry
    let underlyingCountryOfIssue = ReadOptionalField bs index 592 ReadUnderlyingCountryOfIssue
    let underlyingStateOrProvinceOfIssue = ReadOptionalField bs index 593 ReadUnderlyingStateOrProvinceOfIssue
    let underlyingLocaleOfIssue = ReadOptionalField bs index 594 ReadUnderlyingLocaleOfIssue
    let underlyingRedemptionDate = ReadOptionalField bs index 247 ReadUnderlyingRedemptionDate
    let underlyingStrikePrice = ReadOptionalField bs index 316 ReadUnderlyingStrikePrice
    let underlyingStrikeCurrency = ReadOptionalField bs index 941 ReadUnderlyingStrikeCurrency
    let underlyingOptAttribute = ReadOptionalField bs index 317 ReadUnderlyingOptAttribute
    let underlyingContractMultiplier = ReadOptionalField bs index 436 ReadUnderlyingContractMultiplier
    let underlyingCouponRate = ReadOptionalField bs index 435 ReadUnderlyingCouponRate
    let underlyingSecurityExchange = ReadOptionalField bs index 308 ReadUnderlyingSecurityExchange
    let underlyingIssuer = ReadOptionalField bs index 306 ReadUnderlyingIssuer
    let encodedUnderlyingIssuer = ReadOptionalField bs index 362 ReadEncodedUnderlyingIssuer
    let underlyingSecurityDesc = ReadOptionalField bs index 307 ReadUnderlyingSecurityDesc
    let encodedUnderlyingSecurityDesc = ReadOptionalField bs index 364 ReadEncodedUnderlyingSecurityDesc
    let underlyingCPProgram = ReadOptionalField bs index 877 ReadUnderlyingCPProgram
    let underlyingCPRegType = ReadOptionalField bs index 878 ReadUnderlyingCPRegType
    let underlyingCurrency = ReadOptionalField bs index 318 ReadUnderlyingCurrency
    let underlyingQty = ReadOptionalField bs index 879 ReadUnderlyingQty
    let underlyingPx = ReadOptionalField bs index 810 ReadUnderlyingPx
    let underlyingDirtyPrice = ReadOptionalField bs index 882 ReadUnderlyingDirtyPrice
    let underlyingEndPrice = ReadOptionalField bs index 883 ReadUnderlyingEndPrice
    let underlyingStartValue = ReadOptionalField bs index 884 ReadUnderlyingStartValue
    let underlyingCurrentValue = ReadOptionalField bs index 885 ReadUnderlyingCurrentValue
    let underlyingEndValue = ReadOptionalField bs index 886 ReadUnderlyingEndValue
    let noUnderlyingStipsGrp = ReadOptionalGroup bs index 887 ReadNoUnderlyingStipsGrp
    let ci:UnderlyingInstrument = {
        UnderlyingSymbol = underlyingSymbol
        UnderlyingSymbolSfx = underlyingSymbolSfx
        UnderlyingSecurityID = underlyingSecurityID
        UnderlyingSecurityIDSource = underlyingSecurityIDSource
        NoUnderlyingSecurityAltIDGrp = noUnderlyingSecurityAltIDGrp
        UnderlyingProduct = underlyingProduct
        UnderlyingCFICode = underlyingCFICode
        UnderlyingSecurityType = underlyingSecurityType
        UnderlyingSecuritySubType = underlyingSecuritySubType
        UnderlyingMaturityMonthYear = underlyingMaturityMonthYear
        UnderlyingMaturityDate = underlyingMaturityDate
        UnderlyingPutOrCall = underlyingPutOrCall
        UnderlyingCouponPaymentDate = underlyingCouponPaymentDate
        UnderlyingIssueDate = underlyingIssueDate
        UnderlyingRepoCollateralSecurityType = underlyingRepoCollateralSecurityType
        UnderlyingRepurchaseTerm = underlyingRepurchaseTerm
        UnderlyingRepurchaseRate = underlyingRepurchaseRate
        UnderlyingFactor = underlyingFactor
        UnderlyingCreditRating = underlyingCreditRating
        UnderlyingInstrRegistry = underlyingInstrRegistry
        UnderlyingCountryOfIssue = underlyingCountryOfIssue
        UnderlyingStateOrProvinceOfIssue = underlyingStateOrProvinceOfIssue
        UnderlyingLocaleOfIssue = underlyingLocaleOfIssue
        UnderlyingRedemptionDate = underlyingRedemptionDate
        UnderlyingStrikePrice = underlyingStrikePrice
        UnderlyingStrikeCurrency = underlyingStrikeCurrency
        UnderlyingOptAttribute = underlyingOptAttribute
        UnderlyingContractMultiplier = underlyingContractMultiplier
        UnderlyingCouponRate = underlyingCouponRate
        UnderlyingSecurityExchange = underlyingSecurityExchange
        UnderlyingIssuer = underlyingIssuer
        EncodedUnderlyingIssuer = encodedUnderlyingIssuer
        UnderlyingSecurityDesc = underlyingSecurityDesc
        EncodedUnderlyingSecurityDesc = encodedUnderlyingSecurityDesc
        UnderlyingCPProgram = underlyingCPProgram
        UnderlyingCPRegType = underlyingCPRegType
        UnderlyingCurrency = underlyingCurrency
        UnderlyingQty = underlyingQty
        UnderlyingPx = underlyingPx
        UnderlyingDirtyPrice = underlyingDirtyPrice
        UnderlyingEndPrice = underlyingEndPrice
        UnderlyingStartValue = underlyingStartValue
        UnderlyingCurrentValue = underlyingCurrentValue
        UnderlyingEndValue = underlyingEndValue
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadUnderlyingInstrumentOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingInstrument =
    let underlyingSymbol = ReadFieldOrdered true bs index 311 ReadUnderlyingSymbol
    let underlyingSymbolSfx = ReadOptionalFieldOrdered true bs index 312 ReadUnderlyingSymbolSfx
    let underlyingSecurityID = ReadOptionalFieldOrdered true bs index 309 ReadUnderlyingSecurityID
    let underlyingSecurityIDSource = ReadOptionalFieldOrdered true bs index 305 ReadUnderlyingSecurityIDSource
    let noUnderlyingSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 457 ReadNoUnderlyingSecurityAltIDGrp
    let underlyingProduct = ReadOptionalFieldOrdered true bs index 462 ReadUnderlyingProduct
    let underlyingCFICode = ReadOptionalFieldOrdered true bs index 463 ReadUnderlyingCFICode
    let underlyingSecurityType = ReadOptionalFieldOrdered true bs index 310 ReadUnderlyingSecurityType
    let underlyingSecuritySubType = ReadOptionalFieldOrdered true bs index 763 ReadUnderlyingSecuritySubType
    let underlyingMaturityMonthYear = ReadOptionalFieldOrdered true bs index 313 ReadUnderlyingMaturityMonthYear
    let underlyingMaturityDate = ReadOptionalFieldOrdered true bs index 542 ReadUnderlyingMaturityDate
    let underlyingPutOrCall = ReadOptionalFieldOrdered true bs index 315 ReadUnderlyingPutOrCall
    let underlyingCouponPaymentDate = ReadOptionalFieldOrdered true bs index 241 ReadUnderlyingCouponPaymentDate
    let underlyingIssueDate = ReadOptionalFieldOrdered true bs index 242 ReadUnderlyingIssueDate
    let underlyingRepoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 243 ReadUnderlyingRepoCollateralSecurityType
    let underlyingRepurchaseTerm = ReadOptionalFieldOrdered true bs index 244 ReadUnderlyingRepurchaseTerm
    let underlyingRepurchaseRate = ReadOptionalFieldOrdered true bs index 245 ReadUnderlyingRepurchaseRate
    let underlyingFactor = ReadOptionalFieldOrdered true bs index 246 ReadUnderlyingFactor
    let underlyingCreditRating = ReadOptionalFieldOrdered true bs index 256 ReadUnderlyingCreditRating
    let underlyingInstrRegistry = ReadOptionalFieldOrdered true bs index 595 ReadUnderlyingInstrRegistry
    let underlyingCountryOfIssue = ReadOptionalFieldOrdered true bs index 592 ReadUnderlyingCountryOfIssue
    let underlyingStateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 593 ReadUnderlyingStateOrProvinceOfIssue
    let underlyingLocaleOfIssue = ReadOptionalFieldOrdered true bs index 594 ReadUnderlyingLocaleOfIssue
    let underlyingRedemptionDate = ReadOptionalFieldOrdered true bs index 247 ReadUnderlyingRedemptionDate
    let underlyingStrikePrice = ReadOptionalFieldOrdered true bs index 316 ReadUnderlyingStrikePrice
    let underlyingStrikeCurrency = ReadOptionalFieldOrdered true bs index 941 ReadUnderlyingStrikeCurrency
    let underlyingOptAttribute = ReadOptionalFieldOrdered true bs index 317 ReadUnderlyingOptAttribute
    let underlyingContractMultiplier = ReadOptionalFieldOrdered true bs index 436 ReadUnderlyingContractMultiplier
    let underlyingCouponRate = ReadOptionalFieldOrdered true bs index 435 ReadUnderlyingCouponRate
    let underlyingSecurityExchange = ReadOptionalFieldOrdered true bs index 308 ReadUnderlyingSecurityExchange
    let underlyingIssuer = ReadOptionalFieldOrdered true bs index 306 ReadUnderlyingIssuer
    let encodedUnderlyingIssuer = ReadOptionalFieldOrdered true bs index 362 ReadEncodedUnderlyingIssuer
    let underlyingSecurityDesc = ReadOptionalFieldOrdered true bs index 307 ReadUnderlyingSecurityDesc
    let encodedUnderlyingSecurityDesc = ReadOptionalFieldOrdered true bs index 364 ReadEncodedUnderlyingSecurityDesc
    let underlyingCPProgram = ReadOptionalFieldOrdered true bs index 877 ReadUnderlyingCPProgram
    let underlyingCPRegType = ReadOptionalFieldOrdered true bs index 878 ReadUnderlyingCPRegType
    let underlyingCurrency = ReadOptionalFieldOrdered true bs index 318 ReadUnderlyingCurrency
    let underlyingQty = ReadOptionalFieldOrdered true bs index 879 ReadUnderlyingQty
    let underlyingPx = ReadOptionalFieldOrdered true bs index 810 ReadUnderlyingPx
    let underlyingDirtyPrice = ReadOptionalFieldOrdered true bs index 882 ReadUnderlyingDirtyPrice
    let underlyingEndPrice = ReadOptionalFieldOrdered true bs index 883 ReadUnderlyingEndPrice
    let underlyingStartValue = ReadOptionalFieldOrdered true bs index 884 ReadUnderlyingStartValue
    let underlyingCurrentValue = ReadOptionalFieldOrdered true bs index 885 ReadUnderlyingCurrentValue
    let underlyingEndValue = ReadOptionalFieldOrdered true bs index 886 ReadUnderlyingEndValue
    let noUnderlyingStipsGrp = ReadOptionalGroupOrdered true bs index 887 ReadNoUnderlyingStipsGrp
    let ci:UnderlyingInstrument = {
        UnderlyingSymbol = underlyingSymbol
        UnderlyingSymbolSfx = underlyingSymbolSfx
        UnderlyingSecurityID = underlyingSecurityID
        UnderlyingSecurityIDSource = underlyingSecurityIDSource
        NoUnderlyingSecurityAltIDGrp = noUnderlyingSecurityAltIDGrp
        UnderlyingProduct = underlyingProduct
        UnderlyingCFICode = underlyingCFICode
        UnderlyingSecurityType = underlyingSecurityType
        UnderlyingSecuritySubType = underlyingSecuritySubType
        UnderlyingMaturityMonthYear = underlyingMaturityMonthYear
        UnderlyingMaturityDate = underlyingMaturityDate
        UnderlyingPutOrCall = underlyingPutOrCall
        UnderlyingCouponPaymentDate = underlyingCouponPaymentDate
        UnderlyingIssueDate = underlyingIssueDate
        UnderlyingRepoCollateralSecurityType = underlyingRepoCollateralSecurityType
        UnderlyingRepurchaseTerm = underlyingRepurchaseTerm
        UnderlyingRepurchaseRate = underlyingRepurchaseRate
        UnderlyingFactor = underlyingFactor
        UnderlyingCreditRating = underlyingCreditRating
        UnderlyingInstrRegistry = underlyingInstrRegistry
        UnderlyingCountryOfIssue = underlyingCountryOfIssue
        UnderlyingStateOrProvinceOfIssue = underlyingStateOrProvinceOfIssue
        UnderlyingLocaleOfIssue = underlyingLocaleOfIssue
        UnderlyingRedemptionDate = underlyingRedemptionDate
        UnderlyingStrikePrice = underlyingStrikePrice
        UnderlyingStrikeCurrency = underlyingStrikeCurrency
        UnderlyingOptAttribute = underlyingOptAttribute
        UnderlyingContractMultiplier = underlyingContractMultiplier
        UnderlyingCouponRate = underlyingCouponRate
        UnderlyingSecurityExchange = underlyingSecurityExchange
        UnderlyingIssuer = underlyingIssuer
        EncodedUnderlyingIssuer = encodedUnderlyingIssuer
        UnderlyingSecurityDesc = underlyingSecurityDesc
        EncodedUnderlyingSecurityDesc = encodedUnderlyingSecurityDesc
        UnderlyingCPProgram = underlyingCPProgram
        UnderlyingCPRegType = underlyingCPRegType
        UnderlyingCurrency = underlyingCurrency
        UnderlyingQty = underlyingQty
        UnderlyingPx = underlyingPx
        UnderlyingDirtyPrice = underlyingDirtyPrice
        UnderlyingEndPrice = underlyingEndPrice
        UnderlyingStartValue = underlyingStartValue
        UnderlyingCurrentValue = underlyingCurrentValue
        UnderlyingEndValue = underlyingEndValue
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// group
let ReadCollateralResponseNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralResponseNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let collAction = ReadOptionalFieldOrdered true bs index 944 ReadCollAction
    let ci:CollateralResponseNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralAssignmentNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralAssignmentNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let collAction = ReadOptionalFieldOrdered true bs index 944 ReadCollAction
    let ci:CollateralAssignmentNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadCollateralRequestNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CollateralRequestNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let collAction = ReadOptionalFieldOrdered true bs index 944 ReadCollAction
    let ci:CollateralRequestNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        CollAction = collAction
    }
    ci


// group
let ReadPositionReportNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionReportNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let underlyingSettlPrice = ReadFieldOrdered true bs index 732 ReadUnderlyingSettlPrice
    let underlyingSettlPriceType = ReadFieldOrdered true bs index 733 ReadUnderlyingSettlPriceType
    let ci:PositionReportNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        UnderlyingSettlPrice = underlyingSettlPrice
        UnderlyingSettlPriceType = underlyingSettlPriceType
    }
    ci


// group
let ReadNoNestedPartySubIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartySubIDsGrp =
    let nestedPartySubID = ReadFieldOrdered true bs index 545 ReadNestedPartySubID
    let nestedPartySubIDType = ReadOptionalFieldOrdered true bs index 805 ReadNestedPartySubIDType
    let ci:NoNestedPartySubIDsGrp = {
        NestedPartySubID = nestedPartySubID
        NestedPartySubIDType = nestedPartySubIDType
    }
    ci


// group
let ReadNoNestedPartyIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNestedPartyIDsGrp =
    let nestedPartyID = ReadFieldOrdered true bs index 524 ReadNestedPartyID
    let nestedPartyIDSource = ReadOptionalFieldOrdered true bs index 525 ReadNestedPartyIDSource
    let nestedPartyRole = ReadOptionalFieldOrdered true bs index 538 ReadNestedPartyRole
    let noNestedPartySubIDsGrp = ReadOptionalGroupOrdered true bs index 804 ReadNoNestedPartySubIDsGrp
    let ci:NoNestedPartyIDsGrp = {
        NestedPartyID = nestedPartyID
        NestedPartyIDSource = nestedPartyIDSource
        NestedPartyRole = nestedPartyRole
        NoNestedPartySubIDsGrp = noNestedPartySubIDsGrp
    }
    ci


// group
let ReadNoPositionsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPositionsGrp =
    let posType = ReadFieldOrdered true bs index 703 ReadPosType
    let longQty = ReadOptionalFieldOrdered true bs index 704 ReadLongQty
    let shortQty = ReadOptionalFieldOrdered true bs index 705 ReadShortQty
    let posQtyStatus = ReadOptionalFieldOrdered true bs index 706 ReadPosQtyStatus
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let ci:NoPositionsGrp = {
        PosType = posType
        LongQty = longQty
        ShortQty = shortQty
        PosQtyStatus = posQtyStatus
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// component, random access reader
let ReadPositionQty (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionQty =
    let noPositionsGrp = ReadGroup bs index 702 ReadNoPositionsGrp
    let ci:PositionQty = {
        NoPositionsGrp = noPositionsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPositionQtyOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionQty =
    let noPositionsGrp = ReadGroup bs index 702 ReadNoPositionsGrp
    let ci:PositionQty = {
        NoPositionsGrp = noPositionsGrp
    }
    ci


// group
let ReadNoRegistDtlsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRegistDtlsGrp =
    let registDtls = ReadFieldOrdered true bs index 509 ReadRegistDtls
    let registEmail = ReadOptionalFieldOrdered true bs index 511 ReadRegistEmail
    let mailingDtls = ReadOptionalFieldOrdered true bs index 474 ReadMailingDtls
    let mailingInst = ReadOptionalFieldOrdered true bs index 482 ReadMailingInst
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let ownerType = ReadOptionalFieldOrdered true bs index 522 ReadOwnerType
    let dateOfBirth = ReadOptionalFieldOrdered true bs index 486 ReadDateOfBirth
    let investorCountryOfResidence = ReadOptionalFieldOrdered true bs index 475 ReadInvestorCountryOfResidence
    let ci:NoRegistDtlsGrp = {
        RegistDtls = registDtls
        RegistEmail = registEmail
        MailingDtls = mailingDtls
        MailingInst = mailingInst
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        OwnerType = ownerType
        DateOfBirth = dateOfBirth
        InvestorCountryOfResidence = investorCountryOfResidence
    }
    ci


// group
let ReadNoNested2PartySubIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested2PartySubIDsGrp =
    let nested2PartySubID = ReadFieldOrdered true bs index 760 ReadNested2PartySubID
    let nested2PartySubIDType = ReadOptionalFieldOrdered true bs index 807 ReadNested2PartySubIDType
    let ci:NoNested2PartySubIDsGrp = {
        Nested2PartySubID = nested2PartySubID
        Nested2PartySubIDType = nested2PartySubIDType
    }
    ci


// group
let ReadNoNested2PartyIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested2PartyIDsGrp =
    let nested2PartyID = ReadFieldOrdered true bs index 757 ReadNested2PartyID
    let nested2PartyIDSource = ReadOptionalFieldOrdered true bs index 758 ReadNested2PartyIDSource
    let nested2PartyRole = ReadOptionalFieldOrdered true bs index 759 ReadNested2PartyRole
    let noNested2PartySubIDsGrp = ReadOptionalGroupOrdered true bs index 806 ReadNoNested2PartySubIDsGrp
    let ci:NoNested2PartyIDsGrp = {
        Nested2PartyID = nested2PartyID
        Nested2PartyIDSource = nested2PartyIDSource
        Nested2PartyRole = nested2PartyRole
        NoNested2PartySubIDsGrp = noNested2PartySubIDsGrp
    }
    ci


// group
let ReadTradeCaptureReportAckNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrp
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQty
    let ci:TradeCaptureReportAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadNoLegSecurityAltIDGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegSecurityAltIDGrp =
    let legSecurityAltID = ReadFieldOrdered true bs index 605 ReadLegSecurityAltID
    let legSecurityAltIDSource = ReadOptionalFieldOrdered true bs index 606 ReadLegSecurityAltIDSource
    let ci:NoLegSecurityAltIDGrp = {
        LegSecurityAltID = legSecurityAltID
        LegSecurityAltIDSource = legSecurityAltIDSource
    }
    ci


// component, random access reader
let ReadInstrumentLegFG (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLegFG =
    let legSymbol = ReadField bs index 600 ReadLegSymbol
    let legSymbolSfx = ReadOptionalField bs index 601 ReadLegSymbolSfx
    let legSecurityID = ReadOptionalField bs index 602 ReadLegSecurityID
    let legSecurityIDSource = ReadOptionalField bs index 603 ReadLegSecurityIDSource
    let noLegSecurityAltIDGrp = ReadOptionalGroup bs index 604 ReadNoLegSecurityAltIDGrp
    let legProduct = ReadOptionalField bs index 607 ReadLegProduct
    let legCFICode = ReadOptionalField bs index 608 ReadLegCFICode
    let legSecurityType = ReadOptionalField bs index 609 ReadLegSecurityType
    let legSecuritySubType = ReadOptionalField bs index 764 ReadLegSecuritySubType
    let legMaturityMonthYear = ReadOptionalField bs index 610 ReadLegMaturityMonthYear
    let legMaturityDate = ReadOptionalField bs index 611 ReadLegMaturityDate
    let legCouponPaymentDate = ReadOptionalField bs index 248 ReadLegCouponPaymentDate
    let legIssueDate = ReadOptionalField bs index 249 ReadLegIssueDate
    let legRepoCollateralSecurityType = ReadOptionalField bs index 250 ReadLegRepoCollateralSecurityType
    let legRepurchaseTerm = ReadOptionalField bs index 251 ReadLegRepurchaseTerm
    let legRepurchaseRate = ReadOptionalField bs index 252 ReadLegRepurchaseRate
    let legFactor = ReadOptionalField bs index 253 ReadLegFactor
    let legCreditRating = ReadOptionalField bs index 257 ReadLegCreditRating
    let legInstrRegistry = ReadOptionalField bs index 599 ReadLegInstrRegistry
    let legCountryOfIssue = ReadOptionalField bs index 596 ReadLegCountryOfIssue
    let legStateOrProvinceOfIssue = ReadOptionalField bs index 597 ReadLegStateOrProvinceOfIssue
    let legLocaleOfIssue = ReadOptionalField bs index 598 ReadLegLocaleOfIssue
    let legRedemptionDate = ReadOptionalField bs index 254 ReadLegRedemptionDate
    let legStrikePrice = ReadOptionalField bs index 612 ReadLegStrikePrice
    let legStrikeCurrency = ReadOptionalField bs index 942 ReadLegStrikeCurrency
    let legOptAttribute = ReadOptionalField bs index 613 ReadLegOptAttribute
    let legContractMultiplier = ReadOptionalField bs index 614 ReadLegContractMultiplier
    let legCouponRate = ReadOptionalField bs index 615 ReadLegCouponRate
    let legSecurityExchange = ReadOptionalField bs index 616 ReadLegSecurityExchange
    let legIssuer = ReadOptionalField bs index 617 ReadLegIssuer
    let encodedLegIssuer = ReadOptionalField bs index 618 ReadEncodedLegIssuer
    let legSecurityDesc = ReadOptionalField bs index 620 ReadLegSecurityDesc
    let encodedLegSecurityDesc = ReadOptionalField bs index 621 ReadEncodedLegSecurityDesc
    let legRatioQty = ReadOptionalField bs index 623 ReadLegRatioQty
    let legSide = ReadOptionalField bs index 624 ReadLegSide
    let legCurrency = ReadOptionalField bs index 556 ReadLegCurrency
    let legPool = ReadOptionalField bs index 740 ReadLegPool
    let legDatedDate = ReadOptionalField bs index 739 ReadLegDatedDate
    let legContractSettlMonth = ReadOptionalField bs index 955 ReadLegContractSettlMonth
    let legInterestAccrualDate = ReadOptionalField bs index 956 ReadLegInterestAccrualDate
    let ci:InstrumentLegFG = {
        LegSymbol = legSymbol
        LegSymbolSfx = legSymbolSfx
        LegSecurityID = legSecurityID
        LegSecurityIDSource = legSecurityIDSource
        NoLegSecurityAltIDGrp = noLegSecurityAltIDGrp
        LegProduct = legProduct
        LegCFICode = legCFICode
        LegSecurityType = legSecurityType
        LegSecuritySubType = legSecuritySubType
        LegMaturityMonthYear = legMaturityMonthYear
        LegMaturityDate = legMaturityDate
        LegCouponPaymentDate = legCouponPaymentDate
        LegIssueDate = legIssueDate
        LegRepoCollateralSecurityType = legRepoCollateralSecurityType
        LegRepurchaseTerm = legRepurchaseTerm
        LegRepurchaseRate = legRepurchaseRate
        LegFactor = legFactor
        LegCreditRating = legCreditRating
        LegInstrRegistry = legInstrRegistry
        LegCountryOfIssue = legCountryOfIssue
        LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
        LegLocaleOfIssue = legLocaleOfIssue
        LegRedemptionDate = legRedemptionDate
        LegStrikePrice = legStrikePrice
        LegStrikeCurrency = legStrikeCurrency
        LegOptAttribute = legOptAttribute
        LegContractMultiplier = legContractMultiplier
        LegCouponRate = legCouponRate
        LegSecurityExchange = legSecurityExchange
        LegIssuer = legIssuer
        EncodedLegIssuer = encodedLegIssuer
        LegSecurityDesc = legSecurityDesc
        EncodedLegSecurityDesc = encodedLegSecurityDesc
        LegRatioQty = legRatioQty
        LegSide = legSide
        LegCurrency = legCurrency
        LegPool = legPool
        LegDatedDate = legDatedDate
        LegContractSettlMonth = legContractSettlMonth
        LegInterestAccrualDate = legInterestAccrualDate
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentLegFGOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLegFG =
    let legSymbol = ReadFieldOrdered true bs index 600 ReadLegSymbol
    let legSymbolSfx = ReadOptionalFieldOrdered true bs index 601 ReadLegSymbolSfx
    let legSecurityID = ReadOptionalFieldOrdered true bs index 602 ReadLegSecurityID
    let legSecurityIDSource = ReadOptionalFieldOrdered true bs index 603 ReadLegSecurityIDSource
    let noLegSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 604 ReadNoLegSecurityAltIDGrp
    let legProduct = ReadOptionalFieldOrdered true bs index 607 ReadLegProduct
    let legCFICode = ReadOptionalFieldOrdered true bs index 608 ReadLegCFICode
    let legSecurityType = ReadOptionalFieldOrdered true bs index 609 ReadLegSecurityType
    let legSecuritySubType = ReadOptionalFieldOrdered true bs index 764 ReadLegSecuritySubType
    let legMaturityMonthYear = ReadOptionalFieldOrdered true bs index 610 ReadLegMaturityMonthYear
    let legMaturityDate = ReadOptionalFieldOrdered true bs index 611 ReadLegMaturityDate
    let legCouponPaymentDate = ReadOptionalFieldOrdered true bs index 248 ReadLegCouponPaymentDate
    let legIssueDate = ReadOptionalFieldOrdered true bs index 249 ReadLegIssueDate
    let legRepoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 250 ReadLegRepoCollateralSecurityType
    let legRepurchaseTerm = ReadOptionalFieldOrdered true bs index 251 ReadLegRepurchaseTerm
    let legRepurchaseRate = ReadOptionalFieldOrdered true bs index 252 ReadLegRepurchaseRate
    let legFactor = ReadOptionalFieldOrdered true bs index 253 ReadLegFactor
    let legCreditRating = ReadOptionalFieldOrdered true bs index 257 ReadLegCreditRating
    let legInstrRegistry = ReadOptionalFieldOrdered true bs index 599 ReadLegInstrRegistry
    let legCountryOfIssue = ReadOptionalFieldOrdered true bs index 596 ReadLegCountryOfIssue
    let legStateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 597 ReadLegStateOrProvinceOfIssue
    let legLocaleOfIssue = ReadOptionalFieldOrdered true bs index 598 ReadLegLocaleOfIssue
    let legRedemptionDate = ReadOptionalFieldOrdered true bs index 254 ReadLegRedemptionDate
    let legStrikePrice = ReadOptionalFieldOrdered true bs index 612 ReadLegStrikePrice
    let legStrikeCurrency = ReadOptionalFieldOrdered true bs index 942 ReadLegStrikeCurrency
    let legOptAttribute = ReadOptionalFieldOrdered true bs index 613 ReadLegOptAttribute
    let legContractMultiplier = ReadOptionalFieldOrdered true bs index 614 ReadLegContractMultiplier
    let legCouponRate = ReadOptionalFieldOrdered true bs index 615 ReadLegCouponRate
    let legSecurityExchange = ReadOptionalFieldOrdered true bs index 616 ReadLegSecurityExchange
    let legIssuer = ReadOptionalFieldOrdered true bs index 617 ReadLegIssuer
    let encodedLegIssuer = ReadOptionalFieldOrdered true bs index 618 ReadEncodedLegIssuer
    let legSecurityDesc = ReadOptionalFieldOrdered true bs index 620 ReadLegSecurityDesc
    let encodedLegSecurityDesc = ReadOptionalFieldOrdered true bs index 621 ReadEncodedLegSecurityDesc
    let legRatioQty = ReadOptionalFieldOrdered true bs index 623 ReadLegRatioQty
    let legSide = ReadOptionalFieldOrdered true bs index 624 ReadLegSide
    let legCurrency = ReadOptionalFieldOrdered true bs index 556 ReadLegCurrency
    let legPool = ReadOptionalFieldOrdered true bs index 740 ReadLegPool
    let legDatedDate = ReadOptionalFieldOrdered true bs index 739 ReadLegDatedDate
    let legContractSettlMonth = ReadOptionalFieldOrdered true bs index 955 ReadLegContractSettlMonth
    let legInterestAccrualDate = ReadOptionalFieldOrdered true bs index 956 ReadLegInterestAccrualDate
    let ci:InstrumentLegFG = {
        LegSymbol = legSymbol
        LegSymbolSfx = legSymbolSfx
        LegSecurityID = legSecurityID
        LegSecurityIDSource = legSecurityIDSource
        NoLegSecurityAltIDGrp = noLegSecurityAltIDGrp
        LegProduct = legProduct
        LegCFICode = legCFICode
        LegSecurityType = legSecurityType
        LegSecuritySubType = legSecuritySubType
        LegMaturityMonthYear = legMaturityMonthYear
        LegMaturityDate = legMaturityDate
        LegCouponPaymentDate = legCouponPaymentDate
        LegIssueDate = legIssueDate
        LegRepoCollateralSecurityType = legRepoCollateralSecurityType
        LegRepurchaseTerm = legRepurchaseTerm
        LegRepurchaseRate = legRepurchaseRate
        LegFactor = legFactor
        LegCreditRating = legCreditRating
        LegInstrRegistry = legInstrRegistry
        LegCountryOfIssue = legCountryOfIssue
        LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
        LegLocaleOfIssue = legLocaleOfIssue
        LegRedemptionDate = legRedemptionDate
        LegStrikePrice = legStrikePrice
        LegStrikeCurrency = legStrikeCurrency
        LegOptAttribute = legOptAttribute
        LegContractMultiplier = legContractMultiplier
        LegCouponRate = legCouponRate
        LegSecurityExchange = legSecurityExchange
        LegIssuer = legIssuer
        EncodedLegIssuer = encodedLegIssuer
        LegSecurityDesc = legSecurityDesc
        EncodedLegSecurityDesc = encodedLegSecurityDesc
        LegRatioQty = legRatioQty
        LegSide = legSide
        LegCurrency = legCurrency
        LegPool = legPool
        LegDatedDate = legDatedDate
        LegContractSettlMonth = legContractSettlMonth
        LegInterestAccrualDate = legInterestAccrualDate
    }
    ci


// group
let ReadNoLegStipulationsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegStipulationsGrp =
    let legStipulationType = ReadFieldOrdered true bs index 688 ReadLegStipulationType
    let legStipulationValue = ReadOptionalFieldOrdered true bs index 689 ReadLegStipulationValue
    let ci:NoLegStipulationsGrp = {
        LegStipulationType = legStipulationType
        LegStipulationValue = legStipulationValue
    }
    ci


// group
let ReadTradeCaptureReportAckNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportAckNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffect
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncovered
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefID
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPrice
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let legLastPx = ReadOptionalFieldOrdered true bs index 637 ReadLegLastPx
    let ci:TradeCaptureReportAckNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        LegLastPx = legLastPx
    }
    ci


// group
let ReadNoPartySubIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPartySubIDsGrp =
    let partySubID = ReadFieldOrdered true bs index 523 ReadPartySubID
    let partySubIDType = ReadOptionalFieldOrdered true bs index 803 ReadPartySubIDType
    let ci:NoPartySubIDsGrp = {
        PartySubID = partySubID
        PartySubIDType = partySubIDType
    }
    ci


// group
let ReadNoPartyIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPartyIDsGrp =
    let partyID = ReadFieldOrdered true bs index 448 ReadPartyID
    let partyIDSource = ReadOptionalFieldOrdered true bs index 447 ReadPartyIDSource
    let partyRole = ReadOptionalFieldOrdered true bs index 452 ReadPartyRole
    let noPartySubIDsGrp = ReadOptionalGroupOrdered true bs index 802 ReadNoPartySubIDsGrp
    let ci:NoPartyIDsGrp = {
        PartyID = partyID
        PartyIDSource = partyIDSource
        PartyRole = partyRole
        NoPartySubIDsGrp = noPartySubIDsGrp
    }
    ci


// group
let ReadNoClearingInstructionsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoClearingInstructionsGrp =
    let clearingInstruction = ReadFieldOrdered true bs index 577 ReadClearingInstruction
    let ci:NoClearingInstructionsGrp = {
        ClearingInstruction = clearingInstruction
    }
    ci


// component, random access reader
let ReadCommissionData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionData =
    let commission = ReadOptionalField bs index 12 ReadCommission
    let commType = ReadOptionalField bs index 13 ReadCommType
    let commCurrency = ReadOptionalField bs index 479 ReadCommCurrency
    let fundRenewWaiv = ReadOptionalField bs index 497 ReadFundRenewWaiv
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadCommissionDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionData =
    let commission = ReadOptionalFieldOrdered true bs index 12 ReadCommission
    let commType = ReadOptionalFieldOrdered true bs index 13 ReadCommType
    let commCurrency = ReadOptionalFieldOrdered true bs index 479 ReadCommCurrency
    let fundRenewWaiv = ReadOptionalFieldOrdered true bs index 497 ReadFundRenewWaiv
    let ci:CommissionData = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadNoContAmtsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContAmtsGrp =
    let contAmtType = ReadFieldOrdered true bs index 519 ReadContAmtType
    let contAmtValue = ReadOptionalFieldOrdered true bs index 520 ReadContAmtValue
    let contAmtCurr = ReadOptionalFieldOrdered true bs index 521 ReadContAmtCurr
    let ci:NoContAmtsGrp = {
        ContAmtType = contAmtType
        ContAmtValue = contAmtValue
        ContAmtCurr = contAmtCurr
    }
    ci


// group
let ReadNoStipulationsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoStipulationsGrp =
    let stipulationType = ReadFieldOrdered true bs index 233 ReadStipulationType
    let stipulationValue = ReadOptionalFieldOrdered true bs index 234 ReadStipulationValue
    let ci:NoStipulationsGrp = {
        StipulationType = stipulationType
        StipulationValue = stipulationValue
    }
    ci


// group
let ReadNoMiscFeesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMiscFeesGrp =
    let miscFeeAmt = ReadFieldOrdered true bs index 137 ReadMiscFeeAmt
    let miscFeeCurr = ReadOptionalFieldOrdered true bs index 138 ReadMiscFeeCurr
    let miscFeeType = ReadOptionalFieldOrdered true bs index 139 ReadMiscFeeType
    let miscFeeBasis = ReadOptionalFieldOrdered true bs index 891 ReadMiscFeeBasis
    let ci:NoMiscFeesGrp = {
        MiscFeeAmt = miscFeeAmt
        MiscFeeCurr = miscFeeCurr
        MiscFeeType = miscFeeType
        MiscFeeBasis = miscFeeBasis
    }
    ci


// group
let ReadTradeCaptureReportNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrp
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQty
    let ci:TradeCaptureReportNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadTradeCaptureReportNoSidesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoSidesGrp =
    let side = ReadFieldOrdered true bs index 54 ReadSide
    let orderID = ReadFieldOrdered true bs index 37 ReadOrderID
    let secondaryOrderID = ReadOptionalFieldOrdered true bs index 198 ReadSecondaryOrderID
    let clOrdID = ReadOptionalFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let listID = ReadOptionalFieldOrdered true bs index 66 ReadListID
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountType
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCode
    let oddLot = ReadOptionalFieldOrdered true bs index 575 ReadOddLot
    let noClearingInstructionsGrp = ReadOptionalGroupOrdered true bs index 576 ReadNoClearingInstructionsGrp
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicator
    let tradeInputSource = ReadOptionalFieldOrdered true bs index 578 ReadTradeInputSource
    let tradeInputDevice = ReadOptionalFieldOrdered true bs index 579 ReadTradeInputDevice
    let orderInputDevice = ReadOptionalFieldOrdered true bs index 821 ReadOrderInputDevice
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let complianceID = ReadOptionalFieldOrdered true bs index 376 ReadComplianceID
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlag
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacity
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictions
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacity
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdType
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInst
    let transBkdTime = ReadOptionalFieldOrdered true bs index 483 ReadTransBkdTime
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let timeBracket = ReadOptionalFieldOrdered true bs index 943 ReadTimeBracket
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataOrdered
    let grossTradeAmt = ReadOptionalFieldOrdered true bs index 381 ReadGrossTradeAmt
    let numDaysInterest = ReadOptionalFieldOrdered true bs index 157 ReadNumDaysInterest
    let exDate = ReadOptionalFieldOrdered true bs index 230 ReadExDate
    let accruedInterestRate = ReadOptionalFieldOrdered true bs index 158 ReadAccruedInterestRate
    let accruedInterestAmt = ReadOptionalFieldOrdered true bs index 159 ReadAccruedInterestAmt
    let interestAtMaturity = ReadOptionalFieldOrdered true bs index 738 ReadInterestAtMaturity
    let endAccruedInterestAmt = ReadOptionalFieldOrdered true bs index 920 ReadEndAccruedInterestAmt
    let startCash = ReadOptionalFieldOrdered true bs index 921 ReadStartCash
    let endCash = ReadOptionalFieldOrdered true bs index 922 ReadEndCash
    let concession = ReadOptionalFieldOrdered true bs index 238 ReadConcession
    let totalTakedown = ReadOptionalFieldOrdered true bs index 237 ReadTotalTakedown
    let netMoney = ReadOptionalFieldOrdered true bs index 118 ReadNetMoney
    let settlCurrAmt = ReadOptionalFieldOrdered true bs index 119 ReadSettlCurrAmt
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrency
    let settlCurrFxRate = ReadOptionalFieldOrdered true bs index 155 ReadSettlCurrFxRate
    let settlCurrFxRateCalc = ReadOptionalFieldOrdered true bs index 156 ReadSettlCurrFxRateCalc
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffect
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let sideMultiLegReportingType = ReadOptionalFieldOrdered true bs index 752 ReadSideMultiLegReportingType
    let noContAmtsGrp = ReadOptionalGroupOrdered true bs index 518 ReadNoContAmtsGrp
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrp
    let noMiscFeesGrp = ReadOptionalGroupOrdered true bs index 136 ReadNoMiscFeesGrp
    let exchangeRule = ReadOptionalFieldOrdered true bs index 825 ReadExchangeRule
    let tradeAllocIndicator = ReadOptionalFieldOrdered true bs index 826 ReadTradeAllocIndicator
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethod
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocID
    let tradeCaptureReportNoAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadTradeCaptureReportNoAllocsGrp
    let ci:TradeCaptureReportNoSidesGrp = {
        Side = side
        OrderID = orderID
        SecondaryOrderID = secondaryOrderID
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ListID = listID
        NoPartyIDsGrp = noPartyIDsGrp
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        ProcessCode = processCode
        OddLot = oddLot
        NoClearingInstructionsGrp = noClearingInstructionsGrp
        ClearingFeeIndicator = clearingFeeIndicator
        TradeInputSource = tradeInputSource
        TradeInputDevice = tradeInputDevice
        OrderInputDevice = orderInputDevice
        Currency = currency
        ComplianceID = complianceID
        SolicitedFlag = solicitedFlag
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        OrdType = ordType
        ExecInst = execInst
        TransBkdTime = transBkdTime
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        TimeBracket = timeBracket
        CommissionData = commissionData
        GrossTradeAmt = grossTradeAmt
        NumDaysInterest = numDaysInterest
        ExDate = exDate
        AccruedInterestRate = accruedInterestRate
        AccruedInterestAmt = accruedInterestAmt
        InterestAtMaturity = interestAtMaturity
        EndAccruedInterestAmt = endAccruedInterestAmt
        StartCash = startCash
        EndCash = endCash
        Concession = concession
        TotalTakedown = totalTakedown
        NetMoney = netMoney
        SettlCurrAmt = settlCurrAmt
        SettlCurrency = settlCurrency
        SettlCurrFxRate = settlCurrFxRate
        SettlCurrFxRateCalc = settlCurrFxRateCalc
        PositionEffect = positionEffect
        Text = text
        EncodedText = encodedText
        SideMultiLegReportingType = sideMultiLegReportingType
        NoContAmtsGrp = noContAmtsGrp
        NoStipulationsGrp = noStipulationsGrp
        NoMiscFeesGrp = noMiscFeesGrp
        ExchangeRule = exchangeRule
        TradeAllocIndicator = tradeAllocIndicator
        PreallocMethod = preallocMethod
        AllocID = allocID
        TradeCaptureReportNoAllocsGrp = tradeCaptureReportNoAllocsGrp
    }
    ci


// group
let ReadTradeCaptureReportNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TradeCaptureReportNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffect
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncovered
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefID
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPrice
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let legLastPx = ReadOptionalFieldOrdered true bs index 637 ReadLegLastPx
    let ci:TradeCaptureReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        LegLastPx = legLastPx
    }
    ci


// group
let ReadNoPosAmtGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoPosAmtGrp =
    let posAmtType = ReadFieldOrdered true bs index 707 ReadPosAmtType
    let posAmt = ReadFieldOrdered true bs index 708 ReadPosAmt
    let ci:NoPosAmtGrp = {
        PosAmtType = posAmtType
        PosAmt = posAmt
    }
    ci


// component, random access reader
let ReadPositionAmountData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionAmountData =
    let noPosAmtGrp = ReadGroup bs index 753 ReadNoPosAmtGrp
    let ci:PositionAmountData = {
        NoPosAmtGrp = noPosAmtGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPositionAmountDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PositionAmountData =
    let noPosAmtGrp = ReadGroup bs index 753 ReadNoPosAmtGrp
    let ci:PositionAmountData = {
        NoPosAmtGrp = noPosAmtGrp
    }
    ci


// group
let ReadNoSettlPartySubIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartySubIDsGrp =
    let settlPartySubID = ReadFieldOrdered true bs index 785 ReadSettlPartySubID
    let settlPartySubIDType = ReadOptionalFieldOrdered true bs index 786 ReadSettlPartySubIDType
    let ci:NoSettlPartySubIDsGrp = {
        SettlPartySubID = settlPartySubID
        SettlPartySubIDType = settlPartySubIDType
    }
    ci


// group
let ReadNoSettlPartyIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlPartyIDsGrp =
    let settlPartyID = ReadFieldOrdered true bs index 782 ReadSettlPartyID
    let settlPartyIDSource = ReadOptionalFieldOrdered true bs index 783 ReadSettlPartyIDSource
    let settlPartyRole = ReadOptionalFieldOrdered true bs index 784 ReadSettlPartyRole
    let noSettlPartySubIDsGrp = ReadOptionalGroupOrdered true bs index 801 ReadNoSettlPartySubIDsGrp
    let ci:NoSettlPartyIDsGrp = {
        SettlPartyID = settlPartyID
        SettlPartyIDSource = settlPartyIDSource
        SettlPartyRole = settlPartyRole
        NoSettlPartySubIDsGrp = noSettlPartySubIDsGrp
    }
    ci


// group
let ReadNoDlvyInstGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDlvyInstGrp =
    let settlInstSource = ReadFieldOrdered true bs index 165 ReadSettlInstSource
    let dlvyInstType = ReadOptionalFieldOrdered true bs index 787 ReadDlvyInstType
    let noSettlPartyIDsGrp = ReadOptionalGroupOrdered true bs index 781 ReadNoSettlPartyIDsGrp
    let ci:NoDlvyInstGrp = {
        SettlInstSource = settlInstSource
        DlvyInstType = dlvyInstType
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// component, random access reader
let ReadSettlInstructionsData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlInstructionsData =
    let settlDeliveryType = ReadOptionalField bs index 172 ReadSettlDeliveryType
    let standInstDbType = ReadOptionalField bs index 169 ReadStandInstDbType
    let standInstDbName = ReadOptionalField bs index 170 ReadStandInstDbName
    let standInstDbID = ReadOptionalField bs index 171 ReadStandInstDbID
    let noDlvyInstGrp = ReadOptionalGroup bs index 85 ReadNoDlvyInstGrp
    let ci:SettlInstructionsData = {
        SettlDeliveryType = settlDeliveryType
        StandInstDbType = standInstDbType
        StandInstDbName = standInstDbName
        StandInstDbID = standInstDbID
        NoDlvyInstGrp = noDlvyInstGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadSettlInstructionsDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlInstructionsData =
    let settlDeliveryType = ReadOptionalFieldOrdered true bs index 172 ReadSettlDeliveryType
    let standInstDbType = ReadOptionalFieldOrdered true bs index 169 ReadStandInstDbType
    let standInstDbName = ReadOptionalFieldOrdered true bs index 170 ReadStandInstDbName
    let standInstDbID = ReadOptionalFieldOrdered true bs index 171 ReadStandInstDbID
    let noDlvyInstGrp = ReadOptionalGroupOrdered true bs index 85 ReadNoDlvyInstGrp
    let ci:SettlInstructionsData = {
        SettlDeliveryType = settlDeliveryType
        StandInstDbType = standInstDbType
        StandInstDbName = standInstDbName
        StandInstDbID = standInstDbID
        NoDlvyInstGrp = noDlvyInstGrp
    }
    ci


// group
let ReadNoSettlInstGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSettlInstGrp =
    let settlInstID = ReadFieldOrdered true bs index 162 ReadSettlInstID
    let settlInstTransType = ReadOptionalFieldOrdered true bs index 163 ReadSettlInstTransType
    let settlInstRefID = ReadOptionalFieldOrdered true bs index 214 ReadSettlInstRefID
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSide
    let product = ReadOptionalFieldOrdered true bs index 460 ReadProduct
    let securityType = ReadOptionalFieldOrdered true bs index 167 ReadSecurityType
    let cFICode = ReadOptionalFieldOrdered true bs index 461 ReadCFICode
    let effectiveTime = ReadOptionalFieldOrdered true bs index 168 ReadEffectiveTime
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTime
    let lastUpdateTime = ReadOptionalFieldOrdered true bs index 779 ReadLastUpdateTime
    let settlInstructionsData = ReadComponentOrdered true bs index ReadSettlInstructionsDataOrdered
    let paymentMethod = ReadOptionalFieldOrdered true bs index 492 ReadPaymentMethod
    let paymentRef = ReadOptionalFieldOrdered true bs index 476 ReadPaymentRef
    let cardHolderName = ReadOptionalFieldOrdered true bs index 488 ReadCardHolderName
    let cardNumber = ReadOptionalFieldOrdered true bs index 489 ReadCardNumber
    let cardStartDate = ReadOptionalFieldOrdered true bs index 503 ReadCardStartDate
    let cardExpDate = ReadOptionalFieldOrdered true bs index 490 ReadCardExpDate
    let cardIssNum = ReadOptionalFieldOrdered true bs index 491 ReadCardIssNum
    let paymentDate = ReadOptionalFieldOrdered true bs index 504 ReadPaymentDate
    let paymentRemitterID = ReadOptionalFieldOrdered true bs index 505 ReadPaymentRemitterID
    let ci:NoSettlInstGrp = {
        SettlInstID = settlInstID
        SettlInstTransType = settlInstTransType
        SettlInstRefID = settlInstRefID
        NoPartyIDsGrp = noPartyIDsGrp
        Side = side
        Product = product
        SecurityType = securityType
        CFICode = cFICode
        EffectiveTime = effectiveTime
        ExpireTime = expireTime
        LastUpdateTime = lastUpdateTime
        SettlInstructionsData = settlInstructionsData
        PaymentMethod = paymentMethod
        PaymentRef = paymentRef
        CardHolderName = cardHolderName
        CardNumber = cardNumber
        CardStartDate = cardStartDate
        CardExpDate = cardExpDate
        CardIssNum = cardIssNum
        PaymentDate = paymentDate
        PaymentRemitterID = paymentRemitterID
    }
    ci


// group
let ReadNoTrdRegTimestampsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTrdRegTimestampsGrp =
    let trdRegTimestamp = ReadFieldOrdered true bs index 769 ReadTrdRegTimestamp
    let trdRegTimestampType = ReadOptionalFieldOrdered true bs index 770 ReadTrdRegTimestampType
    let trdRegTimestampOrigin = ReadOptionalFieldOrdered true bs index 771 ReadTrdRegTimestampOrigin
    let ci:NoTrdRegTimestampsGrp = {
        TrdRegTimestamp = trdRegTimestamp
        TrdRegTimestampType = trdRegTimestampType
        TrdRegTimestampOrigin = trdRegTimestampOrigin
    }
    ci


// component, random access reader
let ReadTrdRegTimestamps (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TrdRegTimestamps =
    let noTrdRegTimestampsGrp = ReadGroup bs index 768 ReadNoTrdRegTimestampsGrp
    let ci:TrdRegTimestamps = {
        NoTrdRegTimestampsGrp = noTrdRegTimestampsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadTrdRegTimestampsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : TrdRegTimestamps =
    let noTrdRegTimestampsGrp = ReadGroup bs index 768 ReadNoTrdRegTimestampsGrp
    let ci:TrdRegTimestamps = {
        NoTrdRegTimestampsGrp = noTrdRegTimestampsGrp
    }
    ci


// group
let ReadAllocationReportNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let matchStatus = ReadOptionalFieldOrdered true bs index 573 ReadMatchStatus
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPrice
    let allocQty = ReadFieldOrdered true bs index 80 ReadAllocQty
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCode
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let notifyBrokerOfCredit = ReadOptionalFieldOrdered true bs index 208 ReadNotifyBrokerOfCredit
    let allocHandlInst = ReadOptionalFieldOrdered true bs index 209 ReadAllocHandlInst
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocText
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocText
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataOrdered
    let allocAvgPx = ReadOptionalFieldOrdered true bs index 153 ReadAllocAvgPx
    let allocNetMoney = ReadOptionalFieldOrdered true bs index 154 ReadAllocNetMoney
    let settlCurrAmt = ReadOptionalFieldOrdered true bs index 119 ReadSettlCurrAmt
    let allocSettlCurrAmt = ReadOptionalFieldOrdered true bs index 737 ReadAllocSettlCurrAmt
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrency
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let settlCurrFxRate = ReadOptionalFieldOrdered true bs index 155 ReadSettlCurrFxRate
    let settlCurrFxRateCalc = ReadOptionalFieldOrdered true bs index 156 ReadSettlCurrFxRateCalc
    let allocAccruedInterestAmt = ReadOptionalFieldOrdered true bs index 742 ReadAllocAccruedInterestAmt
    let allocInterestAtMaturity = ReadOptionalFieldOrdered true bs index 741 ReadAllocInterestAtMaturity
    let noMiscFeesGrp = ReadOptionalGroupOrdered true bs index 136 ReadNoMiscFeesGrp
    let noClearingInstructionsGrp = ReadOptionalGroupOrdered true bs index 576 ReadNoClearingInstructionsGrp
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicator
    let allocSettlInstType = ReadOptionalFieldOrdered true bs index 780 ReadAllocSettlInstType
    let settlInstructionsData = ReadComponentOrdered true bs index ReadSettlInstructionsDataOrdered
    let ci:AllocationReportNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        MatchStatus = matchStatus
        AllocPrice = allocPrice
        AllocQty = allocQty
        IndividualAllocID = individualAllocID
        ProcessCode = processCode
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        NotifyBrokerOfCredit = notifyBrokerOfCredit
        AllocHandlInst = allocHandlInst
        AllocText = allocText
        EncodedAllocText = encodedAllocText
        CommissionData = commissionData
        AllocAvgPx = allocAvgPx
        AllocNetMoney = allocNetMoney
        SettlCurrAmt = settlCurrAmt
        AllocSettlCurrAmt = allocSettlCurrAmt
        SettlCurrency = settlCurrency
        AllocSettlCurrency = allocSettlCurrency
        SettlCurrFxRate = settlCurrFxRate
        SettlCurrFxRateCalc = settlCurrFxRateCalc
        AllocAccruedInterestAmt = allocAccruedInterestAmt
        AllocInterestAtMaturity = allocInterestAtMaturity
        NoMiscFeesGrp = noMiscFeesGrp
        NoClearingInstructionsGrp = noClearingInstructionsGrp
        ClearingFeeIndicator = clearingFeeIndicator
        AllocSettlInstType = allocSettlInstType
        SettlInstructionsData = settlInstructionsData
    }
    ci


// group
let ReadAllocationInstructionNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationInstructionNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let matchStatus = ReadOptionalFieldOrdered true bs index 573 ReadMatchStatus
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPrice
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQty
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCode
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let notifyBrokerOfCredit = ReadOptionalFieldOrdered true bs index 208 ReadNotifyBrokerOfCredit
    let allocHandlInst = ReadOptionalFieldOrdered true bs index 209 ReadAllocHandlInst
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocText
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocText
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataOrdered
    let allocAvgPx = ReadOptionalFieldOrdered true bs index 153 ReadAllocAvgPx
    let allocNetMoney = ReadOptionalFieldOrdered true bs index 154 ReadAllocNetMoney
    let settlCurrAmt = ReadOptionalFieldOrdered true bs index 119 ReadSettlCurrAmt
    let allocSettlCurrAmt = ReadOptionalFieldOrdered true bs index 737 ReadAllocSettlCurrAmt
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrency
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let settlCurrFxRate = ReadOptionalFieldOrdered true bs index 155 ReadSettlCurrFxRate
    let settlCurrFxRateCalc = ReadOptionalFieldOrdered true bs index 156 ReadSettlCurrFxRateCalc
    let accruedInterestAmt = ReadOptionalFieldOrdered true bs index 159 ReadAccruedInterestAmt
    let allocAccruedInterestAmt = ReadOptionalFieldOrdered true bs index 742 ReadAllocAccruedInterestAmt
    let allocInterestAtMaturity = ReadOptionalFieldOrdered true bs index 741 ReadAllocInterestAtMaturity
    let settlInstMode = ReadOptionalFieldOrdered true bs index 160 ReadSettlInstMode
    let noMiscFeesGrp = ReadOptionalGroupOrdered true bs index 136 ReadNoMiscFeesGrp
    let noClearingInstructions = ReadOptionalFieldOrdered true bs index 576 ReadNoClearingInstructions
    let clearingInstruction = ReadOptionalFieldOrdered true bs index 577 ReadClearingInstruction
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicator
    let allocSettlInstType = ReadOptionalFieldOrdered true bs index 780 ReadAllocSettlInstType
    let settlInstructionsData = ReadComponentOrdered true bs index ReadSettlInstructionsDataOrdered
    let ci:AllocationInstructionNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        MatchStatus = matchStatus
        AllocPrice = allocPrice
        AllocQty = allocQty
        IndividualAllocID = individualAllocID
        ProcessCode = processCode
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        NotifyBrokerOfCredit = notifyBrokerOfCredit
        AllocHandlInst = allocHandlInst
        AllocText = allocText
        EncodedAllocText = encodedAllocText
        CommissionData = commissionData
        AllocAvgPx = allocAvgPx
        AllocNetMoney = allocNetMoney
        SettlCurrAmt = settlCurrAmt
        AllocSettlCurrAmt = allocSettlCurrAmt
        SettlCurrency = settlCurrency
        AllocSettlCurrency = allocSettlCurrency
        SettlCurrFxRate = settlCurrFxRate
        SettlCurrFxRateCalc = settlCurrFxRateCalc
        AccruedInterestAmt = accruedInterestAmt
        AllocAccruedInterestAmt = allocAccruedInterestAmt
        AllocInterestAtMaturity = allocInterestAtMaturity
        SettlInstMode = settlInstMode
        NoMiscFeesGrp = noMiscFeesGrp
        NoClearingInstructions = noClearingInstructions
        ClearingInstruction = clearingInstruction
        ClearingFeeIndicator = clearingFeeIndicator
        AllocSettlInstType = allocSettlInstType
        SettlInstructionsData = settlInstructionsData
    }
    ci


// component, random access reader
let ReadSettlParties (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlParties =
    let noSettlPartyIDsGrp = ReadOptionalGroup bs index 781 ReadNoSettlPartyIDsGrp
    let ci:SettlParties = {
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadSettlPartiesOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SettlParties =
    let noSettlPartyIDsGrp = ReadOptionalGroupOrdered true bs index 781 ReadNoSettlPartyIDsGrp
    let ci:SettlParties = {
        NoSettlPartyIDsGrp = noSettlPartyIDsGrp
    }
    ci


// group
let ReadNoOrdersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoOrdersGrp =
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdID
    let orderID = ReadOptionalFieldOrdered true bs index 37 ReadOrderID
    let secondaryOrderID = ReadOptionalFieldOrdered true bs index 198 ReadSecondaryOrderID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let listID = ReadOptionalFieldOrdered true bs index 66 ReadListID
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrp
    let orderQty = ReadOptionalFieldOrdered true bs index 38 ReadOrderQty
    let orderAvgPx = ReadOptionalFieldOrdered true bs index 799 ReadOrderAvgPx
    let orderBookingQty = ReadOptionalFieldOrdered true bs index 800 ReadOrderBookingQty
    let ci:NoOrdersGrp = {
        ClOrdID = clOrdID
        OrderID = orderID
        SecondaryOrderID = secondaryOrderID
        SecondaryClOrdID = secondaryClOrdID
        ListID = listID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        OrderQty = orderQty
        OrderAvgPx = orderAvgPx
        OrderBookingQty = orderBookingQty
    }
    ci


// group
let ReadListStrikePriceNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : ListStrikePriceNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePx
    let clOrdID = ReadOptionalFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSide
    let price = ReadFieldOrdered true bs index 44 ReadPrice
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:ListStrikePriceNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
        PrevClosePx = prevClosePx
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        Side = side
        Price = price
        Currency = currency
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoSecurityAltIDGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSecurityAltIDGrp =
    let securityAltID = ReadFieldOrdered true bs index 455 ReadSecurityAltID
    let securityAltIDSource = ReadOptionalFieldOrdered true bs index 456 ReadSecurityAltIDSource
    let ci:NoSecurityAltIDGrp = {
        SecurityAltID = securityAltID
        SecurityAltIDSource = securityAltIDSource
    }
    ci


// group
let ReadNoEventsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoEventsGrp =
    let eventType = ReadFieldOrdered true bs index 865 ReadEventType
    let eventDate = ReadOptionalFieldOrdered true bs index 866 ReadEventDate
    let eventPx = ReadOptionalFieldOrdered true bs index 867 ReadEventPx
    let eventText = ReadOptionalFieldOrdered true bs index 868 ReadEventText
    let ci:NoEventsGrp = {
        EventType = eventType
        EventDate = eventDate
        EventPx = eventPx
        EventText = eventText
    }
    ci


// component, random access reader
let ReadInstrument (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Instrument =
    let symbol = ReadField bs index 55 ReadSymbol
    let symbolSfx = ReadOptionalField bs index 65 ReadSymbolSfx
    let securityID = ReadOptionalField bs index 48 ReadSecurityID
    let securityIDSource = ReadOptionalField bs index 22 ReadSecurityIDSource
    let noSecurityAltIDGrp = ReadOptionalGroup bs index 454 ReadNoSecurityAltIDGrp
    let product = ReadOptionalField bs index 460 ReadProduct
    let cFICode = ReadOptionalField bs index 461 ReadCFICode
    let securityType = ReadOptionalField bs index 167 ReadSecurityType
    let securitySubType = ReadOptionalField bs index 762 ReadSecuritySubType
    let maturityMonthYear = ReadOptionalField bs index 200 ReadMaturityMonthYear
    let maturityDate = ReadOptionalField bs index 541 ReadMaturityDate
    let putOrCall = ReadOptionalField bs index 201 ReadPutOrCall
    let couponPaymentDate = ReadOptionalField bs index 224 ReadCouponPaymentDate
    let issueDate = ReadOptionalField bs index 225 ReadIssueDate
    let repoCollateralSecurityType = ReadOptionalField bs index 239 ReadRepoCollateralSecurityType
    let repurchaseTerm = ReadOptionalField bs index 226 ReadRepurchaseTerm
    let repurchaseRate = ReadOptionalField bs index 227 ReadRepurchaseRate
    let factor = ReadOptionalField bs index 228 ReadFactor
    let creditRating = ReadOptionalField bs index 255 ReadCreditRating
    let instrRegistry = ReadOptionalField bs index 543 ReadInstrRegistry
    let countryOfIssue = ReadOptionalField bs index 470 ReadCountryOfIssue
    let stateOrProvinceOfIssue = ReadOptionalField bs index 471 ReadStateOrProvinceOfIssue
    let localeOfIssue = ReadOptionalField bs index 472 ReadLocaleOfIssue
    let redemptionDate = ReadOptionalField bs index 240 ReadRedemptionDate
    let strikePrice = ReadOptionalField bs index 202 ReadStrikePrice
    let strikeCurrency = ReadOptionalField bs index 947 ReadStrikeCurrency
    let optAttribute = ReadOptionalField bs index 206 ReadOptAttribute
    let contractMultiplier = ReadOptionalField bs index 231 ReadContractMultiplier
    let couponRate = ReadOptionalField bs index 223 ReadCouponRate
    let securityExchange = ReadOptionalField bs index 207 ReadSecurityExchange
    let issuer = ReadOptionalField bs index 106 ReadIssuer
    let encodedIssuer = ReadOptionalField bs index 348 ReadEncodedIssuer
    let securityDesc = ReadOptionalField bs index 107 ReadSecurityDesc
    let encodedSecurityDesc = ReadOptionalField bs index 350 ReadEncodedSecurityDesc
    let pool = ReadOptionalField bs index 691 ReadPool
    let contractSettlMonth = ReadOptionalField bs index 667 ReadContractSettlMonth
    let cPProgram = ReadOptionalField bs index 875 ReadCPProgram
    let cPRegType = ReadOptionalField bs index 876 ReadCPRegType
    let noEventsGrp = ReadOptionalGroup bs index 864 ReadNoEventsGrp
    let datedDate = ReadOptionalField bs index 873 ReadDatedDate
    let interestAccrualDate = ReadOptionalField bs index 874 ReadInterestAccrualDate
    let ci:Instrument = {
        Symbol = symbol
        SymbolSfx = symbolSfx
        SecurityID = securityID
        SecurityIDSource = securityIDSource
        NoSecurityAltIDGrp = noSecurityAltIDGrp
        Product = product
        CFICode = cFICode
        SecurityType = securityType
        SecuritySubType = securitySubType
        MaturityMonthYear = maturityMonthYear
        MaturityDate = maturityDate
        PutOrCall = putOrCall
        CouponPaymentDate = couponPaymentDate
        IssueDate = issueDate
        RepoCollateralSecurityType = repoCollateralSecurityType
        RepurchaseTerm = repurchaseTerm
        RepurchaseRate = repurchaseRate
        Factor = factor
        CreditRating = creditRating
        InstrRegistry = instrRegistry
        CountryOfIssue = countryOfIssue
        StateOrProvinceOfIssue = stateOrProvinceOfIssue
        LocaleOfIssue = localeOfIssue
        RedemptionDate = redemptionDate
        StrikePrice = strikePrice
        StrikeCurrency = strikeCurrency
        OptAttribute = optAttribute
        ContractMultiplier = contractMultiplier
        CouponRate = couponRate
        SecurityExchange = securityExchange
        Issuer = issuer
        EncodedIssuer = encodedIssuer
        SecurityDesc = securityDesc
        EncodedSecurityDesc = encodedSecurityDesc
        Pool = pool
        ContractSettlMonth = contractSettlMonth
        CPProgram = cPProgram
        CPRegType = cPRegType
        NoEventsGrp = noEventsGrp
        DatedDate = datedDate
        InterestAccrualDate = interestAccrualDate
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Instrument =
    let symbol = ReadFieldOrdered true bs index 55 ReadSymbol
    let symbolSfx = ReadOptionalFieldOrdered true bs index 65 ReadSymbolSfx
    let securityID = ReadOptionalFieldOrdered true bs index 48 ReadSecurityID
    let securityIDSource = ReadOptionalFieldOrdered true bs index 22 ReadSecurityIDSource
    let noSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 454 ReadNoSecurityAltIDGrp
    let product = ReadOptionalFieldOrdered true bs index 460 ReadProduct
    let cFICode = ReadOptionalFieldOrdered true bs index 461 ReadCFICode
    let securityType = ReadOptionalFieldOrdered true bs index 167 ReadSecurityType
    let securitySubType = ReadOptionalFieldOrdered true bs index 762 ReadSecuritySubType
    let maturityMonthYear = ReadOptionalFieldOrdered true bs index 200 ReadMaturityMonthYear
    let maturityDate = ReadOptionalFieldOrdered true bs index 541 ReadMaturityDate
    let putOrCall = ReadOptionalFieldOrdered true bs index 201 ReadPutOrCall
    let couponPaymentDate = ReadOptionalFieldOrdered true bs index 224 ReadCouponPaymentDate
    let issueDate = ReadOptionalFieldOrdered true bs index 225 ReadIssueDate
    let repoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 239 ReadRepoCollateralSecurityType
    let repurchaseTerm = ReadOptionalFieldOrdered true bs index 226 ReadRepurchaseTerm
    let repurchaseRate = ReadOptionalFieldOrdered true bs index 227 ReadRepurchaseRate
    let factor = ReadOptionalFieldOrdered true bs index 228 ReadFactor
    let creditRating = ReadOptionalFieldOrdered true bs index 255 ReadCreditRating
    let instrRegistry = ReadOptionalFieldOrdered true bs index 543 ReadInstrRegistry
    let countryOfIssue = ReadOptionalFieldOrdered true bs index 470 ReadCountryOfIssue
    let stateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 471 ReadStateOrProvinceOfIssue
    let localeOfIssue = ReadOptionalFieldOrdered true bs index 472 ReadLocaleOfIssue
    let redemptionDate = ReadOptionalFieldOrdered true bs index 240 ReadRedemptionDate
    let strikePrice = ReadOptionalFieldOrdered true bs index 202 ReadStrikePrice
    let strikeCurrency = ReadOptionalFieldOrdered true bs index 947 ReadStrikeCurrency
    let optAttribute = ReadOptionalFieldOrdered true bs index 206 ReadOptAttribute
    let contractMultiplier = ReadOptionalFieldOrdered true bs index 231 ReadContractMultiplier
    let couponRate = ReadOptionalFieldOrdered true bs index 223 ReadCouponRate
    let securityExchange = ReadOptionalFieldOrdered true bs index 207 ReadSecurityExchange
    let issuer = ReadOptionalFieldOrdered true bs index 106 ReadIssuer
    let encodedIssuer = ReadOptionalFieldOrdered true bs index 348 ReadEncodedIssuer
    let securityDesc = ReadOptionalFieldOrdered true bs index 107 ReadSecurityDesc
    let encodedSecurityDesc = ReadOptionalFieldOrdered true bs index 350 ReadEncodedSecurityDesc
    let pool = ReadOptionalFieldOrdered true bs index 691 ReadPool
    let contractSettlMonth = ReadOptionalFieldOrdered true bs index 667 ReadContractSettlMonth
    let cPProgram = ReadOptionalFieldOrdered true bs index 875 ReadCPProgram
    let cPRegType = ReadOptionalFieldOrdered true bs index 876 ReadCPRegType
    let noEventsGrp = ReadOptionalGroupOrdered true bs index 864 ReadNoEventsGrp
    let datedDate = ReadOptionalFieldOrdered true bs index 873 ReadDatedDate
    let interestAccrualDate = ReadOptionalFieldOrdered true bs index 874 ReadInterestAccrualDate
    let ci:Instrument = {
        Symbol = symbol
        SymbolSfx = symbolSfx
        SecurityID = securityID
        SecurityIDSource = securityIDSource
        NoSecurityAltIDGrp = noSecurityAltIDGrp
        Product = product
        CFICode = cFICode
        SecurityType = securityType
        SecuritySubType = securitySubType
        MaturityMonthYear = maturityMonthYear
        MaturityDate = maturityDate
        PutOrCall = putOrCall
        CouponPaymentDate = couponPaymentDate
        IssueDate = issueDate
        RepoCollateralSecurityType = repoCollateralSecurityType
        RepurchaseTerm = repurchaseTerm
        RepurchaseRate = repurchaseRate
        Factor = factor
        CreditRating = creditRating
        InstrRegistry = instrRegistry
        CountryOfIssue = countryOfIssue
        StateOrProvinceOfIssue = stateOrProvinceOfIssue
        LocaleOfIssue = localeOfIssue
        RedemptionDate = redemptionDate
        StrikePrice = strikePrice
        StrikeCurrency = strikeCurrency
        OptAttribute = optAttribute
        ContractMultiplier = contractMultiplier
        CouponRate = couponRate
        SecurityExchange = securityExchange
        Issuer = issuer
        EncodedIssuer = encodedIssuer
        SecurityDesc = securityDesc
        EncodedSecurityDesc = encodedSecurityDesc
        Pool = pool
        ContractSettlMonth = contractSettlMonth
        CPProgram = cPProgram
        CPRegType = cPRegType
        NoEventsGrp = noEventsGrp
        DatedDate = datedDate
        InterestAccrualDate = interestAccrualDate
    }
    ci


// group
let ReadNoStrikesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoStrikesGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let ci:NoStrikesGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQty
    let ci:NoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadNoTradingSessionsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTradingSessionsGrp =
    let tradingSessionID = ReadFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let ci:NoTradingSessionsGrp = {
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    ci


// group
let ReadNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let ci:NoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component, random access reader
let ReadOrderQtyData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : OrderQtyData =
    let orderQty = ReadOptionalField bs index 38 ReadOrderQty
    let cashOrderQty = ReadOptionalField bs index 152 ReadCashOrderQty
    let orderPercent = ReadOptionalField bs index 516 ReadOrderPercent
    let roundingDirection = ReadOptionalField bs index 468 ReadRoundingDirection
    let roundingModulus = ReadOptionalField bs index 469 ReadRoundingModulus
    let ci:OrderQtyData = {
        OrderQty = orderQty
        CashOrderQty = cashOrderQty
        OrderPercent = orderPercent
        RoundingDirection = roundingDirection
        RoundingModulus = roundingModulus
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadOrderQtyDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : OrderQtyData =
    let orderQty = ReadOptionalFieldOrdered true bs index 38 ReadOrderQty
    let cashOrderQty = ReadOptionalFieldOrdered true bs index 152 ReadCashOrderQty
    let orderPercent = ReadOptionalFieldOrdered true bs index 516 ReadOrderPercent
    let roundingDirection = ReadOptionalFieldOrdered true bs index 468 ReadRoundingDirection
    let roundingModulus = ReadOptionalFieldOrdered true bs index 469 ReadRoundingModulus
    let ci:OrderQtyData = {
        OrderQty = orderQty
        CashOrderQty = cashOrderQty
        OrderPercent = orderPercent
        RoundingDirection = roundingDirection
        RoundingModulus = roundingModulus
    }
    ci


// component, random access reader
let ReadSpreadOrBenchmarkCurveData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SpreadOrBenchmarkCurveData =
    let spread = ReadOptionalField bs index 218 ReadSpread
    let benchmarkCurveCurrency = ReadOptionalField bs index 220 ReadBenchmarkCurveCurrency
    let benchmarkCurveName = ReadOptionalField bs index 221 ReadBenchmarkCurveName
    let benchmarkCurvePoint = ReadOptionalField bs index 222 ReadBenchmarkCurvePoint
    let benchmarkPrice = ReadOptionalField bs index 662 ReadBenchmarkPrice
    let benchmarkPriceType = ReadOptionalField bs index 663 ReadBenchmarkPriceType
    let benchmarkSecurityID = ReadOptionalField bs index 699 ReadBenchmarkSecurityID
    let benchmarkSecurityIDSource = ReadOptionalField bs index 761 ReadBenchmarkSecurityIDSource
    let ci:SpreadOrBenchmarkCurveData = {
        Spread = spread
        BenchmarkCurveCurrency = benchmarkCurveCurrency
        BenchmarkCurveName = benchmarkCurveName
        BenchmarkCurvePoint = benchmarkCurvePoint
        BenchmarkPrice = benchmarkPrice
        BenchmarkPriceType = benchmarkPriceType
        BenchmarkSecurityID = benchmarkSecurityID
        BenchmarkSecurityIDSource = benchmarkSecurityIDSource
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadSpreadOrBenchmarkCurveDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SpreadOrBenchmarkCurveData =
    let spread = ReadOptionalFieldOrdered true bs index 218 ReadSpread
    let benchmarkCurveCurrency = ReadOptionalFieldOrdered true bs index 220 ReadBenchmarkCurveCurrency
    let benchmarkCurveName = ReadOptionalFieldOrdered true bs index 221 ReadBenchmarkCurveName
    let benchmarkCurvePoint = ReadOptionalFieldOrdered true bs index 222 ReadBenchmarkCurvePoint
    let benchmarkPrice = ReadOptionalFieldOrdered true bs index 662 ReadBenchmarkPrice
    let benchmarkPriceType = ReadOptionalFieldOrdered true bs index 663 ReadBenchmarkPriceType
    let benchmarkSecurityID = ReadOptionalFieldOrdered true bs index 699 ReadBenchmarkSecurityID
    let benchmarkSecurityIDSource = ReadOptionalFieldOrdered true bs index 761 ReadBenchmarkSecurityIDSource
    let ci:SpreadOrBenchmarkCurveData = {
        Spread = spread
        BenchmarkCurveCurrency = benchmarkCurveCurrency
        BenchmarkCurveName = benchmarkCurveName
        BenchmarkCurvePoint = benchmarkCurvePoint
        BenchmarkPrice = benchmarkPrice
        BenchmarkPriceType = benchmarkPriceType
        BenchmarkSecurityID = benchmarkSecurityID
        BenchmarkSecurityIDSource = benchmarkSecurityIDSource
    }
    ci


// component, random access reader
let ReadYieldData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : YieldData =
    let yieldType = ReadOptionalField bs index 235 ReadYieldType
    let yyield = ReadOptionalField bs index 236 ReadYield
    let yieldCalcDate = ReadOptionalField bs index 701 ReadYieldCalcDate
    let yieldRedemptionDate = ReadOptionalField bs index 696 ReadYieldRedemptionDate
    let yieldRedemptionPrice = ReadOptionalField bs index 697 ReadYieldRedemptionPrice
    let yieldRedemptionPriceType = ReadOptionalField bs index 698 ReadYieldRedemptionPriceType
    let ci:YieldData = {
        YieldType = yieldType
        Yield = yyield
        YieldCalcDate = yieldCalcDate
        YieldRedemptionDate = yieldRedemptionDate
        YieldRedemptionPrice = yieldRedemptionPrice
        YieldRedemptionPriceType = yieldRedemptionPriceType
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadYieldDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : YieldData =
    let yieldType = ReadOptionalFieldOrdered true bs index 235 ReadYieldType
    let yyield = ReadOptionalFieldOrdered true bs index 236 ReadYield
    let yieldCalcDate = ReadOptionalFieldOrdered true bs index 701 ReadYieldCalcDate
    let yieldRedemptionDate = ReadOptionalFieldOrdered true bs index 696 ReadYieldRedemptionDate
    let yieldRedemptionPrice = ReadOptionalFieldOrdered true bs index 697 ReadYieldRedemptionPrice
    let yieldRedemptionPriceType = ReadOptionalFieldOrdered true bs index 698 ReadYieldRedemptionPriceType
    let ci:YieldData = {
        YieldType = yieldType
        Yield = yyield
        YieldCalcDate = yieldCalcDate
        YieldRedemptionDate = yieldRedemptionDate
        YieldRedemptionPrice = yieldRedemptionPrice
        YieldRedemptionPriceType = yieldRedemptionPriceType
    }
    ci


// component, random access reader
let ReadPegInstructions (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PegInstructions =
    let pegOffsetValue = ReadOptionalField bs index 211 ReadPegOffsetValue
    let pegMoveType = ReadOptionalField bs index 835 ReadPegMoveType
    let pegOffsetType = ReadOptionalField bs index 836 ReadPegOffsetType
    let pegLimitType = ReadOptionalField bs index 837 ReadPegLimitType
    let pegRoundDirection = ReadOptionalField bs index 838 ReadPegRoundDirection
    let pegScope = ReadOptionalField bs index 840 ReadPegScope
    let ci:PegInstructions = {
        PegOffsetValue = pegOffsetValue
        PegMoveType = pegMoveType
        PegOffsetType = pegOffsetType
        PegLimitType = pegLimitType
        PegRoundDirection = pegRoundDirection
        PegScope = pegScope
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPegInstructionsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : PegInstructions =
    let pegOffsetValue = ReadOptionalFieldOrdered true bs index 211 ReadPegOffsetValue
    let pegMoveType = ReadOptionalFieldOrdered true bs index 835 ReadPegMoveType
    let pegOffsetType = ReadOptionalFieldOrdered true bs index 836 ReadPegOffsetType
    let pegLimitType = ReadOptionalFieldOrdered true bs index 837 ReadPegLimitType
    let pegRoundDirection = ReadOptionalFieldOrdered true bs index 838 ReadPegRoundDirection
    let pegScope = ReadOptionalFieldOrdered true bs index 840 ReadPegScope
    let ci:PegInstructions = {
        PegOffsetValue = pegOffsetValue
        PegMoveType = pegMoveType
        PegOffsetType = pegOffsetType
        PegLimitType = pegLimitType
        PegRoundDirection = pegRoundDirection
        PegScope = pegScope
    }
    ci


// component, random access reader
let ReadDiscretionInstructions (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DiscretionInstructions =
    let discretionInst = ReadOptionalField bs index 388 ReadDiscretionInst
    let discretionOffsetValue = ReadOptionalField bs index 389 ReadDiscretionOffsetValue
    let discretionMoveType = ReadOptionalField bs index 841 ReadDiscretionMoveType
    let discretionOffsetType = ReadOptionalField bs index 842 ReadDiscretionOffsetType
    let discretionLimitType = ReadOptionalField bs index 843 ReadDiscretionLimitType
    let discretionRoundDirection = ReadOptionalField bs index 844 ReadDiscretionRoundDirection
    let discretionScope = ReadOptionalField bs index 846 ReadDiscretionScope
    let ci:DiscretionInstructions = {
        DiscretionInst = discretionInst
        DiscretionOffsetValue = discretionOffsetValue
        DiscretionMoveType = discretionMoveType
        DiscretionOffsetType = discretionOffsetType
        DiscretionLimitType = discretionLimitType
        DiscretionRoundDirection = discretionRoundDirection
        DiscretionScope = discretionScope
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadDiscretionInstructionsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DiscretionInstructions =
    let discretionInst = ReadOptionalFieldOrdered true bs index 388 ReadDiscretionInst
    let discretionOffsetValue = ReadOptionalFieldOrdered true bs index 389 ReadDiscretionOffsetValue
    let discretionMoveType = ReadOptionalFieldOrdered true bs index 841 ReadDiscretionMoveType
    let discretionOffsetType = ReadOptionalFieldOrdered true bs index 842 ReadDiscretionOffsetType
    let discretionLimitType = ReadOptionalFieldOrdered true bs index 843 ReadDiscretionLimitType
    let discretionRoundDirection = ReadOptionalFieldOrdered true bs index 844 ReadDiscretionRoundDirection
    let discretionScope = ReadOptionalFieldOrdered true bs index 846 ReadDiscretionScope
    let ci:DiscretionInstructions = {
        DiscretionInst = discretionInst
        DiscretionOffsetValue = discretionOffsetValue
        DiscretionMoveType = discretionMoveType
        DiscretionOffsetType = discretionOffsetType
        DiscretionLimitType = discretionLimitType
        DiscretionRoundDirection = discretionRoundDirection
        DiscretionScope = discretionScope
    }
    ci


// group
let ReadNewOrderListNoOrdersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderListNoOrdersGrp =
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let listSeqNo = ReadFieldOrdered true bs index 67 ReadListSeqNo
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkID
    let settlInstMode = ReadOptionalFieldOrdered true bs index 160 ReadSettlInstMode
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDate
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDate
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountType
    let dayBookingInst = ReadOptionalFieldOrdered true bs index 589 ReadDayBookingInst
    let bookingUnit = ReadOptionalFieldOrdered true bs index 590 ReadBookingUnit
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocID
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethod
    let noAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadNoAllocsGrp
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlType
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let cashMargin = ReadOptionalFieldOrdered true bs index 544 ReadCashMargin
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicator
    let handlInst = ReadOptionalFieldOrdered true bs index 21 ReadHandlInst
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInst
    let minQty = ReadOptionalFieldOrdered true bs index 110 ReadMinQty
    let maxFloor = ReadOptionalFieldOrdered true bs index 111 ReadMaxFloor
    let exDestination = ReadOptionalFieldOrdered true bs index 100 ReadExDestination
    let noTradingSessionsGrp = ReadOptionalGroupOrdered true bs index 386 ReadNoTradingSessionsGrp
    let processCode = ReadOptionalFieldOrdered true bs index 81 ReadProcessCode
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePx
    let side = ReadFieldOrdered true bs index 54 ReadSide
    let sideValueInd = ReadOptionalFieldOrdered true bs index 401 ReadSideValueInd
    let locateReqd = ReadOptionalFieldOrdered true bs index 114 ReadLocateReqd
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTime
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrp
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyType
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataOrdered
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdType
    let priceType = ReadOptionalFieldOrdered true bs index 423 ReadPriceType
    let price = ReadOptionalFieldOrdered true bs index 44 ReadPrice
    let stopPx = ReadOptionalFieldOrdered true bs index 99 ReadStopPx
    let spreadOrBenchmarkCurveData = ReadComponentOrdered true bs index ReadSpreadOrBenchmarkCurveDataOrdered
    let yieldData = ReadComponentOrdered true bs index ReadYieldDataOrdered
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let complianceID = ReadOptionalFieldOrdered true bs index 376 ReadComplianceID
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlag
    let iOIid = ReadOptionalFieldOrdered true bs index 23 ReadIOIid
    let quoteID = ReadOptionalFieldOrdered true bs index 117 ReadQuoteID
    let timeInForce = ReadOptionalFieldOrdered true bs index 59 ReadTimeInForce
    let effectiveTime = ReadOptionalFieldOrdered true bs index 168 ReadEffectiveTime
    let expireDate = ReadOptionalFieldOrdered true bs index 432 ReadExpireDate
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTime
    let gTBookingInst = ReadOptionalFieldOrdered true bs index 427 ReadGTBookingInst
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataOrdered
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacity
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictions
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacity
    let forexReq = ReadOptionalFieldOrdered true bs index 121 ReadForexReq
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrency
    let bookingType = ReadOptionalFieldOrdered true bs index 775 ReadBookingType
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2
    let price2 = ReadOptionalFieldOrdered true bs index 640 ReadPrice2
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffect
    let coveredOrUncovered = ReadOptionalFieldOrdered true bs index 203 ReadCoveredOrUncovered
    let maxShow = ReadOptionalFieldOrdered true bs index 210 ReadMaxShow
    let pegInstructions = ReadComponentOrdered true bs index ReadPegInstructionsOrdered
    let discretionInstructions = ReadComponentOrdered true bs index ReadDiscretionInstructionsOrdered
    let targetStrategy = ReadOptionalFieldOrdered true bs index 847 ReadTargetStrategy
    let targetStrategyParameters = ReadOptionalFieldOrdered true bs index 848 ReadTargetStrategyParameters
    let participationRate = ReadOptionalFieldOrdered true bs index 849 ReadParticipationRate
    let designation = ReadOptionalFieldOrdered true bs index 494 ReadDesignation
    let ci:NewOrderListNoOrdersGrp = {
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ListSeqNo = listSeqNo
        ClOrdLinkID = clOrdLinkID
        SettlInstMode = settlInstMode
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        DayBookingInst = dayBookingInst
        BookingUnit = bookingUnit
        AllocID = allocID
        PreallocMethod = preallocMethod
        NoAllocsGrp = noAllocsGrp
        SettlType = settlType
        SettlDate = settlDate
        CashMargin = cashMargin
        ClearingFeeIndicator = clearingFeeIndicator
        HandlInst = handlInst
        ExecInst = execInst
        MinQty = minQty
        MaxFloor = maxFloor
        ExDestination = exDestination
        NoTradingSessionsGrp = noTradingSessionsGrp
        ProcessCode = processCode
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        PrevClosePx = prevClosePx
        Side = side
        SideValueInd = sideValueInd
        LocateReqd = locateReqd
        TransactTime = transactTime
        NoStipulationsGrp = noStipulationsGrp
        QtyType = qtyType
        OrderQtyData = orderQtyData
        OrdType = ordType
        PriceType = priceType
        Price = price
        StopPx = stopPx
        SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
        YieldData = yieldData
        Currency = currency
        ComplianceID = complianceID
        SolicitedFlag = solicitedFlag
        IOIid = iOIid
        QuoteID = quoteID
        TimeInForce = timeInForce
        EffectiveTime = effectiveTime
        ExpireDate = expireDate
        ExpireTime = expireTime
        GTBookingInst = gTBookingInst
        CommissionData = commissionData
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        ForexReq = forexReq
        SettlCurrency = settlCurrency
        BookingType = bookingType
        Text = text
        EncodedText = encodedText
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        Price2 = price2
        PositionEffect = positionEffect
        CoveredOrUncovered = coveredOrUncovered
        MaxShow = maxShow
        PegInstructions = pegInstructions
        DiscretionInstructions = discretionInstructions
        TargetStrategy = targetStrategy
        TargetStrategyParameters = targetStrategyParameters
        ParticipationRate = participationRate
        Designation = designation
    }
    ci


// component, random access reader
let ReadCommissionDataFG (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionDataFG =
    let commission = ReadField bs index 12 ReadCommission
    let commType = ReadOptionalField bs index 13 ReadCommType
    let commCurrency = ReadOptionalField bs index 479 ReadCommCurrency
    let fundRenewWaiv = ReadOptionalField bs index 497 ReadFundRenewWaiv
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadCommissionDataFGOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CommissionDataFG =
    let commission = ReadFieldOrdered true bs index 12 ReadCommission
    let commType = ReadOptionalFieldOrdered true bs index 13 ReadCommType
    let commCurrency = ReadOptionalFieldOrdered true bs index 479 ReadCommCurrency
    let fundRenewWaiv = ReadOptionalFieldOrdered true bs index 497 ReadFundRenewWaiv
    let ci:CommissionDataFG = {
        Commission = commission
        CommType = commType
        CommCurrency = commCurrency
        FundRenewWaiv = fundRenewWaiv
    }
    ci


// group
let ReadBidResponseNoBidComponentsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : BidResponseNoBidComponentsGrp =
    let commissionDataFG = ReadComponentOrdered true bs index ReadCommissionDataFGOrdered
    let listID = ReadOptionalFieldOrdered true bs index 66 ReadListID
    let country = ReadOptionalFieldOrdered true bs index 421 ReadCountry
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSide
    let price = ReadOptionalFieldOrdered true bs index 44 ReadPrice
    let priceType = ReadOptionalFieldOrdered true bs index 423 ReadPriceType
    let fairValue = ReadOptionalFieldOrdered true bs index 406 ReadFairValue
    let netGrossInd = ReadOptionalFieldOrdered true bs index 430 ReadNetGrossInd
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlType
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:BidResponseNoBidComponentsGrp = {
        CommissionDataFG = commissionDataFG
        ListID = listID
        Country = country
        Side = side
        Price = price
        PriceType = priceType
        FairValue = fairValue
        NetGrossInd = netGrossInd
        SettlType = settlType
        SettlDate = settlDate
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoLegAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegAllocsGrp =
    let legAllocAccount = ReadFieldOrdered true bs index 671 ReadLegAllocAccount
    let legIndividualAllocID = ReadOptionalFieldOrdered true bs index 672 ReadLegIndividualAllocID
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrp
    let legAllocQty = ReadOptionalFieldOrdered true bs index 673 ReadLegAllocQty
    let legAllocAcctIDSource = ReadOptionalFieldOrdered true bs index 674 ReadLegAllocAcctIDSource
    let legSettlCurrency = ReadOptionalFieldOrdered true bs index 675 ReadLegSettlCurrency
    let ci:NoLegAllocsGrp = {
        LegAllocAccount = legAllocAccount
        LegIndividualAllocID = legIndividualAllocID
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
        LegAllocQty = legAllocQty
        LegAllocAcctIDSource = legAllocAcctIDSource
        LegSettlCurrency = legSettlCurrency
    }
    ci


// group
let ReadMultilegOrderCancelReplaceRequestNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MultilegOrderCancelReplaceRequestNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noLegAllocsGrp = ReadOptionalGroupOrdered true bs index 670 ReadNoLegAllocsGrp
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffect
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncovered
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefID
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPrice
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let ci:MultilegOrderCancelReplaceRequestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoLegAllocsGrp = noLegAllocsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
    }
    ci


// group
let ReadNoNested3PartySubIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested3PartySubIDsGrp =
    let nested3PartySubID = ReadFieldOrdered true bs index 953 ReadNested3PartySubID
    let nested3PartySubIDType = ReadOptionalFieldOrdered true bs index 954 ReadNested3PartySubIDType
    let ci:NoNested3PartySubIDsGrp = {
        Nested3PartySubID = nested3PartySubID
        Nested3PartySubIDType = nested3PartySubIDType
    }
    ci


// group
let ReadNoNested3PartyIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoNested3PartyIDsGrp =
    let nested3PartyID = ReadFieldOrdered true bs index 949 ReadNested3PartyID
    let nested3PartyIDSource = ReadOptionalFieldOrdered true bs index 950 ReadNested3PartyIDSource
    let nested3PartyRole = ReadOptionalFieldOrdered true bs index 951 ReadNested3PartyRole
    let noNested3PartySubIDsGrp = ReadOptionalGroupOrdered true bs index 952 ReadNoNested3PartySubIDsGrp
    let ci:NoNested3PartyIDsGrp = {
        Nested3PartyID = nested3PartyID
        Nested3PartyIDSource = nested3PartyIDSource
        Nested3PartyRole = nested3PartyRole
        NoNested3PartySubIDsGrp = noNested3PartySubIDsGrp
    }
    ci


// group
let ReadMultilegOrderCancelReplaceRequestNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MultilegOrderCancelReplaceRequestNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let noNested3PartyIDsGrp = ReadOptionalGroupOrdered true bs index 948 ReadNoNested3PartyIDsGrp
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQty
    let ci:MultilegOrderCancelReplaceRequestNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// group
let ReadNewOrderMultilegNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderMultilegNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noLegAllocsGrp = ReadOptionalGroupOrdered true bs index 670 ReadNoLegAllocsGrp
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffect
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncovered
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefID
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPrice
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let ci:NewOrderMultilegNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoLegAllocsGrp = noLegAllocsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
    }
    ci


// component, random access reader
let ReadNestedParties2 (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties2 =
    let noNested2PartyIDsGrp = ReadOptionalGroup bs index 756 ReadNoNested2PartyIDsGrp
    let ci:NestedParties2 = {
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadNestedParties2Ordered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties2 =
    let noNested2PartyIDsGrp = ReadOptionalGroupOrdered true bs index 756 ReadNoNested2PartyIDsGrp
    let ci:NestedParties2 = {
        NoNested2PartyIDsGrp = noNested2PartyIDsGrp
    }
    ci


// group
let ReadNewOrderMultilegNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NewOrderMultilegNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocSettlCurrency = ReadOptionalFieldOrdered true bs index 736 ReadAllocSettlCurrency
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let noNested3PartyIDsGrp = ReadOptionalGroupOrdered true bs index 948 ReadNoNested3PartyIDsGrp
    let allocQty = ReadOptionalFieldOrdered true bs index 80 ReadAllocQty
    let ci:NewOrderMultilegNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocSettlCurrency = allocSettlCurrency
        IndividualAllocID = individualAllocID
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
        AllocQty = allocQty
    }
    ci


// component, random access reader
let ReadNestedParties3 (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties3 =
    let noNested3PartyIDsGrp = ReadOptionalGroup bs index 948 ReadNoNested3PartyIDsGrp
    let ci:NestedParties3 = {
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadNestedParties3Ordered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties3 =
    let noNested3PartyIDsGrp = ReadOptionalGroupOrdered true bs index 948 ReadNoNested3PartyIDsGrp
    let ci:NestedParties3 = {
        NoNested3PartyIDsGrp = noNested3PartyIDsGrp
    }
    ci


// group
let ReadCrossOrderCancelRequestNoSidesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CrossOrderCancelRequestNoSidesGrp =
    let side = ReadFieldOrdered true bs index 54 ReadSide
    let origClOrdID = ReadFieldOrdered true bs index 41 ReadOrigClOrdID
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkID
    let origOrdModTime = ReadOptionalFieldOrdered true bs index 586 ReadOrigOrdModTime
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDate
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDate
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataOrdered
    let complianceID = ReadOptionalFieldOrdered true bs index 376 ReadComplianceID
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:CrossOrderCancelRequestNoSidesGrp = {
        Side = side
        OrigClOrdID = origClOrdID
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ClOrdLinkID = clOrdLinkID
        OrigOrdModTime = origOrdModTime
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        OrderQtyData = orderQtyData
        ComplianceID = complianceID
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadCrossOrderCancelReplaceRequestNoSidesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : CrossOrderCancelReplaceRequestNoSidesGrp =
    let side = ReadFieldOrdered true bs index 54 ReadSide
    let origClOrdID = ReadFieldOrdered true bs index 41 ReadOrigClOrdID
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkID
    let origOrdModTime = ReadOptionalFieldOrdered true bs index 586 ReadOrigOrdModTime
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDate
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDate
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountType
    let dayBookingInst = ReadOptionalFieldOrdered true bs index 589 ReadDayBookingInst
    let bookingUnit = ReadOptionalFieldOrdered true bs index 590 ReadBookingUnit
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethod
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocID
    let noAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadNoAllocsGrp
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyType
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataOrdered
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataOrdered
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacity
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictions
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacity
    let forexReq = ReadOptionalFieldOrdered true bs index 121 ReadForexReq
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrency
    let bookingType = ReadOptionalFieldOrdered true bs index 775 ReadBookingType
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffect
    let coveredOrUncovered = ReadOptionalFieldOrdered true bs index 203 ReadCoveredOrUncovered
    let cashMargin = ReadOptionalFieldOrdered true bs index 544 ReadCashMargin
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicator
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlag
    let sideComplianceID = ReadOptionalFieldOrdered true bs index 659 ReadSideComplianceID
    let ci:CrossOrderCancelReplaceRequestNoSidesGrp = {
        Side = side
        OrigClOrdID = origClOrdID
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ClOrdLinkID = clOrdLinkID
        OrigOrdModTime = origOrdModTime
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        DayBookingInst = dayBookingInst
        BookingUnit = bookingUnit
        PreallocMethod = preallocMethod
        AllocID = allocID
        NoAllocsGrp = noAllocsGrp
        QtyType = qtyType
        OrderQtyData = orderQtyData
        CommissionData = commissionData
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        ForexReq = forexReq
        SettlCurrency = settlCurrency
        BookingType = bookingType
        Text = text
        EncodedText = encodedText
        PositionEffect = positionEffect
        CoveredOrUncovered = coveredOrUncovered
        CashMargin = cashMargin
        ClearingFeeIndicator = clearingFeeIndicator
        SolicitedFlag = solicitedFlag
        SideComplianceID = sideComplianceID
    }
    ci


// group
let ReadNoSidesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSidesGrp =
    let side = ReadFieldOrdered true bs index 54 ReadSide
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let clOrdLinkID = ReadOptionalFieldOrdered true bs index 583 ReadClOrdLinkID
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDate
    let tradeDate = ReadOptionalFieldOrdered true bs index 75 ReadTradeDate
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountType
    let dayBookingInst = ReadOptionalFieldOrdered true bs index 589 ReadDayBookingInst
    let bookingUnit = ReadOptionalFieldOrdered true bs index 590 ReadBookingUnit
    let preallocMethod = ReadOptionalFieldOrdered true bs index 591 ReadPreallocMethod
    let allocID = ReadOptionalFieldOrdered true bs index 70 ReadAllocID
    let noAllocsGrp = ReadOptionalGroupOrdered true bs index 78 ReadNoAllocsGrp
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyType
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataOrdered
    let commissionData = ReadComponentOrdered true bs index ReadCommissionDataOrdered
    let orderCapacity = ReadOptionalFieldOrdered true bs index 528 ReadOrderCapacity
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictions
    let custOrderCapacity = ReadOptionalFieldOrdered true bs index 582 ReadCustOrderCapacity
    let forexReq = ReadOptionalFieldOrdered true bs index 121 ReadForexReq
    let settlCurrency = ReadOptionalFieldOrdered true bs index 120 ReadSettlCurrency
    let bookingType = ReadOptionalFieldOrdered true bs index 775 ReadBookingType
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let positionEffect = ReadOptionalFieldOrdered true bs index 77 ReadPositionEffect
    let coveredOrUncovered = ReadOptionalFieldOrdered true bs index 203 ReadCoveredOrUncovered
    let cashMargin = ReadOptionalFieldOrdered true bs index 544 ReadCashMargin
    let clearingFeeIndicator = ReadOptionalFieldOrdered true bs index 635 ReadClearingFeeIndicator
    let solicitedFlag = ReadOptionalFieldOrdered true bs index 377 ReadSolicitedFlag
    let sideComplianceID = ReadOptionalFieldOrdered true bs index 659 ReadSideComplianceID
    let ci:NoSidesGrp = {
        Side = side
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        ClOrdLinkID = clOrdLinkID
        NoPartyIDsGrp = noPartyIDsGrp
        TradeOriginationDate = tradeOriginationDate
        TradeDate = tradeDate
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        DayBookingInst = dayBookingInst
        BookingUnit = bookingUnit
        PreallocMethod = preallocMethod
        AllocID = allocID
        NoAllocsGrp = noAllocsGrp
        QtyType = qtyType
        OrderQtyData = orderQtyData
        CommissionData = commissionData
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        CustOrderCapacity = custOrderCapacity
        ForexReq = forexReq
        SettlCurrency = settlCurrency
        BookingType = bookingType
        Text = text
        EncodedText = encodedText
        PositionEffect = positionEffect
        CoveredOrUncovered = coveredOrUncovered
        CashMargin = cashMargin
        ClearingFeeIndicator = clearingFeeIndicator
        SolicitedFlag = solicitedFlag
        SideComplianceID = sideComplianceID
    }
    ci


// group
let ReadExecutionReportNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : ExecutionReportNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let legPositionEffect = ReadOptionalFieldOrdered true bs index 564 ReadLegPositionEffect
    let legCoveredOrUncovered = ReadOptionalFieldOrdered true bs index 565 ReadLegCoveredOrUncovered
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legRefID = ReadOptionalFieldOrdered true bs index 654 ReadLegRefID
    let legPrice = ReadOptionalFieldOrdered true bs index 566 ReadLegPrice
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let legLastPx = ReadOptionalFieldOrdered true bs index 637 ReadLegLastPx
    let ci:ExecutionReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegPositionEffect = legPositionEffect
        LegCoveredOrUncovered = legCoveredOrUncovered
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegRefID = legRefID
        LegPrice = legPrice
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        LegLastPx = legLastPx
    }
    ci


// group
let ReadNoInstrAttribGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoInstrAttribGrp =
    let instrAttribType = ReadFieldOrdered true bs index 871 ReadInstrAttribType
    let instrAttribValue = ReadOptionalFieldOrdered true bs index 872 ReadInstrAttribValue
    let ci:NoInstrAttribGrp = {
        InstrAttribType = instrAttribType
        InstrAttribValue = instrAttribValue
    }
    ci


// component, random access reader
let ReadInstrumentExtension (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentExtension =
    let deliveryForm = ReadOptionalField bs index 668 ReadDeliveryForm
    let pctAtRisk = ReadOptionalField bs index 869 ReadPctAtRisk
    let noInstrAttribGrp = ReadOptionalGroup bs index 870 ReadNoInstrAttribGrp
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentExtensionOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentExtension =
    let deliveryForm = ReadOptionalFieldOrdered true bs index 668 ReadDeliveryForm
    let pctAtRisk = ReadOptionalFieldOrdered true bs index 869 ReadPctAtRisk
    let noInstrAttribGrp = ReadOptionalGroupOrdered true bs index 870 ReadNoInstrAttribGrp
    let ci:InstrumentExtension = {
        DeliveryForm = deliveryForm
        PctAtRisk = pctAtRisk
        NoInstrAttribGrp = noInstrAttribGrp
    }
    ci


// group
let ReadNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let ci:NoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
    }
    ci


// group
let ReadDerivativeSecurityListNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : DerivativeSecurityListNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let expirationCycle = ReadOptionalFieldOrdered true bs index 827 ReadExpirationCycle
    let instrumentExtension = ReadComponentOrdered true bs index ReadInstrumentExtensionOrdered
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:DerivativeSecurityListNoRelatedSymGrp = {
        Instrument = instrument
        Currency = currency
        ExpirationCycle = expirationCycle
        InstrumentExtension = instrumentExtension
        NoLegsGrp = noLegsGrp
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        Text = text
        EncodedText = encodedText
    }
    ci


// component, random access reader
let ReadFinancingDetails (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : FinancingDetails =
    let agreementDesc = ReadOptionalField bs index 913 ReadAgreementDesc
    let agreementID = ReadOptionalField bs index 914 ReadAgreementID
    let agreementDate = ReadOptionalField bs index 915 ReadAgreementDate
    let agreementCurrency = ReadOptionalField bs index 918 ReadAgreementCurrency
    let terminationType = ReadOptionalField bs index 788 ReadTerminationType
    let startDate = ReadOptionalField bs index 916 ReadStartDate
    let endDate = ReadOptionalField bs index 917 ReadEndDate
    let deliveryType = ReadOptionalField bs index 919 ReadDeliveryType
    let marginRatio = ReadOptionalField bs index 898 ReadMarginRatio
    let ci:FinancingDetails = {
        AgreementDesc = agreementDesc
        AgreementID = agreementID
        AgreementDate = agreementDate
        AgreementCurrency = agreementCurrency
        TerminationType = terminationType
        StartDate = startDate
        EndDate = endDate
        DeliveryType = deliveryType
        MarginRatio = marginRatio
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadFinancingDetailsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : FinancingDetails =
    let agreementDesc = ReadOptionalFieldOrdered true bs index 913 ReadAgreementDesc
    let agreementID = ReadOptionalFieldOrdered true bs index 914 ReadAgreementID
    let agreementDate = ReadOptionalFieldOrdered true bs index 915 ReadAgreementDate
    let agreementCurrency = ReadOptionalFieldOrdered true bs index 918 ReadAgreementCurrency
    let terminationType = ReadOptionalFieldOrdered true bs index 788 ReadTerminationType
    let startDate = ReadOptionalFieldOrdered true bs index 916 ReadStartDate
    let endDate = ReadOptionalFieldOrdered true bs index 917 ReadEndDate
    let deliveryType = ReadOptionalFieldOrdered true bs index 919 ReadDeliveryType
    let marginRatio = ReadOptionalFieldOrdered true bs index 898 ReadMarginRatio
    let ci:FinancingDetails = {
        AgreementDesc = agreementDesc
        AgreementID = agreementID
        AgreementDate = agreementDate
        AgreementCurrency = agreementCurrency
        TerminationType = terminationType
        StartDate = startDate
        EndDate = endDate
        DeliveryType = deliveryType
        MarginRatio = marginRatio
    }
    ci


// component, random access reader
let ReadLegBenchmarkCurveData (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegBenchmarkCurveData =
    let legBenchmarkCurveCurrency = ReadOptionalField bs index 676 ReadLegBenchmarkCurveCurrency
    let legBenchmarkCurveName = ReadOptionalField bs index 677 ReadLegBenchmarkCurveName
    let legBenchmarkCurvePoint = ReadOptionalField bs index 678 ReadLegBenchmarkCurvePoint
    let legBenchmarkPrice = ReadOptionalField bs index 679 ReadLegBenchmarkPrice
    let legBenchmarkPriceType = ReadOptionalField bs index 680 ReadLegBenchmarkPriceType
    let ci:LegBenchmarkCurveData = {
        LegBenchmarkCurveCurrency = legBenchmarkCurveCurrency
        LegBenchmarkCurveName = legBenchmarkCurveName
        LegBenchmarkCurvePoint = legBenchmarkCurvePoint
        LegBenchmarkPrice = legBenchmarkPrice
        LegBenchmarkPriceType = legBenchmarkPriceType
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadLegBenchmarkCurveDataOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegBenchmarkCurveData =
    let legBenchmarkCurveCurrency = ReadOptionalFieldOrdered true bs index 676 ReadLegBenchmarkCurveCurrency
    let legBenchmarkCurveName = ReadOptionalFieldOrdered true bs index 677 ReadLegBenchmarkCurveName
    let legBenchmarkCurvePoint = ReadOptionalFieldOrdered true bs index 678 ReadLegBenchmarkCurvePoint
    let legBenchmarkPrice = ReadOptionalFieldOrdered true bs index 679 ReadLegBenchmarkPrice
    let legBenchmarkPriceType = ReadOptionalFieldOrdered true bs index 680 ReadLegBenchmarkPriceType
    let ci:LegBenchmarkCurveData = {
        LegBenchmarkCurveCurrency = legBenchmarkCurveCurrency
        LegBenchmarkCurveName = legBenchmarkCurveName
        LegBenchmarkCurvePoint = legBenchmarkCurvePoint
        LegBenchmarkPrice = legBenchmarkPrice
        LegBenchmarkPriceType = legBenchmarkPriceType
    }
    ci


// group
let ReadSecurityListNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SecurityListNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataOrdered
    let ci:SecurityListNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        NoLegStipulationsGrp = noLegStipulationsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadSecurityListNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : SecurityListNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let instrumentExtension = ReadComponentOrdered true bs index ReadInstrumentExtensionOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrp
    let securityListNoLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadSecurityListNoLegsGrp
    let spreadOrBenchmarkCurveData = ReadComponentOrdered true bs index ReadSpreadOrBenchmarkCurveDataOrdered
    let yieldData = ReadComponentOrdered true bs index ReadYieldDataOrdered
    let roundLot = ReadOptionalFieldOrdered true bs index 561 ReadRoundLot
    let minTradeVol = ReadOptionalFieldOrdered true bs index 562 ReadMinTradeVol
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let expirationCycle = ReadOptionalFieldOrdered true bs index 827 ReadExpirationCycle
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:SecurityListNoRelatedSymGrp = {
        Instrument = instrument
        InstrumentExtension = instrumentExtension
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        Currency = currency
        NoStipulationsGrp = noStipulationsGrp
        SecurityListNoLegsGrp = securityListNoLegsGrp
        SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
        YieldData = yieldData
        RoundLot = roundLot
        MinTradeVol = minTradeVol
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        ExpirationCycle = expirationCycle
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadMarketDataIncrementalRefreshNoMDEntriesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MarketDataIncrementalRefreshNoMDEntriesGrp =
    let mDUpdateAction = ReadFieldOrdered true bs index 279 ReadMDUpdateAction
    let deleteReason = ReadOptionalFieldOrdered true bs index 285 ReadDeleteReason
    let mDEntryType = ReadOptionalFieldOrdered true bs index 269 ReadMDEntryType
    let mDEntryID = ReadOptionalFieldOrdered true bs index 278 ReadMDEntryID
    let mDEntryRefID = ReadOptionalFieldOrdered true bs index 280 ReadMDEntryRefID
    let instrument = ReadOptionalComponentOrdered true bs index 55 ReadInstrumentOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let financialStatus = ReadOptionalFieldOrdered true bs index 291 ReadFinancialStatus
    let corporateAction = ReadOptionalFieldOrdered true bs index 292 ReadCorporateAction
    let mDEntryPx = ReadOptionalFieldOrdered true bs index 270 ReadMDEntryPx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let mDEntrySize = ReadOptionalFieldOrdered true bs index 271 ReadMDEntrySize
    let mDEntryDate = ReadOptionalFieldOrdered true bs index 272 ReadMDEntryDate
    let mDEntryTime = ReadOptionalFieldOrdered true bs index 273 ReadMDEntryTime
    let tickDirection = ReadOptionalFieldOrdered true bs index 274 ReadTickDirection
    let mDMkt = ReadOptionalFieldOrdered true bs index 275 ReadMDMkt
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let quoteCondition = ReadOptionalFieldOrdered true bs index 276 ReadQuoteCondition
    let tradeCondition = ReadOptionalFieldOrdered true bs index 277 ReadTradeCondition
    let mDEntryOriginator = ReadOptionalFieldOrdered true bs index 282 ReadMDEntryOriginator
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationID
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskID
    let openCloseSettlFlag = ReadOptionalFieldOrdered true bs index 286 ReadOpenCloseSettlFlag
    let timeInForce = ReadOptionalFieldOrdered true bs index 59 ReadTimeInForce
    let expireDate = ReadOptionalFieldOrdered true bs index 432 ReadExpireDate
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTime
    let minQty = ReadOptionalFieldOrdered true bs index 110 ReadMinQty
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInst
    let sellerDays = ReadOptionalFieldOrdered true bs index 287 ReadSellerDays
    let orderID = ReadOptionalFieldOrdered true bs index 37 ReadOrderID
    let quoteEntryID = ReadOptionalFieldOrdered true bs index 299 ReadQuoteEntryID
    let mDEntryBuyer = ReadOptionalFieldOrdered true bs index 288 ReadMDEntryBuyer
    let mDEntrySeller = ReadOptionalFieldOrdered true bs index 289 ReadMDEntrySeller
    let numberOfOrders = ReadOptionalFieldOrdered true bs index 346 ReadNumberOfOrders
    let mDEntryPositionNo = ReadOptionalFieldOrdered true bs index 290 ReadMDEntryPositionNo
    let scope = ReadOptionalFieldOrdered true bs index 546 ReadScope
    let priceDelta = ReadOptionalFieldOrdered true bs index 811 ReadPriceDelta
    let netChgPrevDay = ReadOptionalFieldOrdered true bs index 451 ReadNetChgPrevDay
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:MarketDataIncrementalRefreshNoMDEntriesGrp = {
        MDUpdateAction = mDUpdateAction
        DeleteReason = deleteReason
        MDEntryType = mDEntryType
        MDEntryID = mDEntryID
        MDEntryRefID = mDEntryRefID
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
        FinancialStatus = financialStatus
        CorporateAction = corporateAction
        MDEntryPx = mDEntryPx
        Currency = currency
        MDEntrySize = mDEntrySize
        MDEntryDate = mDEntryDate
        MDEntryTime = mDEntryTime
        TickDirection = tickDirection
        MDMkt = mDMkt
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        QuoteCondition = quoteCondition
        TradeCondition = tradeCondition
        MDEntryOriginator = mDEntryOriginator
        LocationID = locationID
        DeskID = deskID
        OpenCloseSettlFlag = openCloseSettlFlag
        TimeInForce = timeInForce
        ExpireDate = expireDate
        ExpireTime = expireTime
        MinQty = minQty
        ExecInst = execInst
        SellerDays = sellerDays
        OrderID = orderID
        QuoteEntryID = quoteEntryID
        MDEntryBuyer = mDEntryBuyer
        MDEntrySeller = mDEntrySeller
        NumberOfOrders = numberOfOrders
        MDEntryPositionNo = mDEntryPositionNo
        Scope = scope
        PriceDelta = priceDelta
        NetChgPrevDay = netChgPrevDay
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadMarketDataRequestNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MarketDataRequestNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let ci:MarketDataRequestNoRelatedSymGrp = {
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    ci


// group
let ReadMassQuoteAcknowledgementNoQuoteEntriesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteAcknowledgementNoQuoteEntriesGrp =
    let quoteEntryID = ReadFieldOrdered true bs index 299 ReadQuoteEntryID
    let instrument = ReadOptionalComponentOrdered true bs index 55 ReadInstrumentOrdered
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let bidPx = ReadOptionalFieldOrdered true bs index 132 ReadBidPx
    let offerPx = ReadOptionalFieldOrdered true bs index 133 ReadOfferPx
    let bidSize = ReadOptionalFieldOrdered true bs index 134 ReadBidSize
    let offerSize = ReadOptionalFieldOrdered true bs index 135 ReadOfferSize
    let validUntilTime = ReadOptionalFieldOrdered true bs index 62 ReadValidUntilTime
    let bidSpotRate = ReadOptionalFieldOrdered true bs index 188 ReadBidSpotRate
    let offerSpotRate = ReadOptionalFieldOrdered true bs index 190 ReadOfferSpotRate
    let bidForwardPoints = ReadOptionalFieldOrdered true bs index 189 ReadBidForwardPoints
    let offerForwardPoints = ReadOptionalFieldOrdered true bs index 191 ReadOfferForwardPoints
    let midPx = ReadOptionalFieldOrdered true bs index 631 ReadMidPx
    let bidYield = ReadOptionalFieldOrdered true bs index 632 ReadBidYield
    let midYield = ReadOptionalFieldOrdered true bs index 633 ReadMidYield
    let offerYield = ReadOptionalFieldOrdered true bs index 634 ReadOfferYield
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTime
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdType
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2
    let bidForwardPoints2 = ReadOptionalFieldOrdered true bs index 642 ReadBidForwardPoints2
    let offerForwardPoints2 = ReadOptionalFieldOrdered true bs index 643 ReadOfferForwardPoints2
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let quoteEntryRejectReason = ReadOptionalFieldOrdered true bs index 368 ReadQuoteEntryRejectReason
    let ci:MassQuoteAcknowledgementNoQuoteEntriesGrp = {
        QuoteEntryID = quoteEntryID
        Instrument = instrument
        NoLegsGrp = noLegsGrp
        BidPx = bidPx
        OfferPx = offerPx
        BidSize = bidSize
        OfferSize = offerSize
        ValidUntilTime = validUntilTime
        BidSpotRate = bidSpotRate
        OfferSpotRate = offerSpotRate
        BidForwardPoints = bidForwardPoints
        OfferForwardPoints = offerForwardPoints
        MidPx = midPx
        BidYield = bidYield
        MidYield = midYield
        OfferYield = offerYield
        TransactTime = transactTime
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        SettlDate = settlDate
        OrdType = ordType
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        BidForwardPoints2 = bidForwardPoints2
        OfferForwardPoints2 = offerForwardPoints2
        Currency = currency
        QuoteEntryRejectReason = quoteEntryRejectReason
    }
    ci


// group
let ReadMassQuoteAcknowledgementNoQuoteSetsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteAcknowledgementNoQuoteSetsGrp =
    let quoteSetID = ReadFieldOrdered true bs index 302 ReadQuoteSetID
    let underlyingInstrument = ReadOptionalComponentOrdered true bs index 311 ReadUnderlyingInstrumentOrdered
    let totNoQuoteEntries = ReadOptionalFieldOrdered true bs index 304 ReadTotNoQuoteEntries
    let lastFragment = ReadOptionalFieldOrdered true bs index 893 ReadLastFragment
    let massQuoteAcknowledgementNoQuoteEntriesGrp = ReadOptionalGroupOrdered true bs index 295 ReadMassQuoteAcknowledgementNoQuoteEntriesGrp
    let ci:MassQuoteAcknowledgementNoQuoteSetsGrp = {
        QuoteSetID = quoteSetID
        UnderlyingInstrument = underlyingInstrument
        TotNoQuoteEntries = totNoQuoteEntries
        LastFragment = lastFragment
        MassQuoteAcknowledgementNoQuoteEntriesGrp = massQuoteAcknowledgementNoQuoteEntriesGrp
    }
    ci


// group
let ReadMassQuoteNoQuoteEntriesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : MassQuoteNoQuoteEntriesGrp =
    let quoteEntryID = ReadFieldOrdered true bs index 299 ReadQuoteEntryID
    let instrument = ReadOptionalComponentOrdered true bs index 55 ReadInstrumentOrdered
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let bidPx = ReadOptionalFieldOrdered true bs index 132 ReadBidPx
    let offerPx = ReadOptionalFieldOrdered true bs index 133 ReadOfferPx
    let bidSize = ReadOptionalFieldOrdered true bs index 134 ReadBidSize
    let offerSize = ReadOptionalFieldOrdered true bs index 135 ReadOfferSize
    let validUntilTime = ReadOptionalFieldOrdered true bs index 62 ReadValidUntilTime
    let bidSpotRate = ReadOptionalFieldOrdered true bs index 188 ReadBidSpotRate
    let offerSpotRate = ReadOptionalFieldOrdered true bs index 190 ReadOfferSpotRate
    let bidForwardPoints = ReadOptionalFieldOrdered true bs index 189 ReadBidForwardPoints
    let offerForwardPoints = ReadOptionalFieldOrdered true bs index 191 ReadOfferForwardPoints
    let midPx = ReadOptionalFieldOrdered true bs index 631 ReadMidPx
    let bidYield = ReadOptionalFieldOrdered true bs index 632 ReadBidYield
    let midYield = ReadOptionalFieldOrdered true bs index 633 ReadMidYield
    let offerYield = ReadOptionalFieldOrdered true bs index 634 ReadOfferYield
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTime
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdType
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2
    let bidForwardPoints2 = ReadOptionalFieldOrdered true bs index 642 ReadBidForwardPoints2
    let offerForwardPoints2 = ReadOptionalFieldOrdered true bs index 643 ReadOfferForwardPoints2
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let ci:MassQuoteNoQuoteEntriesGrp = {
        QuoteEntryID = quoteEntryID
        Instrument = instrument
        NoLegsGrp = noLegsGrp
        BidPx = bidPx
        OfferPx = offerPx
        BidSize = bidSize
        OfferSize = offerSize
        ValidUntilTime = validUntilTime
        BidSpotRate = bidSpotRate
        OfferSpotRate = offerSpotRate
        BidForwardPoints = bidForwardPoints
        OfferForwardPoints = offerForwardPoints
        MidPx = midPx
        BidYield = bidYield
        MidYield = midYield
        OfferYield = offerYield
        TransactTime = transactTime
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        SettlDate = settlDate
        OrdType = ordType
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        BidForwardPoints2 = bidForwardPoints2
        OfferForwardPoints2 = offerForwardPoints2
        Currency = currency
    }
    ci


// group
let ReadNoQuoteSetsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoQuoteSetsGrp =
    let quoteSetID = ReadFieldOrdered true bs index 302 ReadQuoteSetID
    let underlyingInstrument = ReadOptionalComponentOrdered true bs index 311 ReadUnderlyingInstrumentOrdered
    let quoteSetValidUntilTime = ReadOptionalFieldOrdered true bs index 367 ReadQuoteSetValidUntilTime
    let totNoQuoteEntries = ReadFieldOrdered true bs index 304 ReadTotNoQuoteEntries
    let lastFragment = ReadOptionalFieldOrdered true bs index 893 ReadLastFragment
    let massQuoteNoQuoteEntriesGrp = ReadGroup bs index 295 ReadMassQuoteNoQuoteEntriesGrp
    let ci:NoQuoteSetsGrp = {
        QuoteSetID = quoteSetID
        UnderlyingInstrument = underlyingInstrument
        QuoteSetValidUntilTime = quoteSetValidUntilTime
        TotNoQuoteEntries = totNoQuoteEntries
        LastFragment = lastFragment
        MassQuoteNoQuoteEntriesGrp = massQuoteNoQuoteEntriesGrp
    }
    ci


// group
let ReadQuoteStatusReportNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteStatusReportNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let ci:QuoteStatusReportNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// group
let ReadNoQuoteEntriesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoQuoteEntriesGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let ci:NoQuoteEntriesGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
    }
    ci


// group
let ReadQuoteNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legPriceType = ReadOptionalFieldOrdered true bs index 686 ReadLegPriceType
    let legBidPx = ReadOptionalFieldOrdered true bs index 681 ReadLegBidPx
    let legOfferPx = ReadOptionalFieldOrdered true bs index 684 ReadLegOfferPx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataOrdered
    let ci:QuoteNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegPriceType = legPriceType
        LegBidPx = legBidPx
        LegOfferPx = legOfferPx
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadRFQRequestNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : RFQRequestNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let noLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadNoLegsGrp
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePx
    let quoteRequestType = ReadOptionalFieldOrdered true bs index 303 ReadQuoteRequestType
    let quoteType = ReadOptionalFieldOrdered true bs index 537 ReadQuoteType
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let ci:RFQRequestNoRelatedSymGrp = {
        Instrument = instrument
        NoUnderlyingsGrp = noUnderlyingsGrp
        NoLegsGrp = noLegsGrp
        PrevClosePx = prevClosePx
        QuoteRequestType = quoteRequestType
        QuoteType = quoteType
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
    }
    ci


// group
let ReadQuoteRequestRejectNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestRejectNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataOrdered
    let ci:QuoteRequestRejectNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadQuoteRequestRejectNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestRejectNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePx
    let quoteRequestType = ReadOptionalFieldOrdered true bs index 303 ReadQuoteRequestType
    let quoteType = ReadOptionalFieldOrdered true bs index 537 ReadQuoteType
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDate
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSide
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyType
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataOrdered
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlType
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrp
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountType
    let quoteRequestRejectNoLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadQuoteRequestRejectNoLegsGrp
    let ci:QuoteRequestRejectNoRelatedSymGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        PrevClosePx = prevClosePx
        QuoteRequestType = quoteRequestType
        QuoteType = quoteType
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        TradeOriginationDate = tradeOriginationDate
        Side = side
        QtyType = qtyType
        OrderQtyData = orderQtyData
        SettlType = settlType
        SettlDate = settlDate
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        Currency = currency
        NoStipulationsGrp = noStipulationsGrp
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        QuoteRequestRejectNoLegsGrp = quoteRequestRejectNoLegsGrp
    }
    ci


// group
let ReadQuoteResponseNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteResponseNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legPriceType = ReadOptionalFieldOrdered true bs index 686 ReadLegPriceType
    let legBidPx = ReadOptionalFieldOrdered true bs index 681 ReadLegBidPx
    let legOfferPx = ReadOptionalFieldOrdered true bs index 684 ReadLegOfferPx
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataOrdered
    let ci:QuoteResponseNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegPriceType = legPriceType
        LegBidPx = legBidPx
        LegOfferPx = legOfferPx
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadQuoteRequestNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legQty = ReadOptionalFieldOrdered true bs index 687 ReadLegQty
    let legSwapType = ReadOptionalFieldOrdered true bs index 690 ReadLegSwapType
    let legSettlType = ReadOptionalFieldOrdered true bs index 587 ReadLegSettlType
    let legSettlDate = ReadOptionalFieldOrdered true bs index 588 ReadLegSettlDate
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let legBenchmarkCurveData = ReadComponentOrdered true bs index ReadLegBenchmarkCurveDataOrdered
    let ci:QuoteRequestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegQty = legQty
        LegSwapType = legSwapType
        LegSettlType = legSettlType
        LegSettlDate = legSettlDate
        NoLegStipulationsGrp = noLegStipulationsGrp
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
        LegBenchmarkCurveData = legBenchmarkCurveData
    }
    ci


// group
let ReadNoQuoteQualifiersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoQuoteQualifiersGrp =
    let quoteQualifier = ReadFieldOrdered true bs index 695 ReadQuoteQualifier
    let ci:NoQuoteQualifiersGrp = {
        QuoteQualifier = quoteQualifier
    }
    ci


// group
let ReadQuoteRequestNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : QuoteRequestNoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let financingDetails = ReadComponentOrdered true bs index ReadFinancingDetailsOrdered
    let noUnderlyingsGrp = ReadOptionalGroupOrdered true bs index 711 ReadNoUnderlyingsGrp
    let prevClosePx = ReadOptionalFieldOrdered true bs index 140 ReadPrevClosePx
    let quoteRequestType = ReadOptionalFieldOrdered true bs index 303 ReadQuoteRequestType
    let quoteType = ReadOptionalFieldOrdered true bs index 537 ReadQuoteType
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let tradeOriginationDate = ReadOptionalFieldOrdered true bs index 229 ReadTradeOriginationDate
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSide
    let qtyType = ReadOptionalFieldOrdered true bs index 854 ReadQtyType
    let orderQtyData = ReadComponentOrdered true bs index ReadOrderQtyDataOrdered
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlType
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let settlDate2 = ReadOptionalFieldOrdered true bs index 193 ReadSettlDate2
    let orderQty2 = ReadOptionalFieldOrdered true bs index 192 ReadOrderQty2
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrp
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let accountType = ReadOptionalFieldOrdered true bs index 581 ReadAccountType
    let quoteRequestNoLegsGrp = ReadOptionalGroupOrdered true bs index 555 ReadQuoteRequestNoLegsGrp
    let noQuoteQualifiersGrp = ReadOptionalGroupOrdered true bs index 735 ReadNoQuoteQualifiersGrp
    let quotePriceType = ReadOptionalFieldOrdered true bs index 692 ReadQuotePriceType
    let ordType = ReadOptionalFieldOrdered true bs index 40 ReadOrdType
    let validUntilTime = ReadOptionalFieldOrdered true bs index 62 ReadValidUntilTime
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTime
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTime
    let spreadOrBenchmarkCurveData = ReadComponentOrdered true bs index ReadSpreadOrBenchmarkCurveDataOrdered
    let priceType = ReadOptionalFieldOrdered true bs index 423 ReadPriceType
    let price = ReadOptionalFieldOrdered true bs index 44 ReadPrice
    let price2 = ReadOptionalFieldOrdered true bs index 640 ReadPrice2
    let yieldData = ReadComponentOrdered true bs index ReadYieldDataOrdered
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let ci:QuoteRequestNoRelatedSymGrp = {
        Instrument = instrument
        FinancingDetails = financingDetails
        NoUnderlyingsGrp = noUnderlyingsGrp
        PrevClosePx = prevClosePx
        QuoteRequestType = quoteRequestType
        QuoteType = quoteType
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        TradeOriginationDate = tradeOriginationDate
        Side = side
        QtyType = qtyType
        OrderQtyData = orderQtyData
        SettlType = settlType
        SettlDate = settlDate
        SettlDate2 = settlDate2
        OrderQty2 = orderQty2
        Currency = currency
        NoStipulationsGrp = noStipulationsGrp
        Account = account
        AcctIDSource = acctIDSource
        AccountType = accountType
        QuoteRequestNoLegsGrp = quoteRequestNoLegsGrp
        NoQuoteQualifiersGrp = noQuoteQualifiersGrp
        QuotePriceType = quotePriceType
        OrdType = ordType
        ValidUntilTime = validUntilTime
        ExpireTime = expireTime
        TransactTime = transactTime
        SpreadOrBenchmarkCurveData = spreadOrBenchmarkCurveData
        PriceType = priceType
        Price = price
        Price2 = price2
        YieldData = yieldData
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component, random access reader
let ReadParties (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Parties =
    let noPartyIDsGrp = ReadOptionalGroup bs index 453 ReadNoPartyIDsGrp
    let ci:Parties = {
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadPartiesOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Parties =
    let noPartyIDsGrp = ReadOptionalGroupOrdered true bs index 453 ReadNoPartyIDsGrp
    let ci:Parties = {
        NoPartyIDsGrp = noPartyIDsGrp
    }
    ci


// component, random access reader
let ReadNestedParties (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties =
    let noNestedPartyIDsGrp = ReadOptionalGroup bs index 539 ReadNoNestedPartyIDsGrp
    let ci:NestedParties = {
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadNestedPartiesOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NestedParties =
    let noNestedPartyIDsGrp = ReadOptionalGroupOrdered true bs index 539 ReadNoNestedPartyIDsGrp
    let ci:NestedParties = {
        NoNestedPartyIDsGrp = noNestedPartyIDsGrp
    }
    ci


// group
let ReadNoRelatedSymGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRelatedSymGrp =
    let instrument = ReadComponentOrdered true bs index ReadInstrumentOrdered
    let ci:NoRelatedSymGrp = {
        Instrument = instrument
    }
    ci


// group
let ReadIndicationOfInterestNoLegsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : IndicationOfInterestNoLegsGrp =
    let instrumentLegFG = ReadComponentOrdered true bs index ReadInstrumentLegFGOrdered
    let legIOIQty = ReadOptionalFieldOrdered true bs index 682 ReadLegIOIQty
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let ci:IndicationOfInterestNoLegsGrp = {
        InstrumentLegFG = instrumentLegFG
        LegIOIQty = legIOIQty
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component, random access reader
let ReadLegStipulations (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegStipulations =
    let noLegStipulationsGrp = ReadOptionalGroup bs index 683 ReadNoLegStipulationsGrp
    let ci:LegStipulations = {
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadLegStipulationsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LegStipulations =
    let noLegStipulationsGrp = ReadOptionalGroupOrdered true bs index 683 ReadNoLegStipulationsGrp
    let ci:LegStipulations = {
        NoLegStipulationsGrp = noLegStipulationsGrp
    }
    ci


// component, random access reader
let ReadStipulations (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Stipulations =
    let noStipulationsGrp = ReadOptionalGroup bs index 232 ReadNoStipulationsGrp
    let ci:Stipulations = {
        NoStipulationsGrp = noStipulationsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadStipulationsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : Stipulations =
    let noStipulationsGrp = ReadOptionalGroupOrdered true bs index 232 ReadNoStipulationsGrp
    let ci:Stipulations = {
        NoStipulationsGrp = noStipulationsGrp
    }
    ci


// group
let ReadAdvertisementNoUnderlyingsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AdvertisementNoUnderlyingsGrp =
    let underlyingInstrument = ReadComponentOrdered true bs index ReadUnderlyingInstrumentOrdered
    let ci:AdvertisementNoUnderlyingsGrp = {
        UnderlyingInstrument = underlyingInstrument
    }
    ci


// component, random access reader
let ReadUnderlyingStipulations (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingStipulations =
    let noUnderlyingStipsGrp = ReadOptionalGroup bs index 887 ReadNoUnderlyingStipsGrp
    let ci:UnderlyingStipulations = {
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadUnderlyingStipulationsOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : UnderlyingStipulations =
    let noUnderlyingStipsGrp = ReadOptionalGroupOrdered true bs index 887 ReadNoUnderlyingStipsGrp
    let ci:UnderlyingStipulations = {
        NoUnderlyingStipsGrp = noUnderlyingStipsGrp
    }
    ci


// component, random access reader
let ReadInstrumentLeg (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLeg =
    let legSymbol = ReadOptionalField bs index 600 ReadLegSymbol
    let legSymbolSfx = ReadOptionalField bs index 601 ReadLegSymbolSfx
    let legSecurityID = ReadOptionalField bs index 602 ReadLegSecurityID
    let legSecurityIDSource = ReadOptionalField bs index 603 ReadLegSecurityIDSource
    let noLegSecurityAltIDGrp = ReadOptionalGroup bs index 604 ReadNoLegSecurityAltIDGrp
    let legProduct = ReadOptionalField bs index 607 ReadLegProduct
    let legCFICode = ReadOptionalField bs index 608 ReadLegCFICode
    let legSecurityType = ReadOptionalField bs index 609 ReadLegSecurityType
    let legSecuritySubType = ReadOptionalField bs index 764 ReadLegSecuritySubType
    let legMaturityMonthYear = ReadOptionalField bs index 610 ReadLegMaturityMonthYear
    let legMaturityDate = ReadOptionalField bs index 611 ReadLegMaturityDate
    let legCouponPaymentDate = ReadOptionalField bs index 248 ReadLegCouponPaymentDate
    let legIssueDate = ReadOptionalField bs index 249 ReadLegIssueDate
    let legRepoCollateralSecurityType = ReadOptionalField bs index 250 ReadLegRepoCollateralSecurityType
    let legRepurchaseTerm = ReadOptionalField bs index 251 ReadLegRepurchaseTerm
    let legRepurchaseRate = ReadOptionalField bs index 252 ReadLegRepurchaseRate
    let legFactor = ReadOptionalField bs index 253 ReadLegFactor
    let legCreditRating = ReadOptionalField bs index 257 ReadLegCreditRating
    let legInstrRegistry = ReadOptionalField bs index 599 ReadLegInstrRegistry
    let legCountryOfIssue = ReadOptionalField bs index 596 ReadLegCountryOfIssue
    let legStateOrProvinceOfIssue = ReadOptionalField bs index 597 ReadLegStateOrProvinceOfIssue
    let legLocaleOfIssue = ReadOptionalField bs index 598 ReadLegLocaleOfIssue
    let legRedemptionDate = ReadOptionalField bs index 254 ReadLegRedemptionDate
    let legStrikePrice = ReadOptionalField bs index 612 ReadLegStrikePrice
    let legStrikeCurrency = ReadOptionalField bs index 942 ReadLegStrikeCurrency
    let legOptAttribute = ReadOptionalField bs index 613 ReadLegOptAttribute
    let legContractMultiplier = ReadOptionalField bs index 614 ReadLegContractMultiplier
    let legCouponRate = ReadOptionalField bs index 615 ReadLegCouponRate
    let legSecurityExchange = ReadOptionalField bs index 616 ReadLegSecurityExchange
    let legIssuer = ReadOptionalField bs index 617 ReadLegIssuer
    let encodedLegIssuer = ReadOptionalField bs index 618 ReadEncodedLegIssuer
    let legSecurityDesc = ReadOptionalField bs index 620 ReadLegSecurityDesc
    let encodedLegSecurityDesc = ReadOptionalField bs index 621 ReadEncodedLegSecurityDesc
    let legRatioQty = ReadOptionalField bs index 623 ReadLegRatioQty
    let legSide = ReadOptionalField bs index 624 ReadLegSide
    let legCurrency = ReadOptionalField bs index 556 ReadLegCurrency
    let legPool = ReadOptionalField bs index 740 ReadLegPool
    let legDatedDate = ReadOptionalField bs index 739 ReadLegDatedDate
    let legContractSettlMonth = ReadOptionalField bs index 955 ReadLegContractSettlMonth
    let legInterestAccrualDate = ReadOptionalField bs index 956 ReadLegInterestAccrualDate
    let ci:InstrumentLeg = {
        LegSymbol = legSymbol
        LegSymbolSfx = legSymbolSfx
        LegSecurityID = legSecurityID
        LegSecurityIDSource = legSecurityIDSource
        NoLegSecurityAltIDGrp = noLegSecurityAltIDGrp
        LegProduct = legProduct
        LegCFICode = legCFICode
        LegSecurityType = legSecurityType
        LegSecuritySubType = legSecuritySubType
        LegMaturityMonthYear = legMaturityMonthYear
        LegMaturityDate = legMaturityDate
        LegCouponPaymentDate = legCouponPaymentDate
        LegIssueDate = legIssueDate
        LegRepoCollateralSecurityType = legRepoCollateralSecurityType
        LegRepurchaseTerm = legRepurchaseTerm
        LegRepurchaseRate = legRepurchaseRate
        LegFactor = legFactor
        LegCreditRating = legCreditRating
        LegInstrRegistry = legInstrRegistry
        LegCountryOfIssue = legCountryOfIssue
        LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
        LegLocaleOfIssue = legLocaleOfIssue
        LegRedemptionDate = legRedemptionDate
        LegStrikePrice = legStrikePrice
        LegStrikeCurrency = legStrikeCurrency
        LegOptAttribute = legOptAttribute
        LegContractMultiplier = legContractMultiplier
        LegCouponRate = legCouponRate
        LegSecurityExchange = legSecurityExchange
        LegIssuer = legIssuer
        EncodedLegIssuer = encodedLegIssuer
        LegSecurityDesc = legSecurityDesc
        EncodedLegSecurityDesc = encodedLegSecurityDesc
        LegRatioQty = legRatioQty
        LegSide = legSide
        LegCurrency = legCurrency
        LegPool = legPool
        LegDatedDate = legDatedDate
        LegContractSettlMonth = legContractSettlMonth
        LegInterestAccrualDate = legInterestAccrualDate
    }
    ci


// component, ordered reader i.e. fields are in sequential order in the FIX buffer
let ReadInstrumentLegOrdered (bb:bool) (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : InstrumentLeg =
    let legSymbol = ReadOptionalFieldOrdered true bs index 600 ReadLegSymbol
    let legSymbolSfx = ReadOptionalFieldOrdered true bs index 601 ReadLegSymbolSfx
    let legSecurityID = ReadOptionalFieldOrdered true bs index 602 ReadLegSecurityID
    let legSecurityIDSource = ReadOptionalFieldOrdered true bs index 603 ReadLegSecurityIDSource
    let noLegSecurityAltIDGrp = ReadOptionalGroupOrdered true bs index 604 ReadNoLegSecurityAltIDGrp
    let legProduct = ReadOptionalFieldOrdered true bs index 607 ReadLegProduct
    let legCFICode = ReadOptionalFieldOrdered true bs index 608 ReadLegCFICode
    let legSecurityType = ReadOptionalFieldOrdered true bs index 609 ReadLegSecurityType
    let legSecuritySubType = ReadOptionalFieldOrdered true bs index 764 ReadLegSecuritySubType
    let legMaturityMonthYear = ReadOptionalFieldOrdered true bs index 610 ReadLegMaturityMonthYear
    let legMaturityDate = ReadOptionalFieldOrdered true bs index 611 ReadLegMaturityDate
    let legCouponPaymentDate = ReadOptionalFieldOrdered true bs index 248 ReadLegCouponPaymentDate
    let legIssueDate = ReadOptionalFieldOrdered true bs index 249 ReadLegIssueDate
    let legRepoCollateralSecurityType = ReadOptionalFieldOrdered true bs index 250 ReadLegRepoCollateralSecurityType
    let legRepurchaseTerm = ReadOptionalFieldOrdered true bs index 251 ReadLegRepurchaseTerm
    let legRepurchaseRate = ReadOptionalFieldOrdered true bs index 252 ReadLegRepurchaseRate
    let legFactor = ReadOptionalFieldOrdered true bs index 253 ReadLegFactor
    let legCreditRating = ReadOptionalFieldOrdered true bs index 257 ReadLegCreditRating
    let legInstrRegistry = ReadOptionalFieldOrdered true bs index 599 ReadLegInstrRegistry
    let legCountryOfIssue = ReadOptionalFieldOrdered true bs index 596 ReadLegCountryOfIssue
    let legStateOrProvinceOfIssue = ReadOptionalFieldOrdered true bs index 597 ReadLegStateOrProvinceOfIssue
    let legLocaleOfIssue = ReadOptionalFieldOrdered true bs index 598 ReadLegLocaleOfIssue
    let legRedemptionDate = ReadOptionalFieldOrdered true bs index 254 ReadLegRedemptionDate
    let legStrikePrice = ReadOptionalFieldOrdered true bs index 612 ReadLegStrikePrice
    let legStrikeCurrency = ReadOptionalFieldOrdered true bs index 942 ReadLegStrikeCurrency
    let legOptAttribute = ReadOptionalFieldOrdered true bs index 613 ReadLegOptAttribute
    let legContractMultiplier = ReadOptionalFieldOrdered true bs index 614 ReadLegContractMultiplier
    let legCouponRate = ReadOptionalFieldOrdered true bs index 615 ReadLegCouponRate
    let legSecurityExchange = ReadOptionalFieldOrdered true bs index 616 ReadLegSecurityExchange
    let legIssuer = ReadOptionalFieldOrdered true bs index 617 ReadLegIssuer
    let encodedLegIssuer = ReadOptionalFieldOrdered true bs index 618 ReadEncodedLegIssuer
    let legSecurityDesc = ReadOptionalFieldOrdered true bs index 620 ReadLegSecurityDesc
    let encodedLegSecurityDesc = ReadOptionalFieldOrdered true bs index 621 ReadEncodedLegSecurityDesc
    let legRatioQty = ReadOptionalFieldOrdered true bs index 623 ReadLegRatioQty
    let legSide = ReadOptionalFieldOrdered true bs index 624 ReadLegSide
    let legCurrency = ReadOptionalFieldOrdered true bs index 556 ReadLegCurrency
    let legPool = ReadOptionalFieldOrdered true bs index 740 ReadLegPool
    let legDatedDate = ReadOptionalFieldOrdered true bs index 739 ReadLegDatedDate
    let legContractSettlMonth = ReadOptionalFieldOrdered true bs index 955 ReadLegContractSettlMonth
    let legInterestAccrualDate = ReadOptionalFieldOrdered true bs index 956 ReadLegInterestAccrualDate
    let ci:InstrumentLeg = {
        LegSymbol = legSymbol
        LegSymbolSfx = legSymbolSfx
        LegSecurityID = legSecurityID
        LegSecurityIDSource = legSecurityIDSource
        NoLegSecurityAltIDGrp = noLegSecurityAltIDGrp
        LegProduct = legProduct
        LegCFICode = legCFICode
        LegSecurityType = legSecurityType
        LegSecuritySubType = legSecuritySubType
        LegMaturityMonthYear = legMaturityMonthYear
        LegMaturityDate = legMaturityDate
        LegCouponPaymentDate = legCouponPaymentDate
        LegIssueDate = legIssueDate
        LegRepoCollateralSecurityType = legRepoCollateralSecurityType
        LegRepurchaseTerm = legRepurchaseTerm
        LegRepurchaseRate = legRepurchaseRate
        LegFactor = legFactor
        LegCreditRating = legCreditRating
        LegInstrRegistry = legInstrRegistry
        LegCountryOfIssue = legCountryOfIssue
        LegStateOrProvinceOfIssue = legStateOrProvinceOfIssue
        LegLocaleOfIssue = legLocaleOfIssue
        LegRedemptionDate = legRedemptionDate
        LegStrikePrice = legStrikePrice
        LegStrikeCurrency = legStrikeCurrency
        LegOptAttribute = legOptAttribute
        LegContractMultiplier = legContractMultiplier
        LegCouponRate = legCouponRate
        LegSecurityExchange = legSecurityExchange
        LegIssuer = legIssuer
        EncodedLegIssuer = encodedLegIssuer
        LegSecurityDesc = legSecurityDesc
        EncodedLegSecurityDesc = encodedLegSecurityDesc
        LegRatioQty = legRatioQty
        LegSide = legSide
        LegCurrency = legCurrency
        LegPool = legPool
        LegDatedDate = legDatedDate
        LegContractSettlMonth = legContractSettlMonth
        LegInterestAccrualDate = legInterestAccrualDate
    }
    ci


// group
let ReadNoMsgTypesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMsgTypesGrp =
    let refMsgType = ReadFieldOrdered true bs index 372 ReadRefMsgType
    let msgDirection = ReadOptionalFieldOrdered true bs index 385 ReadMsgDirection
    let ci:NoMsgTypesGrp = {
        RefMsgType = refMsgType
        MsgDirection = msgDirection
    }
    ci


// group
let ReadNoIOIQualifiersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoIOIQualifiersGrp =
    let iOIQualifier = ReadFieldOrdered true bs index 104 ReadIOIQualifier
    let ci:NoIOIQualifiersGrp = {
        IOIQualifier = iOIQualifier
    }
    ci


// group
let ReadNoRoutingIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoRoutingIDsGrp =
    let routingType = ReadFieldOrdered true bs index 216 ReadRoutingType
    let routingID = ReadOptionalFieldOrdered true bs index 217 ReadRoutingID
    let ci:NoRoutingIDsGrp = {
        RoutingType = routingType
        RoutingID = routingID
    }
    ci


// group
let ReadLinesOfTextGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : LinesOfTextGrp =
    let text = ReadFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:LinesOfTextGrp = {
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoMDEntryTypesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntryTypesGrp =
    let mDEntryType = ReadFieldOrdered true bs index 269 ReadMDEntryType
    let ci:NoMDEntryTypesGrp = {
        MDEntryType = mDEntryType
    }
    ci


// group
let ReadNoMDEntriesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoMDEntriesGrp =
    let mDEntryType = ReadFieldOrdered true bs index 269 ReadMDEntryType
    let mDEntryPx = ReadOptionalFieldOrdered true bs index 270 ReadMDEntryPx
    let currency = ReadOptionalFieldOrdered true bs index 15 ReadCurrency
    let mDEntrySize = ReadOptionalFieldOrdered true bs index 271 ReadMDEntrySize
    let mDEntryDate = ReadOptionalFieldOrdered true bs index 272 ReadMDEntryDate
    let mDEntryTime = ReadOptionalFieldOrdered true bs index 273 ReadMDEntryTime
    let tickDirection = ReadOptionalFieldOrdered true bs index 274 ReadTickDirection
    let mDMkt = ReadOptionalFieldOrdered true bs index 275 ReadMDMkt
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let quoteCondition = ReadOptionalFieldOrdered true bs index 276 ReadQuoteCondition
    let tradeCondition = ReadOptionalFieldOrdered true bs index 277 ReadTradeCondition
    let mDEntryOriginator = ReadOptionalFieldOrdered true bs index 282 ReadMDEntryOriginator
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationID
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskID
    let openCloseSettlFlag = ReadOptionalFieldOrdered true bs index 286 ReadOpenCloseSettlFlag
    let timeInForce = ReadOptionalFieldOrdered true bs index 59 ReadTimeInForce
    let expireDate = ReadOptionalFieldOrdered true bs index 432 ReadExpireDate
    let expireTime = ReadOptionalFieldOrdered true bs index 126 ReadExpireTime
    let minQty = ReadOptionalFieldOrdered true bs index 110 ReadMinQty
    let execInst = ReadOptionalFieldOrdered true bs index 18 ReadExecInst
    let sellerDays = ReadOptionalFieldOrdered true bs index 287 ReadSellerDays
    let orderID = ReadOptionalFieldOrdered true bs index 37 ReadOrderID
    let quoteEntryID = ReadOptionalFieldOrdered true bs index 299 ReadQuoteEntryID
    let mDEntryBuyer = ReadOptionalFieldOrdered true bs index 288 ReadMDEntryBuyer
    let mDEntrySeller = ReadOptionalFieldOrdered true bs index 289 ReadMDEntrySeller
    let numberOfOrders = ReadOptionalFieldOrdered true bs index 346 ReadNumberOfOrders
    let mDEntryPositionNo = ReadOptionalFieldOrdered true bs index 290 ReadMDEntryPositionNo
    let scope = ReadOptionalFieldOrdered true bs index 546 ReadScope
    let priceDelta = ReadOptionalFieldOrdered true bs index 811 ReadPriceDelta
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:NoMDEntriesGrp = {
        MDEntryType = mDEntryType
        MDEntryPx = mDEntryPx
        Currency = currency
        MDEntrySize = mDEntrySize
        MDEntryDate = mDEntryDate
        MDEntryTime = mDEntryTime
        TickDirection = tickDirection
        MDMkt = mDMkt
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        QuoteCondition = quoteCondition
        TradeCondition = tradeCondition
        MDEntryOriginator = mDEntryOriginator
        LocationID = locationID
        DeskID = deskID
        OpenCloseSettlFlag = openCloseSettlFlag
        TimeInForce = timeInForce
        ExpireDate = expireDate
        ExpireTime = expireTime
        MinQty = minQty
        ExecInst = execInst
        SellerDays = sellerDays
        OrderID = orderID
        QuoteEntryID = quoteEntryID
        MDEntryBuyer = mDEntryBuyer
        MDEntrySeller = mDEntrySeller
        NumberOfOrders = numberOfOrders
        MDEntryPositionNo = mDEntryPositionNo
        Scope = scope
        PriceDelta = priceDelta
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadNoAltMDSourceGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAltMDSourceGrp =
    let altMDSourceID = ReadFieldOrdered true bs index 817 ReadAltMDSourceID
    let ci:NoAltMDSourceGrp = {
        AltMDSourceID = altMDSourceID
    }
    ci


// group
let ReadNoSecurityTypesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoSecurityTypesGrp =
    let securityType = ReadFieldOrdered true bs index 167 ReadSecurityType
    let securitySubType = ReadOptionalFieldOrdered true bs index 762 ReadSecuritySubType
    let product = ReadOptionalFieldOrdered true bs index 460 ReadProduct
    let cFICode = ReadOptionalFieldOrdered true bs index 461 ReadCFICode
    let ci:NoSecurityTypesGrp = {
        SecurityType = securityType
        SecuritySubType = securitySubType
        Product = product
        CFICode = cFICode
    }
    ci


// group
let ReadNoContraBrokersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoContraBrokersGrp =
    let contraBroker = ReadFieldOrdered true bs index 375 ReadContraBroker
    let contraTrader = ReadOptionalFieldOrdered true bs index 337 ReadContraTrader
    let contraTradeQty = ReadOptionalFieldOrdered true bs index 437 ReadContraTradeQty
    let contraTradeTime = ReadOptionalFieldOrdered true bs index 438 ReadContraTradeTime
    let contraLegRefID = ReadOptionalFieldOrdered true bs index 655 ReadContraLegRefID
    let ci:NoContraBrokersGrp = {
        ContraBroker = contraBroker
        ContraTrader = contraTrader
        ContraTradeQty = contraTradeQty
        ContraTradeTime = contraTradeTime
        ContraLegRefID = contraLegRefID
    }
    ci


// group
let ReadNoAffectedOrdersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoAffectedOrdersGrp =
    let origClOrdID = ReadFieldOrdered true bs index 41 ReadOrigClOrdID
    let affectedOrderID = ReadOptionalFieldOrdered true bs index 535 ReadAffectedOrderID
    let affectedSecondaryOrderID = ReadOptionalFieldOrdered true bs index 536 ReadAffectedSecondaryOrderID
    let ci:NoAffectedOrdersGrp = {
        OrigClOrdID = origClOrdID
        AffectedOrderID = affectedOrderID
        AffectedSecondaryOrderID = affectedSecondaryOrderID
    }
    ci


// group
let ReadNoBidDescriptorsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoBidDescriptorsGrp =
    let bidDescriptorType = ReadFieldOrdered true bs index 399 ReadBidDescriptorType
    let bidDescriptor = ReadOptionalFieldOrdered true bs index 400 ReadBidDescriptor
    let sideValueInd = ReadOptionalFieldOrdered true bs index 401 ReadSideValueInd
    let liquidityValue = ReadOptionalFieldOrdered true bs index 404 ReadLiquidityValue
    let liquidityNumSecurities = ReadOptionalFieldOrdered true bs index 441 ReadLiquidityNumSecurities
    let liquidityPctLow = ReadOptionalFieldOrdered true bs index 402 ReadLiquidityPctLow
    let liquidityPctHigh = ReadOptionalFieldOrdered true bs index 403 ReadLiquidityPctHigh
    let eFPTrackingError = ReadOptionalFieldOrdered true bs index 405 ReadEFPTrackingError
    let fairValue = ReadOptionalFieldOrdered true bs index 406 ReadFairValue
    let outsideIndexPct = ReadOptionalFieldOrdered true bs index 407 ReadOutsideIndexPct
    let valueOfFutures = ReadOptionalFieldOrdered true bs index 408 ReadValueOfFutures
    let ci:NoBidDescriptorsGrp = {
        BidDescriptorType = bidDescriptorType
        BidDescriptor = bidDescriptor
        SideValueInd = sideValueInd
        LiquidityValue = liquidityValue
        LiquidityNumSecurities = liquidityNumSecurities
        LiquidityPctLow = liquidityPctLow
        LiquidityPctHigh = liquidityPctHigh
        EFPTrackingError = eFPTrackingError
        FairValue = fairValue
        OutsideIndexPct = outsideIndexPct
        ValueOfFutures = valueOfFutures
    }
    ci


// group
let ReadNoBidComponentsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoBidComponentsGrp =
    let listID = ReadFieldOrdered true bs index 66 ReadListID
    let side = ReadOptionalFieldOrdered true bs index 54 ReadSide
    let tradingSessionID = ReadOptionalFieldOrdered true bs index 336 ReadTradingSessionID
    let tradingSessionSubID = ReadOptionalFieldOrdered true bs index 625 ReadTradingSessionSubID
    let netGrossInd = ReadOptionalFieldOrdered true bs index 430 ReadNetGrossInd
    let settlType = ReadOptionalFieldOrdered true bs index 63 ReadSettlType
    let settlDate = ReadOptionalFieldOrdered true bs index 64 ReadSettlDate
    let account = ReadOptionalFieldOrdered true bs index 1 ReadAccount
    let acctIDSource = ReadOptionalFieldOrdered true bs index 660 ReadAcctIDSource
    let ci:NoBidComponentsGrp = {
        ListID = listID
        Side = side
        TradingSessionID = tradingSessionID
        TradingSessionSubID = tradingSessionSubID
        NetGrossInd = netGrossInd
        SettlType = settlType
        SettlDate = settlDate
        Account = account
        AcctIDSource = acctIDSource
    }
    ci


// group
let ReadListStatusNoOrdersGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : ListStatusNoOrdersGrp =
    let clOrdID = ReadFieldOrdered true bs index 11 ReadClOrdID
    let secondaryClOrdID = ReadOptionalFieldOrdered true bs index 526 ReadSecondaryClOrdID
    let cumQty = ReadFieldOrdered true bs index 14 ReadCumQty
    let ordStatus = ReadFieldOrdered true bs index 39 ReadOrdStatus
    let workingIndicator = ReadOptionalFieldOrdered true bs index 636 ReadWorkingIndicator
    let leavesQty = ReadFieldOrdered true bs index 151 ReadLeavesQty
    let cxlQty = ReadFieldOrdered true bs index 84 ReadCxlQty
    let avgPx = ReadFieldOrdered true bs index 6 ReadAvgPx
    let ordRejReason = ReadOptionalFieldOrdered true bs index 103 ReadOrdRejReason
    let text = ReadOptionalFieldOrdered true bs index 58 ReadText
    let encodedText = ReadOptionalFieldOrdered true bs index 354 ReadEncodedText
    let ci:ListStatusNoOrdersGrp = {
        ClOrdID = clOrdID
        SecondaryClOrdID = secondaryClOrdID
        CumQty = cumQty
        OrdStatus = ordStatus
        WorkingIndicator = workingIndicator
        LeavesQty = leavesQty
        CxlQty = cxlQty
        AvgPx = avgPx
        OrdRejReason = ordRejReason
        Text = text
        EncodedText = encodedText
    }
    ci


// group
let ReadAllocationInstructionNoExecsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationInstructionNoExecsGrp =
    let lastQty = ReadFieldOrdered true bs index 32 ReadLastQty
    let execID = ReadOptionalFieldOrdered true bs index 17 ReadExecID
    let secondaryExecID = ReadOptionalFieldOrdered true bs index 527 ReadSecondaryExecID
    let lastPx = ReadOptionalFieldOrdered true bs index 31 ReadLastPx
    let lastParPx = ReadOptionalFieldOrdered true bs index 669 ReadLastParPx
    let lastCapacity = ReadOptionalFieldOrdered true bs index 29 ReadLastCapacity
    let ci:AllocationInstructionNoExecsGrp = {
        LastQty = lastQty
        ExecID = execID
        SecondaryExecID = secondaryExecID
        LastPx = lastPx
        LastParPx = lastParPx
        LastCapacity = lastCapacity
    }
    ci


// group
let ReadAllocationInstructionAckNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationInstructionAckNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPrice
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let individualAllocRejCode = ReadOptionalFieldOrdered true bs index 776 ReadIndividualAllocRejCode
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocText
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocText
    let ci:AllocationInstructionAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocPrice = allocPrice
        IndividualAllocID = individualAllocID
        IndividualAllocRejCode = individualAllocRejCode
        AllocText = allocText
        EncodedAllocText = encodedAllocText
    }
    ci


// group
let ReadAllocationReportNoExecsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportNoExecsGrp =
    let lastQty = ReadFieldOrdered true bs index 32 ReadLastQty
    let execID = ReadOptionalFieldOrdered true bs index 17 ReadExecID
    let secondaryExecID = ReadOptionalFieldOrdered true bs index 527 ReadSecondaryExecID
    let lastPx = ReadOptionalFieldOrdered true bs index 31 ReadLastPx
    let lastParPx = ReadOptionalFieldOrdered true bs index 669 ReadLastParPx
    let lastCapacity = ReadOptionalFieldOrdered true bs index 29 ReadLastCapacity
    let ci:AllocationReportNoExecsGrp = {
        LastQty = lastQty
        ExecID = execID
        SecondaryExecID = secondaryExecID
        LastPx = lastPx
        LastParPx = lastParPx
        LastCapacity = lastCapacity
    }
    ci


// group
let ReadAllocationReportAckNoAllocsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : AllocationReportAckNoAllocsGrp =
    let allocAccount = ReadFieldOrdered true bs index 79 ReadAllocAccount
    let allocAcctIDSource = ReadOptionalFieldOrdered true bs index 661 ReadAllocAcctIDSource
    let allocPrice = ReadOptionalFieldOrdered true bs index 366 ReadAllocPrice
    let individualAllocID = ReadOptionalFieldOrdered true bs index 467 ReadIndividualAllocID
    let individualAllocRejCode = ReadOptionalFieldOrdered true bs index 776 ReadIndividualAllocRejCode
    let allocText = ReadOptionalFieldOrdered true bs index 161 ReadAllocText
    let encodedAllocText = ReadOptionalFieldOrdered true bs index 360 ReadEncodedAllocText
    let ci:AllocationReportAckNoAllocsGrp = {
        AllocAccount = allocAccount
        AllocAcctIDSource = allocAcctIDSource
        AllocPrice = allocPrice
        IndividualAllocID = individualAllocID
        IndividualAllocRejCode = individualAllocRejCode
        AllocText = allocText
        EncodedAllocText = encodedAllocText
    }
    ci


// group
let ReadNoCapacitiesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCapacitiesGrp =
    let orderCapacity = ReadFieldOrdered true bs index 528 ReadOrderCapacity
    let orderRestrictions = ReadOptionalFieldOrdered true bs index 529 ReadOrderRestrictions
    let orderCapacityQty = ReadFieldOrdered true bs index 863 ReadOrderCapacityQty
    let ci:NoCapacitiesGrp = {
        OrderCapacity = orderCapacity
        OrderRestrictions = orderRestrictions
        OrderCapacityQty = orderCapacityQty
    }
    ci


// group
let ReadNoDatesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDatesGrp =
    let tradeDate = ReadFieldOrdered true bs index 75 ReadTradeDate
    let transactTime = ReadOptionalFieldOrdered true bs index 60 ReadTransactTime
    let ci:NoDatesGrp = {
        TradeDate = tradeDate
        TransactTime = transactTime
    }
    ci


// group
let ReadNoDistribInstsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoDistribInstsGrp =
    let distribPaymentMethod = ReadFieldOrdered true bs index 477 ReadDistribPaymentMethod
    let distribPercentage = ReadOptionalFieldOrdered true bs index 512 ReadDistribPercentage
    let cashDistribCurr = ReadOptionalFieldOrdered true bs index 478 ReadCashDistribCurr
    let cashDistribAgentName = ReadOptionalFieldOrdered true bs index 498 ReadCashDistribAgentName
    let cashDistribAgentCode = ReadOptionalFieldOrdered true bs index 499 ReadCashDistribAgentCode
    let cashDistribAgentAcctNumber = ReadOptionalFieldOrdered true bs index 500 ReadCashDistribAgentAcctNumber
    let cashDistribPayRef = ReadOptionalFieldOrdered true bs index 501 ReadCashDistribPayRef
    let cashDistribAgentAcctName = ReadOptionalFieldOrdered true bs index 502 ReadCashDistribAgentAcctName
    let ci:NoDistribInstsGrp = {
        DistribPaymentMethod = distribPaymentMethod
        DistribPercentage = distribPercentage
        CashDistribCurr = cashDistribCurr
        CashDistribAgentName = cashDistribAgentName
        CashDistribAgentCode = cashDistribAgentCode
        CashDistribAgentAcctNumber = cashDistribAgentAcctNumber
        CashDistribPayRef = cashDistribPayRef
        CashDistribAgentAcctName = cashDistribAgentAcctName
    }
    ci


// group
let ReadNoExecsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoExecsGrp =
    let execID = ReadFieldOrdered true bs index 17 ReadExecID
    let ci:NoExecsGrp = {
        ExecID = execID
    }
    ci


// group
let ReadNoTradesGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoTradesGrp =
    let tradeReportID = ReadFieldOrdered true bs index 571 ReadTradeReportID
    let secondaryTradeReportID = ReadOptionalFieldOrdered true bs index 818 ReadSecondaryTradeReportID
    let ci:NoTradesGrp = {
        TradeReportID = tradeReportID
        SecondaryTradeReportID = secondaryTradeReportID
    }
    ci


// group
let ReadNoCollInquiryQualifierGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCollInquiryQualifierGrp =
    let collInquiryQualifier = ReadFieldOrdered true bs index 896 ReadCollInquiryQualifier
    let ci:NoCollInquiryQualifierGrp = {
        CollInquiryQualifier = collInquiryQualifier
    }
    ci


// group
let ReadNoCompIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoCompIDsGrp =
    let refCompID = ReadFieldOrdered true bs index 930 ReadRefCompID
    let refSubID = ReadOptionalFieldOrdered true bs index 931 ReadRefSubID
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationID
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskID
    let ci:NoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
    }
    ci


// group
let ReadNetworkStatusResponseNoCompIDsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NetworkStatusResponseNoCompIDsGrp =
    let refCompID = ReadFieldOrdered true bs index 930 ReadRefCompID
    let refSubID = ReadOptionalFieldOrdered true bs index 931 ReadRefSubID
    let locationID = ReadOptionalFieldOrdered true bs index 283 ReadLocationID
    let deskID = ReadOptionalFieldOrdered true bs index 284 ReadDeskID
    let statusValue = ReadOptionalFieldOrdered true bs index 928 ReadStatusValue
    let statusText = ReadOptionalFieldOrdered true bs index 929 ReadStatusText
    let ci:NetworkStatusResponseNoCompIDsGrp = {
        RefCompID = refCompID
        RefSubID = refSubID
        LocationID = locationID
        DeskID = deskID
        StatusValue = statusValue
        StatusText = statusText
    }
    ci


// group
let ReadNoHopsGrp (bs:byte[]) (index:FIXBufIndexer.FixBufIndex) : NoHopsGrp =
    let hopCompID = ReadFieldOrdered true bs index 628 ReadHopCompID
    let hopSendingTime = ReadOptionalFieldOrdered true bs index 629 ReadHopSendingTime
    let hopRefID = ReadOptionalFieldOrdered true bs index 630 ReadHopRefID
    let ci:NoHopsGrp = {
        HopCompID = hopCompID
        HopSendingTime = hopSendingTime
        HopRefID = hopRefID
    }
    ci


