﻿

import { MetaSetDto } from "../MetaSetDto";
import { DictionaryDto } from "../../objects/dictionary/DictionaryDto";

export interface ConfigurationDto extends MetaSetDto {
    creationDate: string;
    lastModificationDate: string;
    description: DictionaryDto;
    title: DictionaryDto;
    children: any[];
    childrenSpecficied: boolean;
    usedItemIds: any[];
    usedItemIdsSpecified: boolean;
    shouldUsedItemIds: boolean;
}