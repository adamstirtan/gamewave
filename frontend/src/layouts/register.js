export function registerLayouts(app) {
    const layouts = import.meta.globEager('./*.vue')

    Object.entries(layouts).forEach(([, layout]) => {
        app.component(layout?.default?.name, layout?.default)
    })
}