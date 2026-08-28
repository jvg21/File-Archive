export const WritingStatusEnum = {
    0: { name: "In Progress" },
    1: { name: "Hiatus" },
    2: { name: "Finished" },
    3: { name: "Abandoned" },

} as const;

export type WritingStatusEnum = typeof WritingStatusEnum[keyof typeof WritingStatusEnum];