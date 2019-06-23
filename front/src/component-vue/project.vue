<template>
	<div v-if="info">
		<div><strong>Имя</strong>: {{info.Name}}</div>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'university',
		data() {
			return {
				info: null,
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/project/' + this.$route.params.id)
				.then(response => {
					this.info = response.data;
				});
		}
	};
</script>
