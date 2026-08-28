export const ReadingStatusEnum = {
    0: { name: "Maybe Read" },
    1: { name: "To Read" },
    2: { name: "Reading" },
    3: { name: "Re Reading" },
    4: { name: "On Hold" },
    5: { name: "Waiting Completion" },
    6: { name: "Finished" },
    7: { name: "Abandoned" }

} as const;

export type ReadingStatusEnum = typeof ReadingStatusEnum[keyof typeof ReadingStatusEnum];