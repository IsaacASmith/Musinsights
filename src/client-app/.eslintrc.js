module.exports = {
  root: true,

  env: {
    node: true
  },

  extends: [
    'plugin:vue/essential',
    '@vue/standard'
  ],

  parserOptions: {
    parser: 'babel-eslint'
  },

  rules: {
    'no-console': 'off',
    'no-debugger': 'off',
    'vue/no-shared-component-data': 'warn',
    'vue/no-side-effects-in-computed-properties': 'warn',
    'vue/no-template-key': 'warn',
    'vue/no-textarea-mustache': 'warn',
    'vue/no-unused-components': 'warn',
    'vue/no-unused-vars': 'warn'
  },

  'extends': [
    'plugin:vue/essential',
    '@vue/standard'
  ]
}
