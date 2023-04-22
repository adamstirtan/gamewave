function toSlug(value) {
    return value.trim().toLowerCase().replaceAll(' ', '-').replace(/[^a-z0-9-_]/g, '')
}

export {
    toSlug
}